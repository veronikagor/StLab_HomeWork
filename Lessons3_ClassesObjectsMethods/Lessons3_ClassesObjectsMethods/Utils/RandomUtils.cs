using System;

namespace Lessons3_ClassesObjectsMethods.Utils
{
    public static class RandomUtils
    {
        public static int RandomInt(int minCount, int maxCount)
        {
            var random = new Random();
            return random.Next(minCount, maxCount);
        }
    }
}