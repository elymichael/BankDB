namespace BankDB
{

    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.Owin.Security.OAuth;
    using BankDB;
    using BankDB.Models;
    using System.Linq;

    public class OwinAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private BankDBEntities db = new BankDBEntities();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() =>
            {
                context.Validated();
            });
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Content-Type" });

            string errorStatus = "";
            User user = null;
            try
            {
                using (var db = new BankDBEntities())
                {
                   user = db.Users
                  .Where(s => s.Email == context.UserName && s.Password == context.Password)
                  .FirstOrDefault<User>();
                }
            }
            catch (Exception ex)
            {
                errorStatus = ex.Message;
            }
           
            if (user == null)
            {
                context.SetError("invalid_grant", errorStatus);
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            if (user != null)
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            context.Validated(identity);
        }
    }
}