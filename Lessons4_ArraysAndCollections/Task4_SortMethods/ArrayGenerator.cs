using System;

namespace Task4_SortMethods
{
   class ArrayGenerator
   {
      public static int[] CreateArray()
      {
         int minArrayLength = 2;
         int maxArrayLength = 10;
         var array = new int[new Random().Next(minArrayLength, maxArrayLength)];

         for (int i = 0; i < array.Length - 1; i++)
         {
            array[i] = new Random().Next();
         }

         return array;
      }
   }
}