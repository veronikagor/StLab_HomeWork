namespace Lessons1_VariablesAndOperators
{
    public class Runner
    {
        static void Main(string[] args)
        {
            InitializationOfVariables.InitializeVariables();

            /* RunCalculator for checking arithmetic operations */
            UsingOfOperators.RunCalculator();

            /* 'Guess the Number' game for checking increment and decrement operations */
            UsingOfOperators.RunGuessTheNumberGame();

            /* 'Do I need to retire?' To check logical operators */
            UsingOfOperators.CheckAgeToRetire(62, "f");

            /* The difference between using shortened and conditional logical operators */
            UsingOfOperators.RunLogicalOperatorsChecks();

            /* The using of ternary and operators of the type checking */
            UsingOfOperators.RunTernaryAndOperatorsOfTypeCheck("veronika");
        }
    }
}