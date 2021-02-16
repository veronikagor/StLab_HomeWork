using System;

namespace InheritanceAndOverriding
{
    class HoneyCake : Cake
    {
        private string name = "Honey cake";
        private double SourCream { get; set; }
        private double Honey { get; set; }
        public override void CalculateTheWeightOfIngredientsForCream(double weightOfBase)
        {
            double weightOfCream = weightOfBase * 1.8;
            Sugar = weightOfCream * 0.27;
            SourCream = weightOfCream * 0.68;
            Honey = weightOfCream * 0.05;
            
            Console.WriteLine($"You need {weightOfCream}g of cream for {name}.");
        }
        public override void PrintTheWeightOfIngredientsForCream(double weightOfBase)
        {
            base.PrintTheWeightOfIngredientsForCream(weightOfBase);
            Console.WriteLine($"{Math.Round(Sugar)} g sugar,\n{Math.Round(SourCream)} g source cream,\n{Math.Round(Honey)} g honey \n");
        }
    }
}