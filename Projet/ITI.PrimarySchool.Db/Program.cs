using System;
using System.Linq;
using System.Reflection;
using DbUp;

namespace ITI.PrimarySchool.Db
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString = args.FirstOrDefault() ?? "Server=.;Database=PrimarySchool;Trusted_connection=true";

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            EnsureDatabase.For.SqlDatabase(connectionString);
            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
