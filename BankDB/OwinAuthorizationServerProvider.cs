namespace BankDB
{

    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.Owin.Security.OAuth;
    using BankDB;    

    public class OwinAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
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

            //Credenciales data = null;
            //string errorStatus = "";

            //using (EntidadesController _repo = new EntidadesController())
            //{
            //    try
            //    {
            //        data = await _repo.Login(context.UserName, context.Password);
            //    }
            //    catch (Exception ex)
            //    {
            //        errorStatus = ex.Message;
            //    }
            //}

            //if (data == null)
            //{
            //    context.SetError("invalid_grant", errorStatus);
            //    return;
            //}

            //var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //identity.AddClaim(new Claim("sub", context.UserName));
            //identity.AddClaim(new Claim("role", "user"));

            //if (data != null)
            //    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, data.EntidadID.ToString()));

            //context.Validated(identity);
        }
    }
}