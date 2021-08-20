using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OneSignal.CSharp.SDK.NetStandard.Serializers;
using RestSharp;

namespace OneSignal.CSharp.SDK.NetStandard.Resources.Notifications
{
    /// <summary>
    /// Class used to define resources needed for client to manage notifications.
    /// </summary>
    public class NotificationsResource : BaseResource, INotificationsResource
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="apiKey">Your OneSignal API key</param>
        /// <param name="apiUri">API uri (https://onesignal.com/api/v1/notifications)</param>
        public NotificationsResource(string apiKey, string apiUri) : base(apiKey, apiUri)
        {
        }

        /// <summary>
        /// Creates new notification to be sent by OneSignal system.
        /// </summary>
        /// <param name="options">Options used for notification create operation.</param>
        /// <returns></returns>
        public async Task<NotificationCreateResult> Create(NotificationCreateOptions options)
        {
            var content = new StringContent(JsonConvert.SerializeObject(options,Formatting.Indented,this.JsonSettings), Encoding.UTF8, "application/json");
            var response = await this.Client.PostAsync("notifications", content);

            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<NotificationCreateResult>(responseString);

            throw new Exception(responseString);
        }

        /// <summary>
        /// Get delivery and convert report about single notification.
        /// </summary>
        /// <param name="options">Options used for getting delivery and convert report about single notification.</param>
        /// <returns></returns>
        public async Task<NotificationViewResult> View(NotificationViewOptions options)
        {
            var response = await this.Client.GetAsync($"notifications/{options.Id}?app_id={options.AppId}");
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<NotificationViewResult>(responseString);

            throw new Exception(responseString);
        }

        /// <summary>
        /// Cancel a notification scheduled by the OneSignal system
        /// </summary>
        /// <param name="options">Options used for notification cancel operation.</param>
        /// <returns></returns>
        public async Task<NotificationCancelResult> Cancel(NotificationCancelOptions options)
        {
            var response = await this.Client.DeleteAsync($"notifications");
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<NotificationCancelResult>(responseString);

            throw new Exception(responseString);
        }
    }
}
