using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;

namespace QBankApi.Controller
{
    public class FoldersController : ControllerAbstract
    {
        public FoldersController(string apiAddress, IAuthenticator authenticator, CachePolicy cachePolicy,
            ref RestClient client) : base(cachePolicy, ref client)
        {
            if (!string.IsNullOrWhiteSpace(apiAddress))
            {
                Client = new RestClient(new Uri(apiAddress)) {Authenticator = authenticator};
            }
        }

        /// <summary>
        /// Lists all Folders.
        ///
        /// Lists all the Folders that the current user has access to.
        /// <param name="root">The identifier of a Folder to be treated as the root. Use zero for the absolute root. The root will not be included in the result..</param>
        /// <param name="depth">The depth for which to include existing subfolders. Use zero to exclude them all together..</param>
        /// <param name="includeProperties">Whether to return the properties for each folder..</param>
        /// <param name="includeObjectCounts">Whether to return the number of objects each folder contains..</param>
        /// </summary>
        public List<FolderResponse> ListFolders(int root = 0, int depth = 0, bool includeProperties = true,
            bool includeObjectCounts = false, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/folders", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("root", root, ParameterType.QueryString);
            request.AddParameter("depth", depth, ParameterType.QueryString);
            request.AddParameter("includeProperties", includeProperties, ParameterType.QueryString);
            request.AddParameter("includeObjectCounts", includeObjectCounts, ParameterType.QueryString);


            return Execute<List<FolderResponse>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific Folder.
        ///
        /// Fetches a Folder by the specified identifier.
        /// <param name="id">The Folder identifier..</param>
        /// <param name="depth">The depth for which to include existing subfolders. Use zero to exclude them all together..</param>
        /// <param name="includeProperties">Whether ti return the properties for each folder..</param>
        /// <param name="includeObjectCounts">Whether to return the number of objects each folder contains..</param>
        /// </summary>
        public FolderResponse RetrieveFolder(int id, int depth = 0, bool includeProperties = true,
            bool includeObjectCounts = false, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/folders/{id}", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("depth", depth, ParameterType.QueryString);
            request.AddParameter("includeProperties", includeProperties, ParameterType.QueryString);
            request.AddParameter("includeObjectCounts", includeObjectCounts, ParameterType.QueryString);


            return Execute<FolderResponse>(request, cachePolicy);
        }

        /// <summary>
        /// Lists all parent Folders until the absolute root.
        ///
        /// Lists all parent Folders from the specified to the absolute root, with distances.
        /// <param name="id">The Folder identifier.</param>
        /// </summary>
        public List<FolderParent> RetrieveParents(int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/folders/{id}/parents", Method.GET);
            request.Parameters.Clear();


            return Execute<List<FolderParent>>(request, cachePolicy);
        }

        /// <summary>
        /// Create a Folder.
        /// <param name="folder">A JSON encoded Folder to create</param>
        /// <param name="parentId">An optional parent folder ID. Will otherwise be created in the root level. Note that root level creation requires additional access!.</param>
        /// <param name="inheritAccess">Decides whether this Folder will inherit access from its parent folder</param>
        /// </summary>
        public FolderResponse CreateFolder(Folder folder, int parentId = 0, bool inheritAccess = false)
        {
            var request = new RestRequest($"v1/folders", Method.POST);
            request.Parameters.Clear();
            request.AddParameter("parentId", parentId, ParameterType.QueryString);

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(folder),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(inheritAccess),
                ParameterType.RequestBody);


            return Execute<FolderResponse>(request);
        }

        /// <summary>
        /// Add Media to Folder
        /// <param name="folderId">Folder to add media to.</param>
        /// <param name="mediaIds">An array of int values.</param>
        /// </summary>
        public Dictionary<string, object> AddMediaToFolder(int folderId, List<int> mediaIds)
        {
            var request = new RestRequest($"v1/folders/{folderId}/media", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(mediaIds),
                ParameterType.RequestBody);


            return Execute<Dictionary<string, object>>(request);
        }

        /// <summary>
        /// Update a Folder. Move a folder by updating the parent folder id.
        ///
        /// Update a Folder.
        /// <param name="id">The Folder identifier.</param>
        /// <param name="folder">A JSON encoded Folder representing the updates</param>
        /// </summary>
        public FolderResponse UpdateFolder(int id, Folder folder)
        {
            var request = new RestRequest($"v1/folders/{id}", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(folder),
                ParameterType.RequestBody);


            return Execute<FolderResponse>(request);
        }

        /// <summary>
        /// Remove Media from Folder
        /// <param name="folderId">Folder to remove media from.</param>
        /// <param name="mediaId">Media to remove from specified folder.</param>
        /// </summary>
        public Dictionary<string, object> RemoveMediaFromFolder(int folderId, int mediaId)
        {
            var request = new RestRequest($"v1/folders/{folderId}/media/{mediaId}", Method.DELETE);
            request.Parameters.Clear();


            return Execute<Dictionary<string, object>>(request);
        }

        /// <summary>
        /// Delete a Folder.
        ///
        /// Delete a Folder and all subfolders. Will NOT delete Media attached to the Folder.
        /// <param name="id">The Folder identifier.</param>
        /// </summary>
        public FolderResponse RemoveFolder(int id)
        {
            var request = new RestRequest($"v1/folders/{id}", Method.DELETE);
            request.Parameters.Clear();


            return Execute<FolderResponse>(request);
        }
    }
}