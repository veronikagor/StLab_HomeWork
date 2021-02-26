using System;
using System.Collections.Generic;
using System.Linq;

/* There are N people in the loop, numbered from 1 to N.
 * When counting in the circle, every second person is crossed
 * out until there is only one left. Create a program that simulates the process.
 */
namespace Task3_RemovingEverySecondItem
{
    class Program
    {
        public LinkedList<int> CreateList()
        {
            int length = 10;
            var numbers = new LinkedList<int>(Enumerable.Range(1, length));

            Console.WriteLine("Peoples number in the circle: {" + string.Join(", ", numbers) + "}");
            return numbers;
        }

        public void CrossOutThePerson(LinkedList<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                var currentNumber = numbers.First;
                while (numbers.Count != 1)
                {
                    Console.WriteLine(
                        $"Person number {(currentNumber.Next ?? numbers.First).Value} left the circle");
                    numbers.Remove(currentNumber.Next ?? numbers.First);
                    currentNumber = currentNumber.Next ?? numbers.First;
                }

                Console.WriteLine($"Person number {numbers.First.Value} stayed");
            }
        }

        static void Main(string[] args)
        {
            var program = new Program();
            var listOfPerson = program.CreateList();
            program.CrossOutThePerson(listOfPerson);
        }
    }
}