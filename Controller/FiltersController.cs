using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;


namespace QBankApi.Controller
{
    public class FiltersController : ControllerAbstract
    {
        public FiltersController(CachePolicy cachePolicy, string apiAddress, IAuthenticator authenticator) : base(
            cachePolicy, apiAddress, authenticator)
        {
        }

        public FiltersController(CachePolicy cachePolicy, RestClient client) : base(cachePolicy, client)
        {
        }

        /// <summary>
        /// Returns a array of FilterItem for the chosen categories
        ///
        /// , optionally filtered by specific DeploymentSites.
        /// <param name="categoryIds">Comma separated string categoryIds we should fetch mediaIds for.</param>
        /// <param name="deploymentSiteIds">Comma separated string of deploymentSiteIds we should fetch mediaIds for.</param>
        /// <param name="ignoreGrouping">Whether to include grouped media or not.</param>
        /// </summary>
        public virtual List<FilterItem> Categories(
            string categoryIds, string deploymentSiteIds = null, bool ignoreGrouping = false,
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/filters/categories/{categoryIds}", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("deploymentSiteIds", deploymentSiteIds, ParameterType.QueryString);
            request.AddParameter("ignoreGrouping", ignoreGrouping, ParameterType.QueryString);

            return Execute<List<FilterItem>>(request, cachePolicy);
        }

        /// <summary>
        /// Returns a array of FilterItem for the chosen folder subfolders
        ///
        /// , optionally filtered by specific CategoryIds and/or DeploymentSites.
        /// <param name="parentFolderId">The folder id..</param>
        /// <param name="categoryIds">Comma separated string categoryIds we should fetch mediaIds for.</param>
        /// <param name="deploymentSiteIds">Comma separated string of deploymentSiteIds we should fetch mediaIds for.</param>
        /// <param name="ignoreGrouping">Whether to include grouped media or not.</param>
        /// </summary>
        public virtual List<FilterItem> Folder(
            int parentFolderId, string categoryIds = null, string deploymentSiteIds = null, bool ignoreGrouping = false,
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/filters/folder/{parentFolderId}", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("categoryIds", categoryIds, ParameterType.QueryString);
            request.AddParameter("deploymentSiteIds", deploymentSiteIds, ParameterType.QueryString);
            request.AddParameter("ignoreGrouping", ignoreGrouping, ParameterType.QueryString);

            return Execute<List<FilterItem>>(request, cachePolicy);
        }

        /// <summary>
        /// Returns a array of FilterItem for a specific freetext
        ///
        /// , optionally filtered by DeploymentSites.
        /// <param name="freetext">String to filter by.</param>
        /// <param name="deploymentSiteIds">Comma separated string of deploymentSiteIds we should fetch mediaIds for.</param>
        /// <param name="mode">The method (AND|OR) to filter words by.</param>
        /// <param name="ignoreGrouping">Whether to include grouped media or not.</param>
        /// </summary>
        public virtual List<FilterItem> Freetext(
            string freetext, string deploymentSiteIds = null, string mode = "OR", bool ignoreGrouping = false,
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/filters/freetext/{freetext}", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("deploymentSiteIds", deploymentSiteIds, ParameterType.QueryString);
            request.AddParameter("mode", mode, ParameterType.QueryString);
            request.AddParameter("ignoreGrouping", ignoreGrouping, ParameterType.QueryString);

            return Execute<List<FilterItem>>(request, cachePolicy);
        }

        /// <summary>
        /// Returns a array of FilterItem for the chosen property
        ///
        /// , optionally filtered by specific CategoryIds and/or DeploymentSites.
        /// <param name="systemName">System name of property to filter by.</param>
        /// <param name="preloadNames">If item names should be preloaded from property type.</param>
        /// <param name="categoryIds">Comma separated string categoryIds we should fetch mediaIds for.</param>
        /// <param name="deploymentSiteIds">Comma separated string of deploymentSiteIds we should fetch mediaIds for.</param>
        /// <param name="isHierarchical">Whether to include grouped media or not.</param>
        /// <param name="ignoreGrouping"></param>
        /// </summary>
        public virtual List<FilterItem> Property(
            string systemName, bool preloadNames = false, string categoryIds = null, string deploymentSiteIds = null,
            bool isHierarchical = false, bool ignoreGrouping = false, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/filters/property/{systemName}", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("preloadNames", preloadNames, ParameterType.QueryString);
            request.AddParameter("categoryIds", categoryIds, ParameterType.QueryString);
            request.AddParameter("deploymentSiteIds", deploymentSiteIds, ParameterType.QueryString);
            request.AddParameter("isHierarchical", isHierarchical, ParameterType.QueryString);
            request.AddParameter("ignoreGrouping", ignoreGrouping, ParameterType.QueryString);

            return Execute<List<FilterItem>>(request, cachePolicy);
        }
    }
}