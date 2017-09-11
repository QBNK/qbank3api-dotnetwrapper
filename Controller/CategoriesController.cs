using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;


namespace QBankApi.Controller
{
    public class CategoriesController : ControllerAbstract
    {
        public CategoriesController(string apiAddress, IAuthenticator authenticator, CachePolicy cachePolicy,
            ref RestClient client) : base(cachePolicy, ref client)
        {
            if (!string.IsNullOrWhiteSpace(apiAddress))
            {
                Client = new RestClient(new Uri(apiAddress)) {Authenticator = authenticator};
            }
        }

        /// <summary>
        /// Lists all Categories
        ///
        /// Lists all categories that the current user has access to.
        /// </summary>
        public List<CategoryResponse> ListCategories(
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/categories", Method.GET);
            request.Parameters.Clear();


            return Execute<List<CategoryResponse>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific Category.
        ///
        /// Fetches a Category by the specified identifier.
        /// <param name="id">The Category identifier.</param>
        /// </summary>
        public CategoryResponse RetrieveCategory(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/categories/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<CategoryResponse>(request, cachePolicy);
        }

        /// <summary>
        /// Create a Category.
        /// <param name="category">A JSON encoded Category to create</param>
        /// </summary>
        public CategoryResponse CreateCategory(
            Category category)
        {
            var request = new RestRequest($"v1/categories", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(category),
                ParameterType.RequestBody);


            return Execute<CategoryResponse>(request);
        }

        /// <summary>
        /// Update a Category.
        /// <param name="id">The Category identifier.</param>
        /// <param name="category">A JSON encoded Category representing the updates</param>
        /// </summary>
        public CategoryResponse UpdateCategory(
            int id, Category category)
        {
            var request = new RestRequest($"v1/categories/{id}", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(category),
                ParameterType.RequestBody);


            return Execute<CategoryResponse>(request);
        }

        /// <summary>
        /// Delete a Category.
        ///
        /// You can not delete a category that has Media attached to it.
        /// <param name="id">The Category identifier.</param>
        /// </summary>
        public CategoryResponse RemoveCategory(
            int id)
        {
            var request = new RestRequest($"v1/categories/{id}", Method.DELETE);
            request.Parameters.Clear();


            return Execute<CategoryResponse>(request);
        }
    }
}