using System.Linq;
using NLog;
using PhoneShop.Utils;

namespace PhoneShop.Actions
{
    public class CalculationThePhoneCount
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public static void CalculateTheCountOfPhones(string operationSystemType, string filename)
        {
            var phoneShops = FileReader.ReadTheFile(filename);

            const string operationSystemIos = "IOS";
            const string operationSystemAndroid = "ANDROID";

            foreach (var shop in phoneShops.Shops)
            {
                switch (operationSystemType.ToUpper())
                {
                    case operationSystemIos:
                        var countIosIsAvailableInShop = 0;
                        countIosIsAvailableInShop = shop.Phones.Count(p =>
                            p.OperationSystemType.Equals(operationSystemIos) & p.IsAvailable);

                        log.Info(
                            $"The count of phones with IOS in {shop.Name} is {countIosIsAvailableInShop}");
                        break;

                    case operationSystemAndroid:
                        var countAndroidIsAvailableInShop = shop.Phones.Count(p =>
                            p.OperationSystemType.Equals(operationSystemAndroid) & p.IsAvailable);

                        log.Info(
                            $"The count of phones with Android OS in {shop.Name} is {countAndroidIsAvailableInShop}");
                        break;

                    default:
                        log.Warn($"Invalid OS type: {operationSystemType} in the shop: {shop.Name}");
                        break;
                }
            }
        }
    }
}