using Newtonsoft.Json;

namespace OneSignal.CSharp.HttpClient.NetStandard.Resources.Devices
{
    /// <summary>
    /// Class used to keep result of device add operation.
    /// </summary>
    public class DeviceAddResult
    {
        /// <summary>
        /// Returns true if operation is successfull.
        /// </summary>
        [JsonProperty("success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Returns id of the result operation.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
