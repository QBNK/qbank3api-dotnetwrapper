using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;

namespace QBankApi.Controller
{
    public class DeploymentController : ControllerAbstract
    {
        public DeploymentController(string apiAddress, IAuthenticator authenticator, CachePolicy cachePolicy,
            ref RestClient client) : base(cachePolicy, ref client)
        {
            if (!string.IsNullOrWhiteSpace(apiAddress))
            {
                Client = new RestClient(new Uri(apiAddress)) {Authenticator = authenticator};
            }
        }

        /// <summary>
        /// Lists all Protocols.
        /// </summary>
        public List<Protocol> ListProtocols(CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/deployment/protocols", Method.GET);
            request.Parameters.Clear();


            return Execute<List<Protocol>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific Protocol.
        /// <param name="id">The Protocol identifier..</param>
        /// </summary>
        public Protocol RetrieveProtocol(int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/deployment/protocols/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<Protocol>(request, cachePolicy);
        }

        /// <summary>
        /// Lists all DeploymentSites.
        ///
        /// Lists all DeploymentSites the current User has access to.
        /// </summary>
        public List<DeploymentSiteResponse> ListSites(CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/deployment/sites", Method.GET);
            request.Parameters.Clear();


            return Execute<List<DeploymentSiteResponse>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific DeploymentSite.
        /// <param name="id">The DeploymentSite identifier..</param>
        /// </summary>
        public DeploymentSiteResponse RetrieveSite(int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/deployment/sites/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<DeploymentSiteResponse>(request, cachePolicy);
        }

        /// <summary>
        /// Create a DeploymentSite.
        /// <param name="deploymentSite">A JSON encoded DeploymentSite to create</param>
        /// </summary>
        public DeploymentSiteResponse CreateSite(DeploymentSite deploymentSite)
        {
            var request = new RestRequest($"v1/deployment", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(deploymentSite),
                ParameterType.RequestBody);


            return Execute<DeploymentSiteResponse>(request);
        }

        /// <summary>
        /// Update a DeploymentSite.
        /// <param name="id">The DeploymentSite identifier.</param>
        /// <param name="deploymentSite">A JSON encoded DeploymentSite representing the updates</param>
        /// </summary>
        public DeploymentSiteResponse UpdateSite(int id, DeploymentSite deploymentSite)
        {
            var request = new RestRequest($"v1/deployment/{id}", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(deploymentSite),
                ParameterType.RequestBody);


            return Execute<DeploymentSiteResponse>(request);
        }

        /// <summary>
        /// Deploy Media to a DeploymentSite.
        ///
        /// Deploy Media to a DeploymentSite, this is an asynchronous method.
        /// <param name="id">DeploymentSite to deploy to.</param>
        /// <param name="mediaIds">An array of int values.</param>
        /// </summary>
        public Dictionary<string, object> AddMediaToDeploymentSite(int id, List<int> mediaIds)
        {
            var request = new RestRequest($"v1/deployment/{id}/media", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(mediaIds),
                ParameterType.RequestBody);


            return Execute<Dictionary<string, object>>(request);
        }

        /// <summary>
        /// Delete a DeploymentSite.
        ///
        /// You can not delete a DeploymentSite while there are still media deployed there!
        /// <param name="id">The DeploymentSite identifier.</param>
        /// </summary>
        public DeploymentSiteResponse RemoveSite(int id)
        {
            var request = new RestRequest($"v1/deployment/{id}", Method.DELETE);
            request.Parameters.Clear();


            return Execute<DeploymentSiteResponse>(request);
        }

        /// <summary>
        /// Undeploy Media from a DeploymentSite.
        ///
        /// Undeploy Media from a DeploymentSite, this is an asynchronous method.
        /// <param name="id">DeploymentSite to undeploy from.</param>
        /// <param name="mediaIds">A comma separated string of media ids we should undeploy.</param>
        /// </summary>
        public Dictionary<string, object> RemoveMediaFromDeploymentSite(int id, string mediaIds)
        {
            var request = new RestRequest($"v1/deployment/{id}/media", Method.DELETE);
            request.Parameters.Clear();
            request.AddParameter("mediaIds", mediaIds, ParameterType.QueryString);


            return Execute<Dictionary<string, object>>(request);
        }
    }
}