using System;
using System.Collections.Generic;

namespace Lessons10_REST_API.DataProvider
{
    public static class TestCaseSources
    {
        private static Random random = new Random();

        public static IEnumerable<object[]> Cases =>
            new List<object[]>
            {
                 new object[] {Guid.NewGuid().ToString("n").Substring(0, 8)},
                 new object[] {random.NextDouble()}
            };
        
    }
}
