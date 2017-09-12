using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;


namespace QBankApi.Controller
{
    public class MoodboardsController : ControllerAbstract
    {
		public MoodboardsController(CachePolicy cachePolicy, string apiAddress, IAuthenticator authenticator) : base(cachePolicy, apiAddress, authenticator) { }

		public MoodboardsController(CachePolicy cachePolicy, RestClient client) : base(cachePolicy, client) { }

		/// <summary>
		/// Lists all Moodboards
		///
		/// that the current user has access to.
		/// </summary>
		public List<MoodboardResponse> ListMoodboards(
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/moodboards", Method.GET);
            request.Parameters.Clear();


            return Execute<List<MoodboardResponse>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific Moodboard.
        ///
        /// Fetches a Moodboard by the specified identifier.
        /// <param name="id">The Moodboard identifier.</param>
        /// </summary>
        public MoodboardResponse RetrieveMoodboard(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/moodboards/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<MoodboardResponse>(request, cachePolicy);
        }

        /// <summary>
        /// Lists all Moodboard templates.
        ///
        /// Lists all Moodboard templates that the user has access to.
        /// </summary>
        public List<MoodboardTemplateResponse> ListTemplates(
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/moodboards/templates", Method.GET);
            request.Parameters.Clear();


            return Execute<List<MoodboardTemplateResponse>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific Moodboard template.
        ///
        /// Fetches a specific Moodboard template by id.
        /// <param name="templateId"></param>
        /// </summary>
        public MoodboardTemplateResponse RetrieveTemplate(
            int templateId, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/moodboards/templates/{templateId}", Method.GET);
            request.Parameters.Clear();


            return Execute<MoodboardTemplateResponse>(request, cachePolicy);
        }

        /// <summary>
        /// Create a moodboard.
        ///
        /// Create a Moodboard
        /// <param name="moodboard">A JSON encoded Moodboard to create</param>
        /// </summary>
        public MoodboardResponse CreateMoodboard(
            Moodboard moodboard)
        {
            var request = new RestRequest($"v1/moodboards", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(moodboard),
                ParameterType.RequestBody);


            return Execute<MoodboardResponse>(request);
        }

        /// <summary>
        /// Update a moodboard.
        ///
        /// Update a Moodboard.
        /// <param name="id">The Moodboard identifier.</param>
        /// <param name="moodboard">A JSON encoded Moodboard representing the updates</param>
        /// </summary>
        public MoodboardResponse UpdateMoodboard(
            int id, Moodboard moodboard)
        {
            var request = new RestRequest($"v1/moodboards/{id}", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(moodboard),
                ParameterType.RequestBody);


            return Execute<MoodboardResponse>(request);
        }

        /// <summary>
        /// Add Media to a Moodboard
        /// <param name="moodboardId">Moodboard ID to add media to.</param>
        /// <param name="mediaIds">An array of int values.</param>
        /// </summary>
        public Dictionary<string, object> AddMediaToMoodboard(
            int moodboardId, List<int> mediaIds)
        {
            var request = new RestRequest($"v1/moodboards/{moodboardId}/media", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(mediaIds),
                ParameterType.RequestBody);


            return Execute<Dictionary<string, object>>(request);
        }

        /// <summary>
        /// Delete a Moodboard.
        ///
        /// Will NOT delete Media attached to the Moodboard.
        /// <param name="id">The Moodboard identifier.</param>
        /// </summary>
        public MoodboardResponse RemoveMoodboard(
            int id)
        {
            var request = new RestRequest($"v1/moodboards/{id}", Method.DELETE);
            request.Parameters.Clear();


            return Execute<MoodboardResponse>(request);
        }

        /// <summary>
        /// Remove Media from a Moodboard
        /// <param name="moodboardId">Moodboard ID to remove media from.</param>
        /// <param name="mediaId">Media ID to remove from specified folder.</param>
        /// </summary>
        public Dictionary<string, object> RemoveMediaFromMoodboard(
            int moodboardId, int mediaId)
        {
            var request = new RestRequest($"v1/moodboards/{moodboardId}/media/{mediaId}", Method.DELETE);
            request.Parameters.Clear();


            return Execute<Dictionary<string, object>>(request);
        }
    }
}