using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace ITI.PrimarySchool.DAL
{
    public class StudentGateway
    {
        readonly string _connectionString;

        public StudentGateway(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentException("The connection string must be not null nor whitespace.", nameof(connectionString));
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<StudentData>> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return await conn.QueryAsync<StudentData>(
                    @"select s.StudentId, s.FirstName, s.LastName, s.BirthDate
                      from ps.vStudent s;");
            }
        }
    }
}
