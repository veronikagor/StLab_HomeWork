using PhoneShop.Actions;

namespace PhoneShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "appsettings.json";

            CalculationThePhoneCount.CalculateTheCountOfPhones("IOS", fileName);
            var listOfShopsWithDesiredPhoneModel = Order.FindShopsWithDesiredPhoneModel(fileName);
            Order.MakeOrder(listOfShopsWithDesiredPhoneModel);
        }
    }
}