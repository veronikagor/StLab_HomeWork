using System.Linq;
using NLog;
using PhoneShop.Models;
using PhoneShop.Models.Enums;

namespace PhoneShop.Actions
{
    public class CalculationThePhoneCount
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public static void CalculateTheCountOfPhonesInShops(PhoneShops phoneShops)
        {
            foreach (var shop in phoneShops.Shops)
            {
                var countIosIsAvailableInShop = GetCountOfPhonesInShop(shop, OperationSystemType.IOS);
                log.Info(
                    $"The count of phones with IOS in {shop.Name} is {countIosIsAvailableInShop}");

                var countAndroidIsAvailableInShop = GetCountOfPhonesInShop(shop, OperationSystemType.Android);
                log.Info(
                    $"The count of phones with Android OS in {shop.Name} is {countAndroidIsAvailableInShop}");
            }
        }

        private static int GetCountOfPhonesInShop(Shop shop, OperationSystemType operationSystemType)
        {
            return shop.Phones.Count(p =>
                p.OperationSystemType.Equals(operationSystemType.ToString()) & p.IsAvailable);
        }
    }
}