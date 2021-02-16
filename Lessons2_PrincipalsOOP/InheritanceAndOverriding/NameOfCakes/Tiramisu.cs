using System;

namespace InheritanceAndOverriding
{
    public class Tiramisu : Cake
    {
        private string Name = "Tiramisu";
        private double Mascarpone { get; set; }
        private double ColdPreparedEspresso { get; set; }
        private double EggYolks { get; set; }
        private double Cocoa { get; set; }

        public override void CalculateTheWeightOfIngredientsForCream(double weightOfBase)
        {
            double weightOfCream = weightOfBase * 2.7;
            Sugar = weightOfCream * 0.08;
            Mascarpone = weightOfCream * 0.39;
            ColdPreparedEspresso = weightOfCream * 0.35;
            EggYolks = weightOfCream * 0.16 / 17;
            Cocoa = weightOfCream * 0.02;

            Console.WriteLine($"You need {weightOfCream}g of cream for {Name}.");
        }

        public override void PrintTheWeightOfIngredientsForCream(double weightOfBase)
        {
            base.PrintTheWeightOfIngredientsForCream(weightOfBase);
            Console.WriteLine(
                $"{Math.Round(Sugar)} g sugar,\n{Math.Round(Mascarpone)} g mascarpone,\n{Math.Round(Cocoa)} g cocoa,\n{Math.Round(EggYolks)} large egg yolks\n");
        }
    }
}