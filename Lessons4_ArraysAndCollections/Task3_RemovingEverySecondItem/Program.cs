using System;
using System.Collections.Generic;
using System.Linq;

/* There are N people in the loop, numbered from 1 to N.
 * When counting in a loop, every other person is crossed
 * out until there is only one left. Create a program that simulates the process.
 */
namespace Task3_RemovingEverySecondItem
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 10;
            LinkedList<int> numbers = new LinkedList<int>(Enumerable.Range(1, length));

            Console.WriteLine("Number of people in the loop: {" + string.Join(", ", numbers) + "}");

            for (int i = 0; i < numbers.Count; i++)
            {
                var currentNumber = numbers.First;
                while (numbers.Count != 1)
                {
                    Console.WriteLine(
                        $"The number of the person who left the loop is: {(currentNumber.Next ?? numbers.First).Value}");
                    numbers.Remove(currentNumber.Next ?? numbers.First);
                    currentNumber = currentNumber.Next ?? numbers.First;
                }

                Console.WriteLine($"The number of person who stayed is: {numbers.First.Value}");
            }
        }
    }
}