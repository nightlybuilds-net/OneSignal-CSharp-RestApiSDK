using System;
using System.Net.Http;
using HttpTracer;
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
            this.Client = new HttpClient(new HttpTracerHandler())
            {
                BaseAddress = new Uri(apiUri)
            };
            this.Client.DefaultRequestHeaders.Add("Authorization",$"Basic {apiKey}");
        }


        protected JsonSerializerSettings JsonSettings => new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Include
        };
    }
}
