using System;
using System.Diagnostics;
using Lessons4_ArraysAndCollections.CollectionActions;
using Lessons4_ArraysAndCollections.RandomUtils;

namespace Lessons4_ArraysAndCollections
{
    public class Runner
    {
        public static void Main()
        {
            /*
             1. From the two given stacks that store numbers, 
             create a new stack of the numbers that are in both the first and second stack.
            */
            MergeTwoStacks();

            /* 
             2. Given a sequence of N distinct integers entered in the queue.
             Find the sum of its members located between the maximum and minimum values 
             (include both of these numbers in the sum).
            */
            FindTheSumOfNumberInQueueBetweenMaximumAndMinimumValues();

            /*
             3. There are N people in the circle, numbered from 1 to N.
             When counting in the circle, every second person is crossed
             out until there is only one left. Create a program that simulates the process.
            */
            CrossOutEverySecondPersonInTheCircle();

            /*
             4. Implement any two sorts from the list in the lecture.
            */
            SortArrayByTwoSortingAlgorithmsAndDisplayRunTime();
        }

        public static void MergeTwoStacks()
        {
            int minCountOfNumbers = 1;
            int maxCountOfNumbers = 11;

            var firstStack = CollectionCreation.GenerateRandomNumbersForStack(minCountOfNumbers, maxCountOfNumbers);
            var secondStack = CollectionCreation.GenerateRandomNumbersForStack(minCountOfNumbers, maxCountOfNumbers);
            
            var firstSet = StackActions.CopyStackToHashSet(firstStack);
            var secondSet = StackActions.CopyStackToHashSet(secondStack);
            
            var combinedStack = StackActions.CreateStackWithDuplicateElements(firstSet, secondSet);
            Console.WriteLine("Сombined stack {" + string.Join(", ", combinedStack) + "}\n");
        }

        public static void FindTheSumOfNumberInQueueBetweenMaximumAndMinimumValues()
        {
            int minCountOfMembers = 1;
            int maxCountOfMembers = 11;

            var queue = CollectionCreation.GenerateRandomNumbersForQueue(minCountOfMembers, maxCountOfMembers);
            var array = QueueActions.CopyQueueToArray(queue);
            var sum = QueueActions.SumOfNumbersBetweenMaximumAndMinimumValues(array);
            Console.WriteLine($"Sum of numbers between upper and lower numbers in queue is {sum}\n");
        }

        public static void CrossOutEverySecondPersonInTheCircle()
        {
            int lengthOfPersonsList = 10;

            var listOfPersons = CollectionCreation.GenerateRandomNumbersForList(lengthOfPersonsList);
            LinkedListActions.CrossOutEverySecondPerson(listOfPersons);
        }

        public static void SortArrayByTwoSortingAlgorithmsAndDisplayRunTime()
        {
            int minArrayLength = 2;
            int maxArrayLength = 10;

            var arrayToSelectionSort = CollectionCreation.GenerateRandomNumbersForArray(minArrayLength, maxArrayLength);
            var arrayToStoogeSort = (int[]) arrayToSelectionSort.Clone();

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            ArrayActions.StoogeSort(arrayToStoogeSort);
            stopwatch.Stop();
            Console.WriteLine("The array sorted by stooge sort: {"
                              + string.Join(", ", arrayToStoogeSort) + "} in " + (stopwatch.Elapsed.TotalMilliseconds)
                              + " milliseconds");

            stopwatch.Reset();
            stopwatch.Start();
            ArrayActions.SelectionSort(arrayToSelectionSort);
            stopwatch.Stop();
            Console.WriteLine("The array sorted by selection sort: {"
                              + string.Join(", ", arrayToSelectionSort) + "} in " +
                              (stopwatch.Elapsed.TotalMilliseconds)
                              + " milliseconds");
        }
    }
}