using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;

namespace ITI.PrimarySchool.DAL
{
    public class ClassGateway
    {
        readonly IOptions<GatewayOptions> _options;

        public ClassGateway(IOptions<GatewayOptions> options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            _options = options;
        }

        public async Task<IEnumerable<ClassData>> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_options.Value.ConnectionString))
            {
                return await conn.QueryAsync<ClassData>("select c.ClassId, c.Name, c.[Level] from ps.vClass c;");
            }
        }

        public async Task<ClassData> GetById(int classId)
        {
            using (SqlConnection conn = new SqlConnection(_options.Value.ConnectionString))
            {
                return await conn.QuerySingleOrDefaultAsync<ClassData>(
                    "select c.ClassId, c.Name, c.[Level] from ps.vClass c where c.ClassId = @ClassId;",
                    new { ClassId = classId });
            }
        }
    }

    public class ClassData
    {
        public int ClassId { get; set; }

        public string Name { get; set; }

        public string Level { get; set; }
    }
}
