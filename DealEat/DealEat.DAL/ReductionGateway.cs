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

        /*public async Task<Result<ReductionData>> FindById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                ReductionData reduction = await con.QueryFirstOrDefaultAsync<ReductionData>(
                    REQUETE SQL,

                    new { Id = id });
                if (reduction == null) return Result.Failure<ReductionData>(Status.NotFound, "User not found.");
                return Result.Success(reduction);
            }
        }*/
        public async Task<IEnumerable<ReductionData>> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                IEnumerable<ReductionData> listReduction = await con.QueryAsync<ReductionData> (
                    @"select * from dealeat.vBracket");

                return listReduction;
            }
        }





    }
}
