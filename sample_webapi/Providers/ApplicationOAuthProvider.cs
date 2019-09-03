using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace sample_webapi.Providers
{
	public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
	{
		public ApplicationOAuthProvider()
		{
		}

		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context?.Validated();
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			var claimIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
			if (context.UserName == "admin" && context.Password == "admin")
			{
				claimIdentity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
				claimIdentity.AddClaim(new Claim("username", "admin"));
				claimIdentity.AddClaim(new Claim(ClaimTypes.Name, "AdminClaims"));
				context.Validated(claimIdentity);
			}
			else if (context.UserName == "user" && context.Password == "user")
			{
				claimIdentity.AddClaim(new Claim(ClaimTypes.Role, "user"));
				claimIdentity.AddClaim(new Claim("username", "user"));
				claimIdentity.AddClaim(new Claim(ClaimTypes.Name, "AdminClaims"));
				context.Validated(claimIdentity);
			}
			else
			{
				context.SetError("invalid_grant", "Wrong credentials Used. Please Try again");
				return;
			}


		}
	}
}