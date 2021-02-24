using System;
using System.Collections.Generic;

/*
 * From the two given stacks that store numbers, create a new stack of the numbers that are in both the first and second stack.
 */
namespace Task1_MergingStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(2);
            stack1.Push(10);
            stack1.Push(4);
            stack1.Push(6);
            stack1.Push(42);

            Stack<int> stack2 = new Stack<int>();
            stack2.Push(5);
            stack2.Push(3);
            stack2.Push(11);

            Stack<int> combinedStack = new Stack<int>();

            while (stack1.Count > 0 || stack2.Count > 0)
                if (stack2.Count == 0 || (stack1.Count != 0 && stack1.Peek() > stack2.Peek()))
                    combinedStack.Push(stack1.Pop());
                else
                    combinedStack.Push(stack2.Pop());

            Console.WriteLine("Сombined stack {" + string.Join(", ", combinedStack) + "}");
        }
    }
}