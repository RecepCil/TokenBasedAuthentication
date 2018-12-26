using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TokenBasedAuthentication.WebAPI.OAuth.Providers;
using TokenBasedAuthentication.WebAPI.Services;

[assembly: OwinStartup(typeof(TokenBasedAuthentication.WebAPI.OAuth.Startup))]
namespace TokenBasedAuthentication.WebAPI.OAuth
{
    // Servis çalışmaya başlarken Owin pipeline'ını ayağa kaldırabilmek için Startup'u hazırlıyoruz.
    public class Startup
    {
        public IUserLoginService _userLoginService;

        //bu dogru mu??
        public Startup()
        {
            //IUserLoginService userLoginService
            //this._userLoginService = userLoginService;
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            ConfigureOAuth(appBuilder);
            WebApiConfig.Register(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);
        }
        private void ConfigureOAuth(IAppBuilder appBuilder)
        {

            OAuthAuthorizationServerOptions oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"), // token alacağımız path'i belirtiyoruz
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1), // 86400 sn
                AllowInsecureHttp = true,
                Provider = new SimpleAuthorizationServerProvider(_userLoginService)
            };
            // AppBuilder'a token üretimini gerçekleştirebilmek için ilgili authorization ayarlarımızı veriyoruz.
            appBuilder.UseOAuthAuthorizationServer(oAuthAuthorizationServerOptions);
            // Authentication type olarak ise Bearer Authentication'ı kullanacağımızı belirtiyoruz.
            // Bearer token OAuth 2.0 ile gelen standartlaşmış token türüdür.
            // Herhangi kriptolu bir veriye ihtiyaç duymadan client tarafından token isteğinde bulunulur ve server belirli bir expire date'e sahip bir access_token üretir.
            // Bearer token üzerinde güvenlik SSL'e dayanır.
            // Bir diğer tip ise MAC token'dır. OAuth 1.0 versiyonunda kullanılıyor, hem client'a, hemde server tarafına implementasyonlardan dolayı ek maliyet çıkartmaktadır. Bu maliyetin yanı sıra ise Bearer token'a göre kaynak alış verişinin biraz daha güvenli olduğu söyleniyor çünkü client her request'inde veriyi hmac ile imzalayıp verileri kriptolu bir şekilde göndermeleri gerektiği için.
            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}