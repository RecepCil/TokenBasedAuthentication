using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using TokenBasedAuthentication.WebAPI.Data;
using TokenBasedAuthentication.WebAPI.Domain;
using TokenBasedAuthentication.WebAPI.Services;

namespace TokenBasedAuthentication.WebAPI.OAuth.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        #region Fields

        private IUserLoginService _userLoginService;

        #endregion

        #region Constructors

        public SimpleAuthorizationServerProvider(IUserLoginService userLoginService)
        {
             this._userLoginService = userLoginService;
        }

        #endregion

        #region Methods

        // OAuthAuthorizationServerProvider sınıfının client erişimine izin verebilmek için ilgili ValidateClientAuthentication metotunu override ediyoruz.
        public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        // OAuthAuthorizationServerProvider sınıfının kaynak erişimine izin verebilmek için ilgili GrantResourceOwnerCredentials metotunu override ediyoruz.
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // CORS ayarlarını set ediyoruz.
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            // Kullanıcının access_token alabilmesi için gerekli validation işlemlerini yapıyoruz.
            UserLoginService userLoginService = new UserLoginService(); 
            bool isUser = userLoginService.IsUser(new UserLogin { Username = context.UserName, Password = context.Password });
            if (isUser)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));  // new Claim("sub", context.UserName)
                identity.AddClaim(new Claim("role", "user"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Kullanıcı adı veya şifre yanlış.");
            }
        }

        #endregion
    }
}