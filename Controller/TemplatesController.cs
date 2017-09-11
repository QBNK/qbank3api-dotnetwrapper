using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;


namespace QBankApi.Controller
{
    public class TemplatesController : ControllerAbstract
    {
		public TemplatesController(CachePolicy cachePolicy, string apiAddress, IAuthenticator authenticator) : base(cachePolicy, apiAddress, authenticator) { }

		public TemplatesController(CachePolicy cachePolicy, RestClient client) : base(cachePolicy, client) { }

		/// <summary>
		/// List audio templates available.
		///
		/// List all non-deleted audio templates.
		/// </summary>
		public List<AudioTemplate> ListAudioTemplates(
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/templates/audio", Method.GET);
            request.Parameters.Clear();


            return Execute<List<AudioTemplate>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific AudioTemplate.
        ///
        /// Fetches a Audio Template by the specified identifier.
        /// <param name="id">The audio templates identifier..</param>
        /// </summary>
        public AudioTemplate RetrieveAudioTemplate(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/templates/audiotemplate", Method.GET);
            request.Parameters.Clear();


            return Execute<AudioTemplate>(request, cachePolicy);
        }

        /// <summary>
        /// Lists Image Templates available
        /// </summary>
        public List<ImageTemplate> ListImageTemplates(
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/templates/images", Method.GET);
            request.Parameters.Clear();


            return Execute<List<ImageTemplate>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific Image Template.
        ///
        /// Fetches a Image Template by the specified identifier.
        /// <param name="id">The Image Template identifier.</param>
        /// </summary>
        public ImageTemplate RetrieveImageTemplate(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/templates/images/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<ImageTemplate>(request, cachePolicy);
        }

        /// <summary>
        /// Lists Video Templates available
        /// </summary>
        public List<VideoTemplate> ListVideoTemplates(
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/templates/videos", Method.GET);
            request.Parameters.Clear();


            return Execute<List<VideoTemplate>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific Video Template.
        ///
        /// Fetches a Video Template by the specified identifier.
        /// <param name="id">The Video Template identifier.</param>
        /// </summary>
        public VideoTemplate RetrieveVideoTemplate(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/templates/videos/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<VideoTemplate>(request, cachePolicy);
        }
    }
}