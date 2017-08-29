using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QBankApi.Model;
using QBankApi.Serializers;
using RestSharp;
using RestSharp.Authenticators;

namespace QBankApi.Controller
{
    public class AccountsController : ControllerAbstract
    {
        public AccountsController(string apiAddress, IAuthenticator authenticator, CachePolicy cachePolicy,
            ref RestClient client) : base(cachePolicy, ref client)
        {
            if (!string.IsNullOrWhiteSpace(apiAddress))
            {
                Client = new RestClient(new Uri(apiAddress)) {Authenticator = authenticator};
            }
        }

        /// <summary>
        /// Lists Functionalities available
        ///
        /// Lists all Functionalities available
        /// <param name="includeDeleted">Indicates if we should include removed Functionalities in the result.</param>
        /// </summary>
        public List<Functionality> ListFunctionalities(bool includeDeleted = false, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/accounts/functionalities", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("includeDeleted", includeDeleted, ParameterType.QueryString);


            return Execute<List<Functionality>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific Functionality.
        ///
        /// Fetches a Functionality by the specified identifier.
        /// <param name="id">The Functionality identifier.</param>
        /// </summary>
        public Functionality RetrieveFunctionality(int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/accounts/functionalities/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<Functionality>(request, cachePolicy);
        }

        /// <summary>
        /// Lists Groups available
        ///
        /// Lists all Groups available
        /// <param name="includeDeleted">Indicates if we should include removed Groups in the result.</param>
        /// </summary>
        public List<Group> ListGroups(bool includeDeleted = false, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/accounts/groups", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("includeDeleted", includeDeleted, ParameterType.QueryString);


            return Execute<List<Group>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific Group.
        ///
        /// Fetches a Group by the specified identifier.
        /// <param name="id">The Group identifier.</param>
        /// </summary>
        public Group RetrieveGroup(int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/accounts/groups/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<Group>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches the currently logged in User.
        ///
        /// Effectively a whoami call.
        /// </summary>
        public User RetrieveCurrentUser(CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/accounts/me", Method.GET);
            request.Parameters.Clear();


            return Execute<User>(request, cachePolicy);
        }

        /// <summary>
        /// Lists Roles available
        ///
        /// Lists all Roles available
        /// <param name="includeDeleted">Indicates if we should include removed Roles in the result.</param>
        /// </summary>
        public List<Role> ListRoles(bool includeDeleted = false, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/accounts/roles", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("includeDeleted", includeDeleted, ParameterType.QueryString);


            return Execute<List<Role>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific Role.
        ///
        /// Fetches a Role by the specified identifier.
        /// <param name="id">The Role identifier.</param>
        /// </summary>
        public Role RetrieveRole(int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/accounts/roles/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<Role>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches all settings.
        ///
        /// Fetches all settings currently available for the current user.
        /// </summary>
        public Dictionary<string, object> ListSettings(CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/accounts/settings", Method.GET);
            request.Parameters.Clear();


            return Execute<Dictionary<string, object>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a setting.
        ///
        /// Fetches a setting for the current user.
        /// <param name="key">The key of the setting to fetch..</param>
        /// </summary>
        public Dictionary<string, object> RetrieveSetting(string key, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/accounts/settings/{key}", Method.GET);
            request.Parameters.Clear();


            return Execute<Dictionary<string, object>>(request, cachePolicy);
        }

        /// <summary>
        /// Lists Users available
        ///
        /// Lists all Users available
        /// <param name="includeDeleted">Indicates if we should include removed Users in the result.</param>
        /// </summary>
        public List<User> ListUsers(bool includeDeleted = false, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/accounts/users", Method.GET);
            request.Parameters.Clear();
            request.AddParameter("includeDeleted", includeDeleted, ParameterType.QueryString);


            return Execute<List<User>>(request, cachePolicy);
        }

        /// <summary>
        /// Fetches a specific User.
        ///
        /// Fetches a User by the specified identifier.
        /// <param name="id">The User identifier.</param>
        /// </summary>
        public User RetrieveUser(int id, CachePolicy cachePolicy = null)
        {
            var request = new RestRequest($"v1/accounts/users/{id}", Method.GET);
            request.Parameters.Clear();


            return Execute<User>(request, cachePolicy);
        }

        /// <summary>
        /// Creates a new setting.
        ///
        /// Creates a new, previously not existing setting.
        /// <param name="key">The key (identifier) of the setting</param>
        /// <param name="value">The value of the setting</param>
        /// </summary>
        public object CreateSetting(string key, string value)
        {
            var request = new RestRequest($"v1/accounts/settings", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(key),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(value),
                ParameterType.RequestBody);


            return Execute<object>(request);
        }

        /// <summary>
        /// Create a user Create a user in QBank
        /// <param name="user">The user to create</param>
        /// <param name="password">Password for the new user, leave blank to let QBank send a password-reset link to the user</param>
        /// <param name="redirectTo">Only used if leaving $password blank, a URL to redirect the user to after setting his/hers password</param>
        /// <param name="sendNotificationEmail">Send a notification email to the new user, as specified through the QBank backend</param>
        /// </summary>
        public User CreateUser(User user, string password = null, string redirectTo = null,
            bool sendNotificationEmail = false)
        {
            var request = new RestRequest($"v1/accounts/users", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(user),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(password),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(redirectTo),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(sendNotificationEmail),
                ParameterType.RequestBody);


            return Execute<User>(request);
        }

        /// <summary>
        /// Update a user Update a user in QBank
        /// <param name="id"></param>
        /// <param name="user">The user to update</param>
        /// <param name="password">Set a new password for the user, leave blank to leave unchanged</param>
        /// </summary>
        public User UpdateUser(int id, User user, string password = null)
        {
            var request = new RestRequest($"v1/accounts/users/{id}", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(user),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(password),
                ParameterType.RequestBody);


            return Execute<User>(request);
        }

        /// <summary>
        /// Add the user to one or more groups
        /// <param name="id"></param>
        /// <param name="groupIds">An array of int values.</param>
        /// </summary>
        public User AddUserToGroup(int id, List<int> groupIds)
        {
            var request = new RestRequest($"v1/accounts/users/{id}/groups", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(groupIds),
                ParameterType.RequestBody);


            return Execute<User>(request);
        }

        /// <summary>
        /// Update the last login time for a user Update the last login time for a user
        /// <param name="id"></param>
        /// <param name="successful">Login attempt successful or not</param>
        /// </summary>
        public User UpdateLastLogin(int id, bool successful = false)
        {
            var request = new RestRequest($"v1/accounts/users/{id}/registerloginattempt", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(successful),
                ParameterType.RequestBody);


            return Execute<User>(request);
        }

        /// <summary>
        /// Dispatch a password reset mail to a user
        ///
        /// . The supplied link will be included in the mail and appended with a "hash=" parameter containing the password reset hash needed to set the new password in step 2.
        /// <param name="id">The User identifier.</param>
        /// <param name="link">Optional link to override redirect to in the password reset mail</param>
        /// </summary>
        public object SendPasswordReset(int id, string link = null)
        {
            var request = new RestRequest($"v1/accounts/users/{id}/resetpassword", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(link),
                ParameterType.RequestBody);


            return Execute<object>(request);
        }

        /// <summary>
        /// Reset a password for a user with password reset hash
        ///
        /// Resets a password for a user with a valid password reset hash. Hash should be obtained through "/users/{id}/sendpasswordreset".
        /// <param name="hash">Valid password reset hash</param>
        /// <param name="password">New password</param>
        /// </summary>
        public Dictionary<string, object> ResetPassword(string hash, string password)
        {
            var request = new RestRequest($"v1/accounts/users/resetpassword", Method.POST);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(hash),
                ParameterType.RequestBody);
            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(password),
                ParameterType.RequestBody);


            return Execute<Dictionary<string, object>>(request);
        }

        /// <summary>
        /// Updates an existing setting.
        ///
        /// Updates a previously created setting.
        /// <param name="key">The key (identifier) of the setting..</param>
        /// <param name="value">The value of the setting</param>
        /// </summary>
        public object UpdateSetting(string key, string value)
        {
            var request = new RestRequest($"v1/accounts/settings/{key}", Method.PUT);
            request.Parameters.Clear();

            request.AddParameter("application/json", new RestSharpJsonNetSerializer().Serialize(value),
                ParameterType.RequestBody);


            return Execute<object>(request);
        }
    }
}