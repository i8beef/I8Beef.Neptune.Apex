using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using I8Beef.Neptune.Apex.Schema;

namespace I8Beef.Neptune.Apex
{
    /// <inheritdoc />
    public class Client : IClient
    {
        private static readonly HttpClient _httpClient = new HttpClient { Timeout = Timeout.InfiniteTimeSpan };
        private readonly string _host;
        private readonly string _username;
        private readonly string _password;
        private TimeSpan _timeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="host">Apex IP.</param>
        /// <param name="username">Apex username.</param>
        /// <param name="password">Apex password.</param>
        public Client(string host, string username, string password)
            : this(host, username, password, TimeSpan.FromSeconds(100))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="host">Apex IP.</param>
        /// <param name="username">Apex username.</param>
        /// <param name="password">Apex password.</param>
        /// <param name="timeout">Timeout to use for all HTTP calls.</param>
        public Client(string host, string username, string password, TimeSpan timeout)
        {
            _host = host;
            _username = username;
            _password = password;
            _timeout = timeout;
        }

        /// <inheritdoc />
        public async Task<Status> GetStatus(CancellationToken cancellationToken = default)
        {
            return await Get<Status>("http://" + _host + "/cgi-bin/status.xml", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Program> GetProgram(CancellationToken cancellationToken = default)
        {
            return await Get<Program>("http://" + _host + "/cgi-bin/program.xml", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<DataLog> GetDataLog(CancellationToken cancellationToken = default)
        {
            return await Get<DataLog>("http://" + _host + "/cgi-bin/datalog.xml", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<DataLog> GetDataLog(DateTime startDate, int days, CancellationToken cancellationToken = default)
        {
            return await Get<DataLog>("http://" + _host + "/cgi-bin/datalog.xml?sdate=" + startDate.ToString("yyMMdd") + "&days=" + days, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task SetOutlet(string outletName, OutletState state, CancellationToken cancellationToken = default)
        {
            var request = new Dictionary<string, string>
            {
                { outletName + "_state", ((int)state).ToString() },
                { "noResponse", "1" }
            };

            await Post("http://" + _host + "/cgi-bin/status.cgi", request, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task SetFeed(FeedCycle cycle, CancellationToken cancellationToken = default)
        {
            var request = new Dictionary<string, string>
            {
                { "FeedCycle", "Feed" },
                { "FeedSel", ((int)cycle).ToString() },
                { "noResponse", "1" }
            };

            await Post("http://" + _host + "/cgi-bin/status.cgi", request, cancellationToken)
                .ConfigureAwait(false);
        }

        private async Task<TType> Get<TType>(string url, CancellationToken cancellationToken = default)
            where TType : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            // Set basic auth header
            var byteArray = Encoding.ASCII.GetBytes(_username + ":" + _password);
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = await SendAsyncWithTimeout(requestMessage, cancellationToken)
                .ConfigureAwait(false);
            var responseString = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Request failed with status code " + response.StatusCode);

            return XmlSerializer<TType>.Deserialize(responseString);
        }

        private async Task Post(string url, IDictionary<string, string> payload, CancellationToken cancellationToken = default)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(payload)
            };

            requestMessage.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Set basic auth header
            var byteArray = Encoding.ASCII.GetBytes(_username + ":" + _password);
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            try
            {
                var response = await SendAsyncWithTimeout(requestMessage, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (HttpRequestException ex) when (ex.InnerException != null && ex.InnerException.Message.StartsWith("The server returned an invalid or unrecognized response"))
            {
                // This will ALWAYS throw an exception because the Apex API doesn't even return a valid HTTP protocol response
                // Thus it is ignored. This is probably one of the more evil things I've ever written...
            }
        }

        /// <summary>
        /// Executes HttpClient.SendAsync() with a timeout extension.
        /// </summary>
        /// <param name="requestMessage">Same as parameters in HttpClient.SendAsync()</param>
        /// <param name="cancellationToken">Same as parameters in HttpClient.SendAsync()</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        /// <remarks>
        /// The HttpClient has a Timout feature that has been poorly implemented in that it raises an ambiguous exception on timeout.
        /// This wraps the HttpClient.SendAsync() and adds a proper timeout option.
        /// </remarks>
        private async Task<HttpResponseMessage> SendAsyncWithTimeout(HttpRequestMessage requestMessage, CancellationToken cancellationToken = default)
        {
            var timoutCts = new CancellationTokenSource(_timeout);
            var aggregateCts = CancellationTokenSource.CreateLinkedTokenSource(timoutCts.Token, cancellationToken);

            try
            {
                return await _httpClient.SendAsync(requestMessage, aggregateCts.Token)
                    .ConfigureAwait(false);
            }
            catch (TaskCanceledException) when (timoutCts.IsCancellationRequested)
            {
                throw new TimeoutException("HTTP request timed out.");
            }
        }
    }
}
