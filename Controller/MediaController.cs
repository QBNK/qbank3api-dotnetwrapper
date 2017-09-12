using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;
using System.IO;


namespace QBankApi.Controller
{
    public class MediaController : ControllerAbstract
    {
		public MediaController(CachePolicy cachePolicy, string apiAddress, IAuthenticator authenticator) : base(cachePolicy, apiAddress, authenticator) { }

		public MediaController(CachePolicy cachePolicy, RestClient client) : base(cachePolicy, client) { }

		/// <summary>
		/// Fetches a specific Media.
		/// <param name="id">The Media identifier.</param>
		/// </summary>
		public MediaResponse RetrieveMedia(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<MediaResponse>(request, cachePolicy);
        }

        /// <summary>
        /// Gets the raw file data of a Media.
        ///
        /// You may append an optional template parameter to the query. Omitting the template parameter will return the medium thumbnail.
        ///
        ///  Existing templates are:
        ///  <b>original</b> - The original file
        ///  <b>preview</b> - A preview image, sized 1000px on the long side
        ///  <b>thumb_small</b> - A thumbnail image, sized 100px on the long side
        ///  <b>thumb_medium</b> - A thumbnail image, sized 200px on the long side
        ///  <b>thumb_large</b> - A thumbnail image, sized 300px on the long side
        ///  <b>videopreview</b> - A preview video, sized 360p and maximum 2min
        ///  <b>{integer}</b> - An image template identifier (NOTE: You can only request templates that are available on the server, eg. a media that have been published using COPY or SYMLINK-protocols)
        /// <param name="writer">Stream to write file to</param>
        /// <param name="id">The Media identifier..</param>
        /// <param name="template">Optional template of Media..</param>
        /// </summary>
        public void RetrieveFileData(
            Stream writer, int id, string template = null, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/{id}/asset");
            request.AddParameter("template", template, ParameterType.QueryString);

            request.ResponseWriter = (responseStream) => responseStream.CopyTo(writer);
            Client.DownloadData(request);
        }

