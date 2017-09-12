using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;


namespace QBankApi.Controller
{
    public class PropertysetsController : ControllerAbstract
    {
		public PropertysetsController(CachePolicy cachePolicy, string apiAddress, IAuthenticator authenticator) : base(cachePolicy, apiAddress, authenticator) { }

		public PropertysetsController(CachePolicy cachePolicy, RestClient client) : base(cachePolicy, client) { }

		/// <summary>
		/// Lists all PropertySets
		/// </summary>
		public List<PropertySet> ListPropertySets(
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/propertysets", Method.GET);
            request.Parameters.Clear();


            return Execute<List<PropertySet>>(request, cachePolicy);
        }

        /// <summary>
        /// Lists all PropertyTypes in QBank
        /// </summary>
        public List<PropertyType> ListPropertyTypes(
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/propertysets/propertytypes", Method.GET);
            request.Parameters.Clear();


            return Execute<List<PropertyType>>(request, cachePolicy);
        }
    }
}