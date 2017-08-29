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
        const int TokenCacheExpirationTime = 5; // Minutes

        private static Credentials _credentials;
        private static string _apiAddress;
        private static CachePolicy _cachePolicy;
        private static RestClient _client;
        private readonly string _userName;

        //Lazy loading
        private readonly Lazy<AccountsController> _accounts = new Lazy<AccountsController>(() =>
            new AccountsController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public AccountsController Accounts => _accounts.Value;

        private readonly Lazy<CategoriesController> _categories = new Lazy<CategoriesController>(() =>
            new CategoriesController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public CategoriesController Categories => _categories.Value;

        private readonly Lazy<DeploymentController> _deployment = new Lazy<DeploymentController>(() =>
            new DeploymentController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public DeploymentController Deployment => _deployment.Value;

        private readonly Lazy<EventsController> _events = new Lazy<EventsController>(() =>
            new EventsController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public EventsController Events => _events.Value;

        private readonly Lazy<FiltersController> _filters = new Lazy<FiltersController>(() =>
            new FiltersController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public FiltersController Filters => _filters.Value;

        private readonly Lazy<FoldersController> _folders = new Lazy<FoldersController>(() =>
            new FoldersController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public FoldersController Folders => _folders.Value;

        private readonly Lazy<MediaController> _media = new Lazy<MediaController>(() =>
            new MediaController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public MediaController Media => _media.Value;

        private readonly Lazy<MoodboardsController> _moodboards = new Lazy<MoodboardsController>(() =>
            new MoodboardsController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public MoodboardsController Moodboards => _moodboards.Value;

        private readonly Lazy<ObjecttypesController> _objecttypes = new Lazy<ObjecttypesController>(() =>
            new ObjecttypesController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public ObjecttypesController Objecttypes => _objecttypes.Value;

        private readonly Lazy<PropertysetsController> _propertysets = new Lazy<PropertysetsController>(() =>
            new PropertysetsController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public PropertysetsController Propertysets => _propertysets.Value;

        private readonly Lazy<SearchController> _search = new Lazy<SearchController>(() =>
            new SearchController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public SearchController Search => _search.Value;

        private readonly Lazy<SocialmediaController> _socialmedia = new Lazy<SocialmediaController>(() =>
            new SocialmediaController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public SocialmediaController Socialmedia => _socialmedia.Value;

        private readonly Lazy<TemplatesController> _templates = new Lazy<TemplatesController>(() =>
            new TemplatesController(_apiAddress, new OAuth2Authenticator(_credentials), _cachePolicy, ref _client));

        public TemplatesController Templates => _templates.Value;


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
            _cachePolicy = cachePolicy;
            _client = new RestClient(new Uri(_apiAddress)) {Authenticator = new OAuth2Authenticator(_credentials)};

            _userName = credentials.UserName;
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