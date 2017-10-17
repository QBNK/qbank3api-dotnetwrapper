using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;


namespace QBankApi.Controller
{
    public class EventsController : ControllerAbstract
    {
        public EventsController(CachePolicy cachePolicy, string apiAddress, IAuthenticator authenticator) : base(
            cachePolicy, apiAddress, authenticator)
        {
        }

        public EventsController(CachePolicy cachePolicy, RestClient client) : base(cachePolicy, client)
        {
        }

        /// <summary>
        /// Track a Media custom event
        /// <param name="sessionId">The session id to log the event on</param>
        /// <param name="mediaId">The ID of the media in the event</param>
        /// <param name="eventName">The event</param>
        /// </summary>
        public virtual object Custom(
            int sessionId, int mediaId, string eventName)
        {
            var request = new RestRequest($"v1/events/custom", Method.POST);
            request.Parameters.Clear();
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(sessionId),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(mediaId),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(eventName),
                ParameterType.RequestBody);

            return Execute<object>(request);
        }

        /// <summary>
        /// Track a Media download
        /// <param name="sessionId">The session id to log the download on</param>
        /// <param name="downloads">An array of DownloadItem (media & template) that was downloaded</param>
        /// </summary>
        public virtual object Download(
            int sessionId, List<DownloadItem> downloads)
        {
            var request = new RestRequest($"v1/events/download", Method.POST);
            request.Parameters.Clear();
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(sessionId),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(downloads),
                ParameterType.RequestBody);

            return Execute<object>(request);
        }

        /// <summary>
        /// Track a Search
        /// <param name="sessionId">The session id to log the search on</param>
        /// <param name="search">The Search that was made</param>
        /// <param name="hits">Number of hits for this search</param>
        /// </summary>
        public virtual object Search(
            int sessionId, Search search, int hits)
        {
            var request = new RestRequest($"v1/events/search", Method.POST);
            request.Parameters.Clear();
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(sessionId),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(search),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(hits),
                ParameterType.RequestBody);

            return Execute<object>(request);
        }

        /// <summary>
        /// Creates a sessionId
        ///
        /// SessionId must be sent along with all subsequent requests to track events.
        /// <param name="sourceId">the source we should log things on</param>
        /// <param name="sessionHash">Some sort of identifier for the user</param>
        /// <param name="remoteIp">Ip-address of the user</param>
        /// <param name="userAgent">the User Agent of the user</param>
        /// <param name="userId">Optional override value for the user id</param>
        /// </summary>
        public virtual object Session(
            int sourceId, string sessionHash, string remoteIp, string userAgent, int userId = 0)
        {
            var request = new RestRequest($"v1/events/session", Method.POST);
            request.Parameters.Clear();
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(sourceId),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(sessionHash),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(remoteIp),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(userAgent),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(userId),
                ParameterType.RequestBody);

            return Execute<object>(request);
        }

        /// <summary>
        /// Register a usage of a Media
        /// <param name="sessionId">The session id to log the event on</param>
        /// <param name="mediaUsage">The MediaUsage to register</param>
        /// </summary>
        public virtual MediaUsageResponse AddUsage(
            int sessionId, MediaUsage mediaUsage)
        {
            var request = new RestRequest($"v1/events/usage", Method.POST);
            request.Parameters.Clear();
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(sessionId),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(mediaUsage),
                ParameterType.RequestBody);

            return Execute<MediaUsageResponse>(request);
        }

        /// <summary>
        /// Track a Media view
        /// <param name="sessionId">The session id to log the view on</param>
        /// <param name="mediaId">The ID of the media that was viewed</param>
        /// </summary>
        public virtual object View(
            int sessionId, int mediaId)
        {
            var request = new RestRequest($"v1/events/view", Method.POST);
            request.Parameters.Clear();
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(sessionId),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(mediaId),
                ParameterType.RequestBody);

            return Execute<object>(request);
        }

        /// <summary>
        /// Unregister (remove) a Media usage
        /// <param name="id">The ID of the usage to remove.</param>
        /// </summary>
        public virtual MediaUsageResponse RemoveUsage(
            int id)
        {
            var request = new RestRequest($"v1/events/usage/{id}", Method.DELETE);
            request.Parameters.Clear();

            return Execute<MediaUsageResponse>(request);
        }
    }
}