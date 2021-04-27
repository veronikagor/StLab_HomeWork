using System;
using System.Collections.Generic;
using System.Linq;

namespace Lessons10_REST_API.DataProvider
{
    public static class RandomUtils
    {
        private static Random random = new Random();

        public static IEnumerable<object[]> GetInvalidProjectId =>
            new List<object[]>
            {
                new object[] {Guid.NewGuid().ToString("n").Substring(0, 8)},
                new object[] {random.NextDouble()}
            };

        public static int GetNonExistentProjectId(List<int> projectsId)
        {
            return projectsId.Max() + random.Next(100, 1000);
        }
    }
}