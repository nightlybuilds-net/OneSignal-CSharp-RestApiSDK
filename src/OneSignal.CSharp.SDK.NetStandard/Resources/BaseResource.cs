using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OneSignal.CSharp.SDK.NetStandard.Resources
{
    /// <summary>
    /// Abstract class which helps easier implementation of new client resources.
    /// </summary>
    public abstract class BaseResource
    {
        /// <summary>
        /// Rest client reference.
        /// </summary>
        protected HttpClient Client { get; }

        /// <summary>
        /// Your OneSignal Api key.
        /// </summary>
        protected string ApiKey { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="apiKey">Your OneSignal API key</param>
        /// <param name="apiUri">API uri (https://onesignal.com/api/v1/notifications)</param>
        protected BaseResource(string apiKey, string apiUri)
        {
            ApiKey = apiKey;
            this.Client = new HttpClient
            {
                BaseAddress = new Uri(apiUri)
            };
            this.Client.DefaultRequestHeaders.Add("Authorization",$"Basic {apiKey}");
        }
        
        
        protected async Task<T> InnerCall<T>(object options)
        {
            var content = new StringContent(JsonConvert.SerializeObject(options), Encoding.UTF8, "application/json");
            var response = await this.Client.PostAsync("notifications", content);

            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<T>(responseString);

            throw new Exception(responseString);
        }
    }
}
