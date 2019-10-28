using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.PrimarySchool.Db.Tests
{
    class TestHelpers
    {
        static readonly Random Random = new Random();
        static readonly string[] Levels = new[] { "CP", "CE1", "CE2", "CM1", "CM2" };

        public static string GetRandomName() => string.Format("Test-{0}", Guid.NewGuid().ToString().Substring(0, 16));

        public static string GetRandomClassName() => GetRandomName().Substring(0, 8);

        public static DateTime GetRandomBirthDate() => DateTime.UtcNow.Date.AddDays(Random.Next(-365 * 10, -365 * 5));

        public static string GetRandomLevel() => Levels[Random.Next(5)];
    }
}
