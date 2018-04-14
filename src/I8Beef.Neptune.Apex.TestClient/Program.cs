using System;
using System.Threading.Tasks;

namespace I8Beef.Neptune.Apex.TestClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args)
        {
            var ip = "blank";
            var username = "blank";
            var password = "blank";

            var client = new Client(ip, username, password);

            var status = await client.GetStatus();
            //var program = await client.GetProgram();
            //var dataLog = await client.GetDataLog();

            await client.SetOutlet("PowerHeadLF", OutletState.Auto);
            //await client.SetFeed(FeedCycle.A);

            Console.ReadKey();
        }
    }
}
