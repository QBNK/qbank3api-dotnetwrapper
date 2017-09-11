using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;


namespace QBankApi.Controller
{
    public class SearchController : ControllerAbstract
    {
        public SearchController(string apiAddress, IAuthenticator authenticator, CachePolicy cachePolicy,
            ref RestClient client) : base(cachePolicy, ref client)
        {
            if (!string.IsNullOrWhiteSpace(apiAddress))
            {
                Client = new RestClient(new Uri(apiAddress)) {Authenticator = authenticator};
            }
        }

        /// <summary>
        ///
        /// </summary>
        public object Metadata(
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/search/metadata", Method.GET);
            request.Parameters.Clear();


            return Execute<object>(request, cachePolicy);
        }

        /// <summary>
        /// Search for Media
        ///
        /// in QBank
        /// <param name="search">Search parameters</param>
        /// <param name="returnType">Whether to return object, mediaIds.</param>
        /// </summary>
        public SearchResult Search(
            Search search, int returnType = 1, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/search", Method.POST);
            request.Parameters.Clear();
            request.AddParameter("returnType", returnType, ParameterType.QueryString);

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(search),
                ParameterType.RequestBody);


            return Execute<SearchResult>(request, cachePolicy);
        }

        /// <summary>
        /// Get total hit count for media search
        ///
        /// in QBank
        /// <param name="search">Search parameters</param>
        /// </summary>
        public object Searchtotal(
            Search search)
        {
            var request = new RestRequest($"v1/search/total", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(search),
                ParameterType.RequestBody);


            return Execute<object>(request);
        }
    }
}