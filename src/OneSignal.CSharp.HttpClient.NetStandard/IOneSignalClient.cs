using OneSignal.CSharp.HttpClient.NetStandard.Resources.Devices;
using OneSignal.CSharp.HttpClient.NetStandard.Resources.Notifications;

namespace OneSignal.CSharp.HttpClient.NetStandard
{
    /// <summary>
    /// OneSignal client interface.
    /// </summary>
    public interface IOneSignalClient
    {
        /// <summary>
        /// Device resources.
        /// </summary>
        IDevicesResource Devices { get; }

        /// <summary>
        /// Notification resources.
        /// </summary>
        INotificationsResource Notifications { get; }
    }
}
