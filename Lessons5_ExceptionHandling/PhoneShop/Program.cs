using PhoneShop.Actions;
using PhoneShop.Utils;

namespace PhoneShop
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "appsettings.json";
            var phoneShops = FileReading.ReadTheFile(fileName);
            CalculationThePhoneCount.CalculateTheCountOfPhonesInShops(phoneShops);
            var listOfShopsWithDesiredPhoneModel = Order.FindShopsWithDesiredPhoneModel(phoneShops);
            Order.MakeOrder(listOfShopsWithDesiredPhoneModel);
        }
    }
}