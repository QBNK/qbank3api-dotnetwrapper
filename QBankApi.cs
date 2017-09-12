using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using QBankApi.Controller;
using QBankApi.Enums;
using QBankApi.Model;
using RestSharp;

namespace QBankApi
{
    public class QBankApi : Communication
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly List<UserAccessToken> _userAccessTokenCache = new List<UserAccessToken>();
        private const int TokenCacheExpirationTime = 5; // Minutes

        private readonly Credentials _credentials;
        private readonly string _apiAddress;
        private readonly string _userName;

        public CachePolicy CachePolicy { get; }

        //Lazy loading
        public AccountsController Accounts => GetRegisteredController<AccountsController>();

        public CategoriesController Categories => GetRegisteredController<CategoriesController>();
        public DeploymentController Deployment => GetRegisteredController<DeploymentController>();
        public EventsController Events => GetRegisteredController<EventsController>();
        public FiltersController Filters => GetRegisteredController<FiltersController>();
        public FoldersController Folders => GetRegisteredController<FoldersController>();
        public MediaController Media => GetRegisteredController<MediaController>();
        public MoodboardsController Moodboards => GetRegisteredController<MoodboardsController>();
        public ObjecttypesController Objecttypes => GetRegisteredController<ObjecttypesController>();
        public PropertysetsController Propertysets => GetRegisteredController<PropertysetsController>();
        public SearchController Search => GetRegisteredController<SearchController>();
        public SocialmediaController Socialmedia => GetRegisteredController<SocialmediaController>();
        public TemplatesController Templates => GetRegisteredController<TemplatesController>();


        private readonly Dictionary<Type, object> _loaders = new Dictionary<Type, object>();

        public void RegisterControllerLoader<T>(Func<T> lazyLoaderFunc, bool overrideIfExists = true)
            where T : ControllerAbstract
        {
            var loaderType = typeof(T);
            if (overrideIfExists || !_loaders.ContainsKey(loaderType))
            {
                _loaders[loaderType] = new Lazy<T>(lazyLoaderFunc);
            }
        }

        public T GetRegisteredController<T>() where T : ControllerAbstract
        {
            return (_loaders[typeof(T)] as Lazy<T>)?.Value;
        }

        /// <summary>
        ///     Initialize QBank Api
        /// </summary>
        /// <param name="credentials">The credentials used to connect</param>
        /// <param name="apiAddress">The URL to the QBank API</param>
        /// <param name="cachePolicy">The cachepolicy</param>
        public QBankApi(Credentials credentials, string apiAddress, CachePolicy cachePolicy = null)
            : base(apiAddress, new OAuth2Authenticator(credentials))
        {
            GetAccessToken();

            if (cachePolicy == null)
            {
                cachePolicy = new CachePolicy(CacheType.Off, 0);
                _logger.Warn("No cache policy supplied! Without a cache policy no API queries will be cached.");
            }

            _credentials = credentials;
            _apiAddress = apiAddress;
            CachePolicy = cachePolicy;
            _userName = credentials.UserName;

            RegisterControllerLoader(() => new AccountsController(CachePolicy, Client));
            RegisterControllerLoader(() => new CategoriesController(CachePolicy, Client));
            RegisterControllerLoader(() => new DeploymentController(CachePolicy, Client));
            RegisterControllerLoader(() => new EventsController(CachePolicy, Client));
            RegisterControllerLoader(() => new FiltersController(CachePolicy, Client));
            RegisterControllerLoader(() => new FoldersController(CachePolicy, Client));
            RegisterControllerLoader(() => new MediaController(CachePolicy, Client));
            RegisterControllerLoader(() => new MoodboardsController(CachePolicy, Client));
            RegisterControllerLoader(() => new ObjecttypesController(CachePolicy, Client));
            RegisterControllerLoader(() => new PropertysetsController(CachePolicy, Client));
            RegisterControllerLoader(() => new SearchController(CachePolicy, Client));
            RegisterControllerLoader(() => new SocialmediaController(CachePolicy, Client));
            RegisterControllerLoader(() => new TemplatesController(CachePolicy, Client));
        }

        internal TokenResponse GetAccessToken()
        {
            var userAccessToken =
                _userAccessTokenCache.FirstOrDefault(u =>
                    u.UserName.Equals(_userName, StringComparison.OrdinalIgnoreCase));

            if (userAccessToken != null)
            {
                if (userAccessToken.Expires > DateTime.Now)
                {
                    return userAccessToken.Token;
                }

                _userAccessTokenCache.Remove(userAccessToken);
            }

            if (OAuth2Authenticator == null)
            {
                return null;
            }

            if (OAuth2Authenticator?.Token != null)
            {
                TriggerCall();
            }

            _userAccessTokenCache.Add(new UserAccessToken
            {
                UserName = _userName,
                Token = OAuth2Authenticator.Token,
                Expires = DateTime.Now.AddMinutes(TokenCacheExpirationTime)
            });

            return OAuth2Authenticator.Token;
        }

        private void TriggerCall()
        {
            var request = new RestRequest("accounts/settings.json", Method.GET);
            Execute<List<string>>(request);
        }
    }
}