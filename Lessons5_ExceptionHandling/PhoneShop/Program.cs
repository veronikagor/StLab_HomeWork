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

            var phoneShopHelper = new PhoneShopHelper(phoneShops);

            phoneShopHelper.PrintInfoAboutCountOfPhones();
            phoneShopHelper.FindPhonesWithDesiredPhone();
            phoneShopHelper.PrintPhonesAndShopsInfo();
            phoneShopHelper.MakeOrder();
        }
    }
}