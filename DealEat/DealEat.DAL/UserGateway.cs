using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace DealEat.DAL
{
    public class UserGateway
    {
        readonly string _connectionString;

        public UserGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<UserData> FindById(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return await con.QueryFirstOrDefaultAsync<UserData>(
                    "select u.UserId, u.Type, u.Name, u.LastName, u.Pseudo, u.[Password] " +
                    "from dealeat.vUser as u " +
                    "where u.UserId = @UserId " ,
                    
                    new { UserId = userId });
            }
        }

        // POUR LE MAIL
        /*public async Task<UserData> FindByEmail(string email)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return await con.QueryFirstOrDefaultAsync<UserData>(
                    "select u.UserId, u.Type, u.Name, u.LastName, u.Pseudo, u.[Password] " +
                    "from dealeat.vUser as u " +
                    "where u.Email = @Email",
                    new { Email = email });
            }
        }*/

        public async Task Delete(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.ExecuteAsync("dealeat.sUserDelete", new { UserId = userId }, commandType: CommandType.StoredProcedure);
            }
        }





    }
}
