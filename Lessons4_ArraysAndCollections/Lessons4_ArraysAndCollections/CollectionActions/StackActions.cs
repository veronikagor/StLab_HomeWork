using System;
using System.Collections.Generic;

namespace Lessons4_ArraysAndCollections.CollectionActions
{
    public static class StackActions
    {
        public static void MergeStacks(Stack<int> stack1, Stack<int> stack2)
        {
            var combinedStack = new Stack<int>();
            while (stack1.Count > 0 || stack2.Count > 0)
                if (stack2.Count == 0 || (stack1.Count != 0 && stack1.Peek() > stack2.Peek()))
                    combinedStack.Push(stack1.Pop());
                else
                    combinedStack.Push(stack2.Pop());

            Console.WriteLine("Сombined stack {" + string.Join(", ", combinedStack) + "}\n");
        }
    }
}