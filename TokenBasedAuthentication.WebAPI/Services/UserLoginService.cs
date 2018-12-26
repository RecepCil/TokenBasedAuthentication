using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using TokenBasedAuthentication.WebAPI.Data;
using TokenBasedAuthentication.WebAPI.Domain;
using System.Net.Http.Headers;

namespace TokenBasedAuthentication.WebAPI.Services
{
    public class UserLoginService : IUserLoginService
    {
        #region Fields

        private readonly IRepository<UserLogin> _userLoginRepository;

        #endregion

        #region Constructor

        public UserLoginService() : this(new EfRepository<UserLogin>())
        {

        }
        public UserLoginService(IRepository<UserLogin> userLoginRepository)
        {
            this._userLoginRepository = userLoginRepository;
        }

        #endregion

        #region Methods

        public bool IsUser(UserLogin userLogin)
        {
            var query = from p in _userLoginRepository.Table
                        where p.Username == userLogin.Username 
                        && p.Password == userLogin.Password
                        select p;

            return query.Any();
        }

        public void InsertUser(UserLogin user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            //insert
            _userLoginRepository.Insert(user);
        }

        public async Task LogInAsync(UserLogin userLogin)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12345/token");
            var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);

            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("grant_type", "password"));
            keyValues.Add(new KeyValuePair<string, string>("username", userLogin.Username));
            keyValues.Add(new KeyValuePair<string, string>("password", userLogin.Password));


            request.Content = new FormUrlEncodedContent(keyValues);
            HttpResponseMessage responseMessage = await client.SendAsync(request);
        }

        #endregion
    }
}