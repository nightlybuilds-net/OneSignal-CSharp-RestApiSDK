using Newtonsoft.Json;

namespace OneSignal.CSharp.SDK.NetStandard.Resources.Notifications
{
    /// <summary>
    /// Result of notification create operation.
    /// </summary>
    public class NotificationCreateResult
    {
        /// <summary>
        /// Returns the number of recepients who received the message.
        /// </summary>
        [JsonProperty("recipients")]
        public int Recipients { get; set; }

        /// <summary>
        /// Returns the id of the result.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