        /// <summary>
        /// Fetches all DeployedFiles a Media has.
        /// <param name="id">The Media identifier..</param>
        /// <param name="media">[DEPRECATED] Internal use only.</param>
        /// </summary>
        public List<DeploymentFile> ListDeployedFiles(
            int id, Media media = null, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/{id}/deployment/files", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("media", media, ParameterType.QueryString);


            return Execute<List<DeploymentFile>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches all DeploymentSites a Media is deployed to.
        /// <param name="id">The Media identifier..</param>
        /// </summary>
        public List<DeploymentSiteResponse> ListDeploymentSites(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/{id}/deployment/sites", Method.GET);
            request.Parameters.Clear();


            return Execute<List<DeploymentSiteResponse>>(request, cachePolicy);
        }

        /// <summary>
        /// Downloads a specific Media.
        ///
        /// You may append an optional template parameter to the query. Omitting the template parameter will return the original file.
        /// <param name="writer">Stream to write file to</param>
        /// <param name="id">The Media identifier.</param>
        /// <param name="template">Optional template to download the media in (NOTE: This should not be used for fetching images often, use very sparingly and consider using publish-sites and templates instead).</param>
        /// <param name="templateType">Indicates type of template, valid values are; image, video.</param>
        /// </summary>
        public void Download(
            Stream writer, int id, string template = null, string templateType = "image",
            CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/{id}/download");
            request.AddParameter("template", template, ParameterType.QueryString);
            request.AddParameter("templateType", templateType, ParameterType.QueryString);

            request.ResponseWriter = (responseStream) => responseStream.CopyTo(writer);
            Client.DownloadData(request);
        }

        /// <summary>
        /// Fetches all Folders a Media resides in.
        /// <param name="id">The Media identifier..</param>
        /// <param name="depth">The depth for which to include existing subfolders. Use zero to exclude them all toghether..</param>
        /// </summary>
        public List<FolderResponse> ListFolders(
            int id, int depth = 0, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/{id}/folders", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("depth", depth, ParameterType.QueryString);


            return Execute<List<FolderResponse>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches all Moodboards a Media is a member of.
        /// <param name="id">The Media identifier..</param>
        /// </summary>
        public List<MoodboardResponse> ListMoodboards(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/{id}/moodboards", Method.GET);
            request.Parameters.Clear();


            return Execute<List<MoodboardResponse>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches all links to SocialMedia that a Media has.
        ///
        /// Fetches all DeployedFiles a Media has.
        /// <param name="id">The Media identifier..</param>
        /// </summary>
        public List<DeploymentFile> ListSocialMediaFiles(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/{id}/socialmedia/files", Method.GET);
            request.Parameters.Clear();


            return Execute<List<DeploymentFile>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches all SocialMedia sites a Media is published to.
        /// <param name="id">The Media identifier..</param>
        /// </summary>
        public List<SocialMedia> ListSocialMedia(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/{id}/socialmedia/sites", Method.GET);
            request.Parameters.Clear();


            return Execute<List<SocialMedia>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches all External Usages for a Media.
        /// <param name="id">The Media identifier..</param>
        /// </summary>
        public List<MediaUsageResponse> ListUsages(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/{id}/usages", Method.GET);
            request.Parameters.Clear();


            return Execute<List<MediaUsageResponse>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches the version list of a media.
        ///
        /// The id may be of any media version in the list; first, somewhere in between or last.
        /// <param name="id">The Media identifier..</param>
        /// </summary>
        public List<MediaVersion> ListVersions(
            int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/{id}/versions", Method.GET);
            request.Parameters.Clear();


            return Execute<List<MediaVersion>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches eventual comments made on this media
        /// <param name="mediaId">The Media identifier..</param>
        /// </summary>
        public List<CommentResponse> ListComments(
            int mediaId, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/{mediaId}/comments", Method.GET);
            request.Parameters.Clear();


            return Execute<List<CommentResponse>>(request, cachePolicy);
        }

        /// <summary>
        /// Downloads an archive of several Media
        ///
        /// . You may append an optional template parameter to the query. Omitting the template parameter will return the original files.
        /// <param name="writer">Stream to write file to</param>
        /// <param name="ids">Array of Media ID:s to download.</param>
        /// <param name="template">Optional template to download all Media in..</param>
        /// </summary>
        public void DownloadArchive(
            Stream writer, List<int> ids, string template = null, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/download");
            request.AddParameter("ids", ids, ParameterType.QueryString);
            request.AddParameter("template", template, ParameterType.QueryString);

            request.ResponseWriter = (responseStream) => responseStream.CopyTo(writer);
            Client.DownloadData(request);
        }

        /// <summary>
        /// Publishes an archive of several Media.
        ///
        /// Publishes an archive of several Media to a deploymentssite by supplying either a list of mediaIds or objectIds and a deployment site id.
        /// <param name="idType">Type of ID, Object or Media, sending ObjectId will automatically use the latest version of a Object..</param>
        /// <param name="ids">A comma-separated list of IDs to zip and publish.</param>
        /// <param name="deploymentSiteId">The site to publish the archive to.</param>
        /// <param name="filename">Optional filename for the zip-archive, a filename will automatically be generated if omitted..</param>
        /// </summary>
        public object PublishArchive(
            string idType, string ids, int deploymentSiteId, string filename = null, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/media/publishArchive", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("idType", idType, ParameterType.QueryString);
            request.AddParameter("ids", ids, ParameterType.QueryString);
            request.AddParameter("deploymentSiteId", deploymentSiteId, ParameterType.QueryString);
            request.AddParameter("filename", filename, ParameterType.QueryString);


            return Execute<object>(request, cachePolicy);
        }

        /// <summary>
        /// Upload a new media to QBank
        ///
        /// This upload endpoint has been specifically tailored to fit chunked uploading (works well with Plupload2 for example). Max chunk size is about 10mb, if your files are larger than this, split it up and set correct chunk and chunks argument in the call.
        ///  For example a 26mb file might be split in 3 chunks, so the following 3 calls should be made
        ///  POST /media.json?chunks=3&chunk=0&filename=largefile.txt&categoryId=1 (file data is sent in body)
        ///  POST /media.json?chunks=3&chunk=1&filename=largefile.txt&categoryId=1&fileId=<fileId from first call> (file data is sent in body)
        ///  POST /media.json?chunks=3&chunk=2&filename=largefile.txt&categoryId=1&fileId=<fileId from first call> (file data is sent in body)
        ///
        /// <param name="name">Filename of the file being uploaded</param>
        /// <param name="chunk">The chunk we are currently uploading, starts at 0</param>
        /// <param name="chunks">Number of chunks you will be uploading, when (chunk - 1) == chunks the file will be considered uploaded</param>
        /// <param name="fileId">A unique fileId that will be used for this upload, if none is given one will be given to you</param>
        /// <param name="categoryId">The category to place the file in</param>
        /// </summary>
        public Dictionary<string, object> UploadFileChunked(
            string name, int chunk, int chunks, string fileId, int categoryId)
        {
            var request = new RestRequest($"v1/media", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(name),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(chunk),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(chunks),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(fileId),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(categoryId),
                ParameterType.RequestBody);


            return Execute<Dictionary<string, object>>(request);
        }

        /// <summary>
        /// Update a specific Media.
        ///
        /// Note that type_id cannot be set directly, but must be decided by the category. The properties parameter of the media
        /// <param name="id">The Media identifier.</param>
        /// <param name="media">A JSON encoded Media representing the updates</param>
        /// </summary>
        public MediaResponse UpdateMedia(
            int id, Media media)
        {
            var request = new RestRequest($"v1/media/{id}", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(media),
                ParameterType.RequestBody);


            return Execute<MediaResponse>(request);
        }

        /// <summary>
        /// Groups one "main" Media with one or more "child" Media.
        ///
        /// The main medium will by default be the only medium shown when searching, child media can be fetched by issuing a search with parentId set to the main medium id.
        /// <param name="id">The Media identifier.</param>
        /// <param name="children">An array of int values.</param>
        /// </summary>
        public object Group(
            int id, List<int> children)
        {
            var request = new RestRequest($"v1/media/{id}/group", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(children),
                ParameterType.RequestBody);


            return Execute<object>(request);
        }

        /// <summary>
        /// Restore a deleted Media.
        ///
        /// Can not restore a Media that has been hard deleted!
        /// <param name="id">The Media identifier.</param>
        /// </summary>
        public MediaResponse RestoreMedia(
            int id)
        {
            var request = new RestRequest($"v1/media/{id}/restore", Method.POST);
            request.Parameters.Clear();


            return Execute<MediaResponse>(request);
        }

        /// <summary>
        /// Change status of a Media.
        ///
        /// This is used to move media from the uploaded tab into the library.
        ///  Possible statuses are: <ul> <li>approved</li> </ul>
        ///
        /// <param name="id">The Media identifier.</param>
        /// <param name="status">The new status of the media</param>
        /// </summary>
        public Dictionary<string, object> SetStatus(
            int id, string status)
        {
            var request = new RestRequest($"v1/media/{id}/status", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(status),
                ParameterType.RequestBody);


            return Execute<Dictionary<string, object>>(request);
        }

        /// <summary>
        /// Upload a new preview for a media.
        ///
        /// Replaces the current preview thumbnails for a media with the supplied one. Recommended image size is minimum 1000px on the longest side. If a PDF is uploaded it will be added as a preview document. This enables users to browse documents directly from within QBank. The maximum recommended file size is 10MB.
        /// <param name="id"></param>
        /// </summary>
        public object UploadPreview(
            int id)
        {
            var request = new RestRequest($"v1/media/{id}/uploadpreview", Method.POST);
            request.Parameters.Clear();


            return Execute<object>(request);
        }

        /// <summary>
        /// Upload a new version of a media
        ///
        /// This upload endpoint has been specifically tailored to fit chunked uploading (works well with Plupload2 for example). Max chunk size is about 10mb, if your files are larger than this, split it up and set correct chunk and chunks argument in the call.
        ///  For example a 26mb file might be split in 3 chunks, so the following 3 calls should be made
        ///  POST /media.json?chunks=3&chunk=0&filename=largefile.txt&categoryId=1 (file data is sent in body)
        ///  POST /media.json?chunks=3&chunk=1&filename=largefile.txt&categoryId=1&fileId=<fileId from first call> (file data is sent in body)
        ///  POST /media.json?chunks=3&chunk=2&filename=largefile.txt&categoryId=1&fileId=<fileId from first call> (file data is sent in body)
        ///
        /// <param name="id">The Media identifier.</param>
        /// <param name="revisionComment">The revision comment</param>
        /// <param name="name">Filename of the file being uploaded</param>
        /// <param name="chunk">The chunk we are currently uploading, starts at 0</param>
        /// <param name="chunks">Number of chunks you will be uploading, when (chunk - 1) == chunks the file will be considered uploaded</param>
        /// <param name="fileId">A unique fileId that will be used for this upload, if none is given one will be given to you</param>
        /// </summary>
        public Dictionary<string, object> UploadNewVersionChunked(
            int id, string revisionComment, string name, int chunk, int chunks, string fileId)
        {
            var request = new RestRequest($"v1/media/{id}/version", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(revisionComment),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(name),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(chunk),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(chunks),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(fileId),
                ParameterType.RequestBody);


            return Execute<Dictionary<string, object>>(request);
        }

        /// <summary>
        /// Post a comment on a media
        ///
        /// , leave username and useremail empty to post as the user that is logged on to the API.
        /// <param name="mediaId">the media to post the comment on.</param>
        /// <param name="comment">The comment to post</param>
        /// </summary>
        public CommentResponse CreateComment(
            int mediaId, Comment comment)
        {
            var request = new RestRequest($"v1/media/{mediaId}/comments", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(comment),
                ParameterType.RequestBody);


            return Execute<CommentResponse>(request);
        }

        /// <summary>
        /// Combines slides
        ///
        /// Combines several slides into one presentation.
        /// <param name="structure">An array of QBNK\QBank\Api\v1\Model\Slides\SlideStructure values.</param>
        /// </summary>
        public object CombineSlides(
            List<SlideStructure> structure)
        {
            var request = new RestRequest($"v1/media/slides/combine", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(structure),
                ParameterType.RequestBody);


            return Execute<object>(request);
        }

        /// <summary>
        /// Update some properties for a Media.
        ///
        /// Update the provided properties for the specified Media. Will not update any other properties then those provided. It is preferable to use this method over updating a whole media to change a few properties as the side effects are fewer.
        /// <param name="id">The Media identifier.</param>
        /// <param name="properties">An array of QBNK\QBank\Api\v1\Model\Property values.</param>
        /// </summary>
        public Dictionary<string, object> UpdateProperties(
            int id, List<Property> properties)
        {
            var request = new RestRequest($"v1/media/{id}/properties", Method.PUT);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(properties),
                ParameterType.RequestBody);


            return Execute<Dictionary<string, object>>(request);
        }

        /// <summary>
        /// Delete a Media.
        ///
        /// Deleting a Media will set it's status to removed but will retain all data and enable restoration of the Media, much like the trash bin of your operating system. To permanetly remove a Media, use the "hardDelete" flag.
        /// <param name="id">The Media identifier.</param>
        /// <param name="hardDelete">Prevent restoration of the Media..</param>
        /// </summary>
        public MediaResponse RemoveMedia(
            int id, bool hardDelete = false)
        {
            var request = new RestRequest($"v1/media/{id}", Method.DELETE);
            request.Parameters.Clear();
            request.AddParameter("hardDelete", hardDelete, ParameterType.QueryString);


            return Execute<MediaResponse>(request);
        }

        /// <summary>
        /// Delete a comment
        ///
        /// on a media
        /// <param name="mediaId">the media to delete the comment from.</param>
        /// <param name="commentId">the comment to delete.</param>
        /// </summary>
        public Comment RemoveComment(
            int mediaId, int commentId)
        {
            var request = new RestRequest($"v1/media/{mediaId}/comments/{commentId}", Method.DELETE);
            request.Parameters.Clear();


            return Execute<Comment>(request);
        }
    }
}