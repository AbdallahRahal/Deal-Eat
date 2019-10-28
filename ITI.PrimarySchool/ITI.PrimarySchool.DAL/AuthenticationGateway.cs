using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;

namespace ITI.PrimarySchool.DAL
{
    public class AuthenticationGateway
    {
        readonly IOptions<GatewayOptions> _options;

        public AuthenticationGateway(IOptions<GatewayOptions> options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            _options = options;
        }

        public async Task<UserData> FindUser(string email)
        {
            using (SqlConnection conn = new SqlConnection(_options.Value.ConnectionString))
            {
                return await conn.QuerySingleOrDefaultAsync<UserData>(
                    @"select u.UserId, u.[Password]
                      from ps.vUser u
                      where u.[Email] = @Email;",
                    new { Email = email });
            }
        }
    }
}
