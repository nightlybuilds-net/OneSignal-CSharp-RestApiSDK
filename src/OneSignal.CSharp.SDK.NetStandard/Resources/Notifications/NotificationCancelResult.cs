using Newtonsoft.Json;

namespace OneSignal.CSharp.SDK.NetStandard.Resources.Notifications
{
    /// <summary>
    /// Result of notification cancel operation.
    /// </summary>
    public class NotificationCancelResult
    {
        /// <summary>
        /// Returns whether the message was canceled or not
        /// {'success': "true"}
        /// </summary>
        [JsonProperty("success")]
        public string Success { get; set; }
    }
}
