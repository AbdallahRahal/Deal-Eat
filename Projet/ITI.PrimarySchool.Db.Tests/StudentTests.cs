using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using NUnit.Framework;

namespace ITI.PrimarySchool.Db.Tests
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public async Task get_students()
        {
            using (SqlConnection conn = new SqlConnection("Server=.;Database=PrimarySchool;Trusted_Connection=True;"))
            {
                var testData = new
                {
                    FirstName = TestHelpers.GetRandomName(),
                    LastName = TestHelpers.GetRandomName(),
                    BirthDate = TestHelpers.GetRandomBirthDate()
                };

                DynamicParameters parameters = new DynamicParameters(testData);
                parameters.Add("StudentId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await conn.ExecuteAsync("ps.sStudentCreate", parameters, commandType: CommandType.StoredProcedure);
                int status = parameters.Get<int>("Result");

                Assert.That(status, Is.EqualTo(0));

                int studentId = parameters.Get<int>("StudentId");

                StudentData student = await conn.QuerySingleAsync<StudentData>(
                    "select s.FirstName, s.LastName, s.BirthDate from ps.vStudent s where s.StudentId = @StudentId;",
                    new { StudentId = studentId });

                Assert.That(student.FirstName, Is.EqualTo(testData.FirstName));
                Assert.That(student.LastName, Is.EqualTo(testData.LastName));
                Assert.That(student.BirthDate, Is.EqualTo(testData.BirthDate));

                parameters = new DynamicParameters(new { StudentId = studentId });
                parameters.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await conn.ExecuteAsync("ps.sStudentDelete", parameters, commandType: CommandType.StoredProcedure);

                Assert.That(parameters.Get<int>("Result"), Is.EqualTo(0));
            }
        }
    }

    public class StudentData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
