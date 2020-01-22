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
        public async Task<Result<RestaurantDataWeb>> FindByIdWeb(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                RestaurantDataWeb restaurant = await con.QueryFirstOrDefaultAsync<RestaurantDataWeb>(
                    @"select r.RestaurantId, r.Name, r.Adresse, r.Photolink, r.Telephone
                    from dealeat.vRestaurant as r where r.RestaurantId = @Id ",

                    new { Id = id });
                if (restaurant == null) return Result.Failure<RestaurantDataWeb>(Status.NotFound, "Restaurant not found.");
                return Result.Success(restaurant);
            }
        }




        public async Task<IEnumerable<FeedBackData>> GetFeedback(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                IEnumerable<FeedBackData> listFeedBack = await con.QueryAsync<FeedBackData>(
                    @"select u.Name, f.Note, f.Feedback
                    from dealeat.tUser as U
                    LEFT JOIN  dealeat.tCustomer as C ON U.UserId = C.CustomerId
                    LEFT JOIN  dealeat.tFeedback as F ON C.CustomerId = F.CustomerId
                    LEFT JOIN  dealeat.tRestaurant as R ON R.RestaurantId = F.RestaurantId

                    where r.RestaurantId = @id; ",
                   new { Id = id });
                //if (id == 0) return Result.Failure<RestaurantData>(Status.NotFound, "Restaurant not found.");
                return (listFeedBack);
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

        public async Task<Result<int>> CreateFeedback(int Note, string Feedback, int CustomerId, int RestaurantId)
        {
            //if (!IsNameValid(firstName)) return Result.Failure<int>(Status.BadRequest, "The first name is not valid.");
            //if (!IsNameValid(lastName)) return Result.Failure<int>(Status.BadRequest, "The last name is not valid.");

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Note", Note);
                p.Add("@Feedback", Feedback);
                p.Add("@CustomerId", CustomerId);
                p.Add("@RestaurantId", RestaurantId);
                //p.Add("@StudentId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                // p.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                await con.ExecuteAsync("dealeat.sFeedbackCreate", p, commandType: CommandType.StoredProcedure);

                int status = p.Get<int>("@Status");
                //if (status == 1) return Result.Failure<int>(Status.BadRequest, "A student with this name already exists.");
                //if (status == 2) return Result.Failure<int>(Status.BadRequest, "A student with GitHub login already exists.");

                Debug.Assert(status == 0);
                return Result.Success(Status.Created, p.Get<int>("@StudentId"));
            }
        }



        bool IsNameValid(string name) => !string.IsNullOrWhiteSpace(name);

    }
}
