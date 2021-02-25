using System;

namespace Lessons3_ClassesObjectsMethods.Utils
{
    static class RandomUtils
    {
        private const int MinCountOfUsers = 1;
        private const int MaxCountOfUsers = 10;

        public static int CreateRandomNumberOfUsers()
        {
            return new Random().Next(MinCountOfUsers, MaxCountOfUsers);
        }
    }
}