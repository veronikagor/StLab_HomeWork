using System;
using System.Collections.Generic;

namespace InheritanceAndOverriding
{
    /* You bought the base for the cake but do not know how much cream to put inside.
     This program will help you calculate the weight of ingredients for different types of cake.
     */
    public class RunCalculation
    {
        private static List<Cake> cakes = new List<Cake>()
        {
            new HoneyCake(),
            new NapoleonCake(TypeOfCreamForNapoleonCake.Buttery),
            new NapoleonCake(TypeOfCreamForNapoleonCake.Pastry),
            new Tiramisu()
        };

        public static double GetTheWeightOfBase()
        {
            double weightOfBase = 0.0;

            while (weightOfBase <= 0.0)
            {
                Console.WriteLine("Enter the weight of base (g)");
                if (!Double.TryParse(Console.ReadLine(), out weightOfBase))
                {
                    Console.WriteLine("This type of input value is wrong! Please try again:");
                }
            }

            return weightOfBase;
        }

        public static void Main(string[] args)
        {
            double weightOfBase = GetTheWeightOfBase();
            foreach (var cake in cakes)
            {
                cake.CalculateTheWeightOfIngredientsForCream(weightOfBase);
                cake.PrintTheWeightOfIngredientsForCream(weightOfBase);
            }
        }
    }
}