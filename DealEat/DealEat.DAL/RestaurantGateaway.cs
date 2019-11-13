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
    class RestaurantGateaway
    {
        readonly string _connectionString;


        public RestaurantGateaway(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<Result<RestaurantData>> FindById(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                RestaurantData user = await con.QueryFirstOrDefaultAsync<RestaurantData>(
                    "select u.UserId, u.Type, u.Name, u.LastName, u.Pseudo, u.[Password] " +
                    "from dealeat.vUser as u " +
                    "where u.UserId = @UserId ",

                    new { UserId = userId });
                if (user == null) return null;// Result.Failure<UserData>(Status.NotFound, "User not found.");
                return Result.Success(user);
            }
        }







    }
}
