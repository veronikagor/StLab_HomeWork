using System;

namespace InheritanceAndOverriding
{
    public abstract class Cake
    {
        private protected static double Sugar { get; set; }

        public virtual void CalculateTheWeightOfIngredientsForCream(double weightOfBase)
        {
        }

        public virtual void PrintTheWeightOfIngredientsForCream(double weightOfBase) =>
            Console.WriteLine("Ingredients: \n");
    }
}