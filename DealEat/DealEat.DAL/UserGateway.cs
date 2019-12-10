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
                    "select UserId, Email, Name, LastName, Pseudo, [Password] " +
                    "from dealeat.tUser " +
                    "where UserId = @UserId " ,
                    
                    new { UserId = userId });
                if (user == null) return Result.Failure<UserData>(Status.NotFound, "User not found.");
                return Result.Success(user);
            }
        }
        public async Task<Result<int>> CreateUser(string email, string name, string lastname, string pseudo,int tel, byte[] password)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Email", email);
                p.Add("@Name", name);
                p.Add("@LastName", lastname);
                p.Add("@Pseudo", pseudo);
                p.Add("@Telephone", tel);
                p.Add("@Password", password);
                p.Add("@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                await con.ExecuteAsync("dealeat.sUserCreate", p, commandType: CommandType.StoredProcedure);

                int status = p.Get<int>("@Status");
                if (status == 1) return Result.Failure<int>(Status.BadRequest, "An account with this email or pseudo already exists.");

                Debug.Assert(status == 0);
                return Result.Success(p.Get<int>("@UserId"));
            }
        }
        public async Task<IEnumerable<string>> GetAuthenticationProviders(string userId)
        {

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return await con.QueryAsync<string>(
                    "select p.ProviderName from dealeat.vAuthenticationProvider p where p.UserId = @UserId",
                    new { UserId = userId });
            }
        }

        public Task<UserData> FindByGoogleId(string googleId)
        {
            throw new NotImplementedException();
        }

        public Task CreateOrUpdateGoogleUser(string email, string googleId, string refreshToken)
        {
            throw new NotImplementedException();
        }

       public async Task<UserData> FindByEmail(string email)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                
                return await con.QueryFirstOrDefaultAsync<UserData>(
                     "select UserId, Email, Name, LastName, Pseudo, [Password] " +
                    "from dealeat.tUser " +
                    "where Email = @Email",
                    new { Email = email });
            }
        }

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
