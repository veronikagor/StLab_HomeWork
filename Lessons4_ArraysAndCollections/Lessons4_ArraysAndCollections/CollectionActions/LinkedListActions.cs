using System;
using System.Collections.Generic;

namespace Lessons4_ArraysAndCollections.CollectionActions
{
    public class LinkedListActions
    {
        public static void CrossOutEverySecondPerson(LinkedList<int> linkedList)
        {
            for (int i = 0; i < linkedList.Count; i++)
            {
                var currentNumber = linkedList.First;
                while (linkedList.Count != 1)
                {
                    Console.WriteLine(
                        $"Person number {(currentNumber.Next ?? linkedList.First).Value} left the circle");
                    linkedList.Remove(currentNumber.Next ?? linkedList.First);
                    currentNumber = currentNumber.Next ?? linkedList.First;
                }

                Console.WriteLine($"Person number {linkedList.First.Value} stayed\n");
            }
        }
    }
}