using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using sample_webapi.Providers;

[assembly: OwinStartup(typeof(sample_webapi.Startup))]

namespace sample_webapi
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			var oAuthServiceProvider = new ApplicationOAuthProvider();

			OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
				Provider = oAuthServiceProvider				
			};

			app.UseOAuthAuthorizationServer(options);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

			HttpConfiguration config = new HttpConfiguration();
			WebApiConfig.Register(config);
		}
	}
}
