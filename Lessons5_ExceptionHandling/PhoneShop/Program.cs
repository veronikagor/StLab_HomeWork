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

            PhoneShopHelper.PrintInfoAboutCountOfPhones(phoneShops);
            var desiredPhoneModel = PhoneShopHelper.GetPhoneModel(phoneShops);
            PhoneShopHelper.PrintPhonesAndShopsInfo(phoneShops, desiredPhoneModel);
            PhoneShopHelper.MakeOrder(phoneShops, desiredPhoneModel);
        }
    }
}