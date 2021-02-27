using System;
using System.Collections.Generic;

/* From the two given stacks that store numbers, create a new stack of the numbers that are in both the first and second stack.
 */
namespace Task1_Stack
{
    class Program
    {
        public Stack<int> CreateStack()
        {
            const int minCountOfNumbers = 1;
            const int maxCountOfNumbers = 11;

            var random = new Random();
            var satck = new Stack<int>();

            for (int i = 0; i < maxCountOfNumbers - 1; i++)
            {
                satck.Push(random.Next(minCountOfNumbers, maxCountOfNumbers));
            }

            Console.WriteLine("Stack is created: {" + string.Join(", ", satck) + "}");
            return satck;
        }

        public void MergeStacks(Stack<int> stack1, Stack<int> stack2)
        {
            var combinedStack = new Stack<int>();
            while (stack1.Count > 0 || stack2.Count > 0)
                if (stack2.Count == 0 || (stack1.Count != 0 && stack1.Peek() > stack2.Peek()))
                    combinedStack.Push(stack1.Pop());
                else
                    combinedStack.Push(stack2.Pop());

            Console.WriteLine("Сombined stack {" + string.Join(", ", combinedStack) + "}");
        }

        static void Main(string[] args)
        {
            // Не совсем понимаю - а зачем создавать эксземпляр класса в этом же классе?
            // Лучше сделать по образу и подобию лекции 3 (классы и фабрики)
            // Отрефакторить все задачи на основании замечания выше
            
            Program program = new Program();
            var stack1 = program.CreateStack();
            var stack2 = program.CreateStack();

            program.MergeStacks(stack1, stack2);
        }
    }
}