using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;


namespace QBankApi.Controller
{
    public class ObjecttypesController : ControllerAbstract
    {
		public ObjecttypesController(CachePolicy cachePolicy, string apiAddress, IAuthenticator authenticator) : base(cachePolicy, apiAddress, authenticator) { }

		public ObjecttypesController(CachePolicy cachePolicy, RestClient client) : base(cachePolicy, client) { }

		/// <summary>
		/// Lists all Object Types
		/// </summary>
		public List<ObjectType> ListObjectTypes(
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/objecttypes", Method.GET);
            request.Parameters.Clear();


            return Execute<List<ObjectType>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific ObjectType.
        ///
        /// Fetches an ObjectType by the specified identifier.
        /// <param name="id">The ObjectType identifier.</param>
        /// </summary>
        public ObjectType RetrieveObjectType(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/objecttypes/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<ObjectType>(request, cachePolicy);
        }
    }
}