using PhoneShop.Actions;
using PhoneShop.Utils;

namespace PhoneShop
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "appsettings.json";
            var phoneShops = JsonReader.ReadTheFile(fileName);
            PhoneShopHelper.CalculateTheCountOfPhonesInShops(phoneShops);

            var listOfShopsWithDesiredPhoneModel = PhoneShopHelper.FindShopsWithDesiredPhoneModel(phoneShops);
            PhoneShopHelper.MakeOrder(listOfShopsWithDesiredPhoneModel);
        }
    }
}