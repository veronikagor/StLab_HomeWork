using System;

namespace InheritanceAndOverriding
{
    public class NapoleonCake : Cake
    {
        private string name = "Napoleon cake";
        private TypeOfCreamForNapoleonCake TypeOfCreamForNapoleonCake { get; }
        private static double Butter { get; set; }
        private static double Milk { get; set; }
        private static double EggYolks { get; set; }

        public NapoleonCake(TypeOfCreamForNapoleonCake typeOfCreamForNapoleonCake)
        {
            TypeOfCreamForNapoleonCake = typeOfCreamForNapoleonCake;
        }

        public override void CalculateTheWeightOfIngredientsForCream(double weightOfBase)
        {
            double weightOfCream;
            switch (TypeOfCreamForNapoleonCake)
            {
                case TypeOfCreamForNapoleonCake.Pastry:
                    weightOfCream = weightOfBase * 3;
                    Sugar = weightOfCream * 0.19;
                    Butter = weightOfCream * 0.26;
                    Milk = weightOfCream * 0.52;
                    EggYolks = weightOfCream * 0.03 / 17;

                    Console.WriteLine(
                        $"You need {weightOfCream}g of cream for {name} with {nameof(TypeOfCreamForNapoleonCake.Pastry).ToLower()} cream.");
                    break;

                case TypeOfCreamForNapoleonCake.Buttery:
                    weightOfCream = weightOfBase * 2.5;
                    Sugar = weightOfCream * 0.17;
                    Butter = weightOfCream * 0.33;
                    Milk = weightOfCream * 0.5;

                    Console.WriteLine(
                        $"You need {weightOfCream}g of cream for {name} with {nameof(TypeOfCreamForNapoleonCake.Buttery).ToLower()} cream.");
                    break;

                default: throw new ArgumentException("Invalid type of cream");
            }
        }

        public override void PrintTheWeightOfIngredientsForCream(double weightOfBase)
        {
            base.PrintTheWeightOfIngredientsForCream(weightOfBase);
            switch (TypeOfCreamForNapoleonCake)
            {
                case TypeOfCreamForNapoleonCake.Pastry:
                    Console.WriteLine(
                        $"{Math.Round(Sugar)} g sugar,\n{Math.Round(Butter)} g butter,\n{Math.Round(Milk)} g milk,\n{Math.Round(EggYolks)} large egg yolks\n");
                    break;
                case TypeOfCreamForNapoleonCake.Buttery:
                    Console.WriteLine(
                    $"{Math.Round(Sugar)} g sugar,\n{Math.Round(Butter)} g butter,\n{Math.Round(Milk)} g milk\n");
                    break;
                default: throw new ArgumentException("Invalid type of cream");
            }
        }
    }
}