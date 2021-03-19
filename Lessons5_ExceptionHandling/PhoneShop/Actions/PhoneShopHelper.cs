using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using PhoneShop.Exceptions;
using PhoneShop.Models;
using PhoneShop.Models.Enums;

namespace PhoneShop.Actions
{
    public static class PhoneShopHelper
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public static void PrintInfoAboutCountOfPhones(PhoneShops phoneShops)
        {
            foreach (var shop in phoneShops.Shops)
            {
                GetCountOfPhonesInShop(shop, OperationSystemType.IOS);
                GetCountOfPhonesInShop(shop, OperationSystemType.Android);
            }
        }

        private static void GetCountOfPhonesInShop(Shop shop, OperationSystemType operationSystemType)
        {
            var countAvailablePhones = shop.Phones.Count(phone =>
                phone.OperationSystemType == operationSystemType && phone.IsAvailable);

            log.Info(
                $"The count of phones with {operationSystemType} in {shop.Name} is {countAvailablePhones.ToString()}");
        }

        public static string GetPhoneModel(PhoneShops phoneShops)
        {
            string desiredPhoneModel = null;

            while (string.IsNullOrEmpty(desiredPhoneModel))
            {
                log.Info("\nWhich phone do you want to buy?");
                desiredPhoneModel = Console.ReadLine().Trim();

                try
                {
                    GetPhonesWithDesiredPhoneModel(phoneShops, desiredPhoneModel);
                }
                catch (Exception ex)
                {
                    if (ex is PhoneNotFoundException || ex is PhoneNotAvailableException)
                    {
                        log.Error(
                            $"There was an error when searching for the desired phone model '{desiredPhoneModel}': {ex.Message}");
                        desiredPhoneModel = null;
                    }
                }
            }

            return desiredPhoneModel;
        }

        private static List<Phone> GetPhonesWithDesiredPhoneModel(PhoneShops phoneShops, string desiredPhoneModel)
        {
            var isPhoneModelExist = false;
            var isPhoneModelAvailable = false;
            var filteredPhoneList = new List<Phone>();

            foreach (var shop in phoneShops.Shops)
            {
                foreach (var phone in shop.Phones.Where(phone =>
                    phone.Model.Equals(desiredPhoneModel, StringComparison.OrdinalIgnoreCase)))
                {
                    if (phone.IsAvailable)
                    {
                        isPhoneModelAvailable = true;
                        filteredPhoneList.Add(phone);
                    }

                    isPhoneModelExist = true;
                }
            }

            ChekThatPhoneAvailableToOrder(isPhoneModelExist, isPhoneModelAvailable, desiredPhoneModel);
            return filteredPhoneList;
        }

        private static void ChekThatPhoneAvailableToOrder(bool isPhoneModelExist, bool isPhoneModelAvailable,
            string desiredPhoneModel)
        {
            if (!isPhoneModelExist)
            {
                log.Info($"The product you entered was not found: {desiredPhoneModel}. Please, try again:");
                throw new PhoneNotFoundException($"Phone model '{desiredPhoneModel}' is not exist.");
            }

            if (isPhoneModelAvailable) return;
            log.Info($"This product is absent in shop: {desiredPhoneModel}. Please, try again:");
            throw new PhoneNotAvailableException($"Phone model '{desiredPhoneModel}' is absent in shop.");
        }

        public static void PrintPhonesAndShopsInfo(PhoneShops phoneShops, string desiredPhoneModel)
        {
            var filteredPhoneList = GetPhonesWithDesiredPhoneModel(phoneShops, desiredPhoneModel);

            foreach (var phone in filteredPhoneList)
            {
                log.Info($"\nInfo about phone: {phone} - {phoneShops.Shops.Find(shop => shop.Phones.Contains(phone))}");
            }
        }

        public static void MakeOrder(PhoneShops phoneShops, string desiredPhoneModel)
        {
            string desiredShopName = null;
            while (string.IsNullOrEmpty(desiredShopName))
            {
                log.Info($"\nIn which shop do you want to buy {desiredPhoneModel}?");
                desiredShopName = Console.ReadLine().Trim();

                try
                {
                    var shopToOrder = GetShopToOrder(phoneShops, desiredShopName);
                    var phoneToOrder = GetPhoneToOrder(shopToOrder, desiredPhoneModel);

                    log.Info(
                        $"The order {phoneToOrder} for the amount {phoneToOrder.Price} has been successfully placed!");
                }
                catch (ShopNotFoundException ex)
                {
                    log.Info($"Shop '{desiredShopName}' is absent in the list. Please try again: ");
                    log.Error(
                        $"There was an error when searching for the desired shop '{desiredShopName}': {ex.Message}");

                    desiredShopName = null;
                }
            }
        }

        private static Shop GetShopToOrder(PhoneShops phoneShops, string desiredShopName)
        {
            var isShopFound = false;
            Shop shopToOrder = null;

            foreach (var shop in phoneShops.Shops.Where(shop =>
                shop.Name.Equals(desiredShopName, StringComparison.OrdinalIgnoreCase)))
            {
                isShopFound = true;
                shopToOrder = shop;
            }

            if (!isShopFound)
            {
                throw new ShopNotFoundException($"Shop '{desiredShopName}' is not exist.");
            }

            return shopToOrder;
        }

        private static Phone GetPhoneToOrder(Shop shop, string desiredPhoneModel)
        {
            return shop.Phones.Find(phone => phone.Model.Equals(desiredPhoneModel, StringComparison.OrdinalIgnoreCase));
        }
    }
}