using System;
using System.Threading;
using System.Threading.Tasks;
using I8Beef.Neptune.Apex.Schema;

namespace I8Beef.Neptune.Apex
{
    /// <summary>
    /// Neptune Apex client.
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Gets the current data log of the unit.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Async task.</returns>
        Task<DataLog> GetDataLog(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the current data log of the unit.
        /// </summary>
        /// <param name="startDate">Start date.</param>
        /// <param name="days">Days of logs to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Async task.</returns>
        Task<DataLog> GetDataLog(DateTime startDate, int days, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the current program of the unit.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Async task.</returns>
        Task<Program> GetProgram(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the current status structure of the unit.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Async task.</returns>
        Task<Status> GetStatus(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets the feed cycle to the designated state.
        /// </summary>
        /// <param name="cycle">The feed cycle to use.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Async task.</returns>
        Task SetFeed(FeedCycle cycle, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets the outlet state for the designated outlet.
        /// </summary>
        /// <param name="outletName">The name of the outlet to set.</param>
        /// <param name="state">The state to set the outlet to.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Async task.</returns>
        Task SetOutlet(string outletName, OutletState state, CancellationToken cancellationToken = default(CancellationToken));
    }
}
