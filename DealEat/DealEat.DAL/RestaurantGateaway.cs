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
    public class RestaurantGateway
    {
        readonly string _connectionString;


        public RestaurantGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Result<RestaurantData>> FindById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                RestaurantData restaurant = await con.QueryFirstOrDefaultAsync<RestaurantData>(
                    @"select r.RestaurantId, r.Name, r.Adresse, r.Photolink, r.Telephone, c.Name as Category
                    from dealeat.vRestaurant as r
                    LEFT JOIN  dealeat.tRestaurant_Category as rc ON r.RestaurantId = rc.RestaurantId
                    LEFT JOIN  dealeat.tCategory as c ON rc.CategoryId = c.CategoryId
                    where r.RestaurantId = @Id ",

                    new { Id = id });
                if (restaurant == null) return Result.Failure<RestaurantData>(Status.NotFound, "Restaurant not found.");
                return Result.Success(restaurant);
            }
        }

        public async Task<Result> UpdateRestaurantById(int RestaurantId, string Name, string Adresse, string PhotoLink, int Telephone)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@RestaurantId", RestaurantId);
                p.Add("@Name", Name);
                p.Add("@Adresse", Adresse);
                p.Add("@PhotoLink", PhotoLink);
                p.Add("@Telephone", Telephone );
                
                await con.ExecuteAsync("DealEat.sRestaurantUpdate", p, commandType: CommandType.StoredProcedure);


                return Result.Success(Status.Ok);
            }
        }
        public async Task<IEnumerable<RestaurantData>> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                IEnumerable<RestaurantData> listRestaurant = await con.QueryAsync<RestaurantData> (
                    @"select r.RestaurantId, r.Name, r.Adresse, r.Photolink, r.Telephone, c.Name as Category
                    from dealeat.tRestaurant as r
                    LEFT JOIN  dealeat.tRestaurant_Category as rc ON r.RestaurantId = rc.RestaurantId
                    LEFT JOIN  dealeat.tCategory as c ON rc.CategoryId = c.CategoryId
                    ");

                return listRestaurant;
            }
        }





    }
}
