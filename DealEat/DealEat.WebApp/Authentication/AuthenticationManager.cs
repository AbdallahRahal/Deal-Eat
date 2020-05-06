using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DealEat.DAL;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace DealEat.WebApp.Authentication
{
    public abstract class AuthenticationManager<TUserInfo>
    {
        public async Task OnCreatingTicket( OAuthCreatingTicketContext ctx )
        {
            TUserInfo userInfo = await GetUserInfoFromContext( ctx );
            await CreateOrUpdateUser( userInfo );
            UserData user = await FindUser( userInfo );
            ctx.Principal = CreatePrincipal( user );
        }

        protected abstract Task<TUserInfo> GetUserInfoFromContext( OAuthCreatingTicketContext ctx );

        protected abstract Task CreateOrUpdateUser( TUserInfo userInfo );

        protected abstract Task<UserData> FindUser( TUserInfo userInfo );

        ClaimsPrincipal CreatePrincipal( UserData user )
        {
            List<Claim> claims = new List<Claim>
            {
                
                new Claim( ClaimTypes.Email, user.Email ),
                new Claim( ClaimTypes.NameIdentifier, user.UserId.ToString(), ClaimValueTypes.String )
            };
            ClaimsPrincipal principal = new ClaimsPrincipal( new ClaimsIdentity( claims, CookieAuthentication.AuthenticationType, ClaimTypes.Email, string.Empty ) );
            return principal;
        }
    }
}
