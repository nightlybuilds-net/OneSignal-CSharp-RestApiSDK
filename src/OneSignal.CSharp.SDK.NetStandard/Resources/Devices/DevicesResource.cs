using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OneSignal.CSharp.SDK.NetStandard.Resources.Notifications;
using OneSignal.CSharp.SDK.NetStandard.Serializers;
using RestSharp;

namespace OneSignal.CSharp.SDK.NetStandard.Resources.Devices
{
    /// <summary>
    /// Implementation of BaseResource, used to help client add or edit device.
    /// </summary>
    public class DevicesResource : BaseResource, IDevicesResource
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="apiKey">Your OneSignal API key</param>
        /// <param name="apiUri">API uri (https://onesignal.com/api/v1/notifications)</param>
        public DevicesResource(string apiKey, string apiUri) : base(apiKey, apiUri)
        {
        }

        /// <summary>
        /// Adds new device into OneSignal App.
        /// </summary>
        /// <param name="options">Here you can specify options used to add new device.</param>
        /// <returns>Result of device add operation.</returns>
        public async Task<DeviceAddResult> Add(DeviceAddOptions options)
        {
            var content = new StringContent(JsonConvert.SerializeObject(options), Encoding.UTF8, "application/json");
            var response = await this.Client.PostAsync("players", content);

            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<DeviceAddResult>(responseString);

            throw new Exception(responseString);
        }

        /// <summary>
        /// Edits existing device defined in OneSignal App.
        /// </summary>
        /// <param name="id">Id of the device</param>
        /// <param name="options">Options used to modify attributes of the device.</param>
        /// <exception cref="Exception"></exception>
        public async Task Edit(string id, DeviceEditOptions options)
        {
            var content = new StringContent(JsonConvert.SerializeObject(options), Encoding.UTF8, "application/json");
            var response = await this.Client.PutAsync($"players/{id}", content);

            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
             throw new Exception(responseString);
        }
    }
}
