using System;
using System.Text.RegularExpressions;

/*
 * Write examples of using all the operators
 */
namespace Lessons1_VariablesAndOperators
{
    public class UsingOfOperators
    {
        public static void RunCalculator()
        {
            Console.WriteLine("\nCalculator for checking arithmetic operations");

            double firstNumber = 0.0;
            double secondNumber = 0.0;
            string operation = null;
            while (string.IsNullOrEmpty(operation))
            {
                try
                {
                    Console.WriteLine("Enter the first number");
                    firstNumber = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the second number");
                    secondNumber = double.Parse(Console.ReadLine());
                    Console.WriteLine("Select the desired operation on the numbers: '+', '-', '*', '/', '%' ");
                    operation = Console.ReadLine();
                    if (Regex.IsMatch(operation, "^[^+-/*%]+$"))
                    {
                        operation = null;
                        Console.WriteLine("This type of input value is wrong! Please try again:");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("This type of input value is wrong! Please try again:");
                }
            }

            switch (operation)
            {
                case "+":
                    Console.WriteLine($"Result is: {firstNumber + secondNumber}");
                    break;
                case "-":
                    Console.WriteLine($"Result is: {firstNumber - secondNumber}");
                    break;
                case "*":
                    Console.WriteLine($"Result is: {firstNumber * secondNumber}");
                    break;
                case "%":
                    Console.WriteLine($"Result is: {firstNumber % secondNumber}");
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        Console.WriteLine("This is exceptional case");
                    }
                    else
                    {
                        Console.WriteLine($"Result is: {firstNumber / secondNumber}");
                    }

                    break;
                default:
                    Console.WriteLine("This operation is unknown to us!");
                    break;
            }
        }

        public static void RunGuessTheNumberGame()
        {
            Console.WriteLine("\n'Guess the Number' game for checking increment and decrement operations");

            Random random = new Random();
            int secretNumber = random.Next(1, 4);
            Console.WriteLine(
                "The compiler has conceived a number from 1 to 4. I suggest you guess it with 3 attempts.");
            Console.WriteLine(secretNumber);
            int counter = 0;
            int numberOfAttempts = 3;

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    int enteredNumber = Int32.Parse(Console.ReadLine());

                    counter++;
                    numberOfAttempts--;
                    if (enteredNumber == secretNumber)
                    {
                        Console.WriteLine($"Congratulations! You got the number from the {counter} attempt");
                    }
                    else
                    {
                        Console.WriteLine($"Wrong value! You have {numberOfAttempts} attempt(s) left");
                    }
                }
                catch
                {
                    Console.WriteLine("A mistake! You didn't enter a number");
                }
            }
        }

        public static void CheckAgeToRetire(int age, string gender)
        {
            Console.WriteLine("Do I need to retire? To check logical operators");

            if ((age >= 57 && gender.ToUpper() == "F") ^
                (age >= 62 && gender.ToUpper() == "M"))
            {
                Console.WriteLine("You can to retire!");
            }
            else
            {
                Console.WriteLine("It's too early to retire!");
            }
        }

        public static void RunLogicalOperatorsChecks()
        {
            short firstNumber = 0, secondNumber = 5;
            bool boolVariable = true;

            if (boolVariable | (++firstNumber < 10))
                Console.WriteLine("i is equal to 1 when using the logical operator OR '|'");

            if (boolVariable || (++firstNumber < 10))
                Console.WriteLine("i is equal to 0 when using the conditional operator the logical OR '||'");

            if (firstNumber != 0 && (secondNumber % firstNumber) == 0)
                Console.WriteLine("{0} is divided entirely by {1}", secondNumber, firstNumber);

            if ((secondNumber % firstNumber) == 0 && firstNumber != 0)
                Console.WriteLine(
                    "the exception occurs because the first comparison operator contains a division by 0");

            if (firstNumber != 0 & (secondNumber % firstNumber) == 0)
                Console.WriteLine("exceptional situation will occur");
        }

        public static void RunTernaryAndOperatorsOfTypeCheck(string name) =>
            Console.WriteLine(name is null ? "null" : name as object);
    }
}