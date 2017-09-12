using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;


namespace QBankApi.Controller
{
    public class SocialmediaController : ControllerAbstract
    {
        public SocialmediaController(CachePolicy cachePolicy, string apiAddress, IAuthenticator authenticator) : base(
            cachePolicy, apiAddress, authenticator)
        {
        }

        public SocialmediaController(CachePolicy cachePolicy, RestClient client) : base(cachePolicy, client)
        {
        }

        /// <summary>
        /// Fetches a specific SocialMedia site.
        /// <param name="id">The SocialMedia identifier..</param>
        /// </summary>
        public DeploymentSiteResponse RetrieveSocialMedia(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/socialmedia/site/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<DeploymentSiteResponse>(request, cachePolicy);
        }

        /// <summary>
        /// Lists all SocialMedia sites.
        /// </summary>
        public List<SocialMedia> ListSocialMedias(
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/socialmedia/sites", Method.GET);
            request.Parameters.Clear();


            return Execute<List<SocialMedia>>(request, cachePolicy);
        }
    }
}