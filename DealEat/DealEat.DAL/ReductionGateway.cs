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
    public class ReductionGateway
    {
        readonly string _connectionString;


        public ReductionGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Result<ReductionData>> FindById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                ReductionData reduction = await con.QueryFirstAsync<ReductionData>(
                     "select * " +
                    "from dealeat.vReduc " +
                    "where SoldId = @Id",

                    new { Id = id });
                if (reduction == null) return Result.Failure<ReductionData>(Status.NotFound, "User not found.");
                return Result.Success(reduction);
            }

        }


        public async Task<IEnumerable<ReductionData>> GetAll()

        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return await con.QueryAsync<ReductionData> (
                   @"select R.RestaurantId, R.name as RestaurantName, B.Name as BracketName, B.PhotoLink, B.Price, B.information, S.Reduction
                    from dealeat.tRestaurant as R
                    LEFT JOIN dealeat.tBracket as B on R.RestaurantId = B.RestaurantId
                    LEFT JOIN dealeat.tSold as S on B.BracketId = S.BracketId
                    WHERE (S.Reduction > 0)
                    ");

                
            }
        }



        public async Task<IEnumerable<ReductionData>> GetReduction(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                IEnumerable<ReductionData> listReduction = await con.QueryAsync<ReductionData>(
                    @"select *
                    from dealeat.tBracket as B
                    LEFT JOIN  dealeat.tSold as S ON B.BracketId = S.BracketId

                    where B.RestaurantId = @id; ",
                   new { Id = id });
                //if (id == 0) return Result.Failure<RestaurantData>(Status.NotFound, "Restaurant not found.");
                return (listReduction);
            }
        }


        public async Task<Result<int>> CreateReduction( int reduction, DateTime start_date, DateTime end_date, int bracketId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Reduction", reduction);
                p.Add("@Start_Date", start_date);
                p.Add("@End_Date", end_date);
                p.Add("@BracketId", bracketId);

                await con.ExecuteAsync("dealeat.sSoldCreate", p, commandType: CommandType.StoredProcedure);

                return Result.Success(p.Get<int>("@SoldId"));

            }
        }


    }
}
