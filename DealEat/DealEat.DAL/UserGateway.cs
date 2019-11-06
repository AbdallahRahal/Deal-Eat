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

        public async Task<Result<UserData>> FindById(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                UserData user = await con.QueryFirstOrDefaultAsync<UserData>(
                    "select u.UserId, u.Type, u.Name, u.LastName, u.Pseudo, u.[Password] " +
                    "from dealeat.vUser as u " +
                    "where u.UserId = @UserId " ,
                    
                    new { UserId = userId });
                if (user == null) return Result.Failure<UserData>(Status.NotFound, "User not found.");
                return Result.Success(user);
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

        public async Task<Result> Delete(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@UserId", userId);
                p.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                await con.ExecuteAsync("dealeat.sUserDelete", p, commandType: CommandType.StoredProcedure);

                int status = p.Get<int>("@Status");
                if (status == 1) return Result.Failure(Status.NotFound, "User not found.");

                Debug.Assert(status == 0);
                return Result.Success();
            }
        }





    }
}
