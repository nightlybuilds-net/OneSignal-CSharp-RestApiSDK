using OneSignal.CSharp.SDK.NetStandard.Resources.Devices;
using OneSignal.CSharp.SDK.NetStandard.Resources.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneSignal.CSharp.SDK.NetStandard
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
