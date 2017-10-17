using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using log4net;
using Newtonsoft.Json;
using QBankApi.Enums;
using QBankApi.Helpers;
using QBankApi.Model;
using RestSharp;
using RestSharp.Authenticators;

namespace QBankApi.Controller
{
    public abstract class ControllerAbstract
    {
        //Logger
        protected static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //Client
        public RestClient Client { get; protected set; }

        //CachePolicy
        protected CachePolicy CachePolicy { get; set; }

        //Delayed request
        protected bool Delayed { get; set; }

        internal List<DelayedRequest> DelayedRequests { get; set; }

        protected ControllerAbstract(CachePolicy cachePolicy, string apiAddress, IAuthenticator authenticator) : this(
            cachePolicy)
        {
            if (!string.IsNullOrWhiteSpace(apiAddress))
            {
                Client = new RestClient(new Uri(apiAddress))
                {
                    Authenticator = authenticator
                };
            }
        }

        protected ControllerAbstract(CachePolicy cachePolicy, RestClient client) : this(cachePolicy)
        {
            Client = client;
        }

        private ControllerAbstract(CachePolicy cachePolicy)
        {
            CachePolicy = cachePolicy;
        }

        /// <summary>
        ///     Performs a request to the QBank API.
        /// </summary>
        /// <typeparam name="T">The type of response</typeparam>
        /// <param name="request">The rest client request</param>
        /// <param name="parameters">The parameters to send</param>
        /// <param name="cachePolicy">The custom caching policy to use</param>
        /// <param name="delayed"> If the request should be delayed until destruction</param>
        /// <returns>The response result</returns>
        public T Execute<T>(RestRequest request, CachePolicy cachePolicy = null, bool delayed = false)
            where T : class, new()
        {
            if (Client == null)
            {
                return default(T);
            }

            if (cachePolicy == null)
            {
                cachePolicy = CachePolicy;
            }

            var parameters = string.Empty;
            if (request.Parameters.Any())
            {
                parameters = request.Parameters[0].ToString();
                if (!string.IsNullOrWhiteSpace(parameters))
                {
                    parameters = parameters.Replace("application/json=", string.Empty);
                }
            }

            if (Delayed)
            {
                DelayedRequests.Add(new DelayedRequest {Method = request.Method, Endpoint = request.Resource});
                Logger.Debug(
                    $"Request to QBank added to delayed queue [ 'endpoint': {request.Resource}, 'parameters' : {parameters}, 'method' : {request.Method} ]");
                return null;
            }

            Console.WriteLine($"{request.Resource}{parameters}{OAuth2Authenticator.Token?.AccessToken}");
            var md5Parameters =
                UtilHelper.GetMd5Hash($"{request.Resource}{parameters}{OAuth2Authenticator.Token?.AccessToken}");

            //If cachepolicy enabled return cached object if it exists
            if (cachePolicy.IsEnabled() &&
                (request.Method == Method.GET || request.Method == Method.POST &&
                 Regex.IsMatch("/v\\d+\\/search/", request.Resource)) &&
                CacheHelper.Exists(md5Parameters))
            {
                var cachedResponse = CacheHelper.Get<T>(md5Parameters);
                Logger.Info(
                    $"Using cached response. {request.Method} {request.Resource} [ 'endpoint': {request.Resource}, 'parameters' : {parameters}, 'method' : {request.Method}, 'response' : {StringHelper.SubString(JsonConvert.SerializeObject(cachedResponse), 4096)}  ]");
                return cachedResponse;
            }


            var dateTime = DateTime.UtcNow;
            var response = Client.Execute<T>(request);
            Logger.Debug(
                $"Request to QBank sent. {request.Method} {request.Resource} [ 'endpoint': {request.Resource}, 'parameters' : {parameters}, 'time' : 0.{Math.Round(((decimal) DateTime.UtcNow.Millisecond - (decimal) dateTime.Millisecond) * 1000)},'method' : {request.Method}, 'response' : {StringHelper.SubString(JsonConvert.SerializeObject(response), 4096)}  ]");

            if (response.ErrorException != null)
            {
                Logger.Error(
                    $"Error while receiving response from QBank. {request.Method} {request.Resource} [ 'message': 'Response not in json format.', 'endpoint': {request.Resource}, 'parameters' : {parameters}, 'method' : {request.Method}, 'response' : {StringHelper.SubString(JsonConvert.SerializeObject(response), 4096)} ]");
                const string message = "Error while receiving response from QBank.  Check inner details for more info.";
                var qbankException = new ApplicationException(message, response.ErrorException);
                throw qbankException;
            }

            //If caching enabled store object
            if (cachePolicy.IsEnabled() &&
                cachePolicy.Type == CacheType.Everything &&
                (request.Method == Method.GET || request.Method == Method.POST &&
                 Regex.IsMatch("/v\\d+\\/search/", request.Resource)))
            {
                CacheHelper.Add(response.Data, md5Parameters, cachePolicy.Lifetime);
            }

            return response.Data;
        }

        protected OAuth2Authenticator OAuth2Authenticator => Client?.Authenticator as OAuth2Authenticator;
    }
}