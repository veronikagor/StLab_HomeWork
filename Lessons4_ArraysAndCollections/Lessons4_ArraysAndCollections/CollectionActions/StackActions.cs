using System;
using System.Collections.Generic;
using System.Linq;

namespace Lessons4_ArraysAndCollections.CollectionActions
{
    public static class StackActions
    {
        public static HashSet<int> CopyStackToHashSet(Stack<int> stack)
        {
            return Enumerable.ToHashSet(stack);
        }

        public static Stack<int> CreateStackWithDuplicateElements(HashSet<int> firstSet, HashSet<int> secondSet)
        {
            var combinedStack = new Stack<int>();

            foreach (var element in firstSet)
            {
                if (secondSet.Contains(element))
                {
                    combinedStack.Push(element);
                }
            }

            return combinedStack;
        }
    }
}