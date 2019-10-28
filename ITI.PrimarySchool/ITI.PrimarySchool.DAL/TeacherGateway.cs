using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;

namespace ITI.PrimarySchool.DAL
{
    public class TeacherGateway
    {
        readonly IOptions<GatewayOptions> _options;

        public TeacherGateway(IOptions<GatewayOptions> options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            _options = options;
        }

        public async Task<IEnumerable<TeacherData>> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_options.Value.ConnectionString))
            {
                return await conn.QueryAsync<TeacherData>(
                    @"select t.TeacherId, t.FirstName, t.LastName
                      from ps.vTeacher t;");
            }
        }

        public async Task<Result<int>> Create(string firstName, string lastName)
        {
            using (SqlConnection conn = new SqlConnection(_options.Value.ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters(new { FirstName = firstName, LastName = lastName });
                parameters.Add("TeacherId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await conn.ExecuteAsync("ps.sTeacherCreate", parameters, commandType: CommandType.StoredProcedure);

                int status = parameters.Get<int>("Result");
                if (status == 1)
                {
                    return Result.CreateError<int>("A teacher with this name already exists.");
                }
                else if (status == 0)
                {
                    int teacherId = parameters.Get<int>("TeacherId");
                    return Result.CreateSuccess(teacherId);
                }

                throw new Exception("Unknown status");
            }
        }

        public async Task Delete(int teacherId)
        {
            using (SqlConnection conn = new SqlConnection(_options.Value.ConnectionString))
            {
                await conn.ExecuteAsync("ps.sTeacherDelete", new { TeacherId = teacherId }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<FullTeacherData> GetById(int teacherId)
        {
            using (SqlConnection conn = new SqlConnection(_options.Value.ConnectionString))
            {
                return await conn.QuerySingleOrDefaultAsync<FullTeacherData>(
                    @"select t.TeacherId, t.FirstName, t.LastName, t.ClassName, [Level] = t.ClassLevel
                      from ps.vTeacher t
                      where t.TeacherId = @TeacherId;",
                    new { TeacherId = teacherId });
            }
        }
    }
}
