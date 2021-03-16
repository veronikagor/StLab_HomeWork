using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using PhoneShop.Exceptions;
using PhoneShop.Models;
using PhoneShop.Models.Enums;

namespace PhoneShop.Actions
{
    public class PhoneShopHelper
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private static string _desiredPhoneModel;
        private static string _desiredShopName;

        private static bool _isPhoneModelExist;
        private static bool _isPhoneModelAvailable;

        public static void CalculateTheCountOfPhonesInShops(PhoneShops phoneShops)
        {
            foreach (var shop in phoneShops.Shops)
            {
                var countIosIsAvailableInShop =
                    GetCountOfPhonesInShop(shop, OperationSystemType.IOS);
                log.Info(
                    $"The count of phones with IOS in {shop.Name} is {countIosIsAvailableInShop}");

                var countAndroidIsAvailableInShop =
                    GetCountOfPhonesInShop(shop, OperationSystemType.Android);
                log.Info(
                    $"The count of phones with Android OS in {shop.Name} is {countAndroidIsAvailableInShop}");
            }
        }

        private static int GetCountOfPhonesInShop(Shop shop, OperationSystemType operationSystemType)
        {
            return shop.Phones.Count(phone =>
                phone.OperationSystemType == operationSystemType && phone.IsAvailable);
        }

        public static Dictionary<Shop, Phone> FindShopsWithDesiredPhoneModel(PhoneShops phoneShops)
        {
            var listOfShopsWithDesiredPhoneModel = new Dictionary<Shop, Phone>();

            while (string.IsNullOrEmpty(_desiredPhoneModel))
            {
                log.Info("\nWhich phone do you want to buy?");
                _desiredPhoneModel = Console.ReadLine().Trim();

                try
                {
                    listOfShopsWithDesiredPhoneModel = GetListOfShopWithDesiredPhone(phoneShops);
                    foreach (var shop in listOfShopsWithDesiredPhoneModel.Keys)
                    {
                        log.Info($"{shop} - {listOfShopsWithDesiredPhoneModel[shop]}");
                    }
                }
                catch (Exception ex)
                {
                    if (ex is PhoneNotFoundException || ex is PhoneNotAvailableException)
                    {
                        log.Error(
                            $"There was an error when searching for the desired phone model '{_desiredPhoneModel}': {ex.Message}");
                        _desiredPhoneModel = null;
                    }
                }
            }

            return listOfShopsWithDesiredPhoneModel;
        }

        public static Dictionary<Shop, Phone> GetListOfShopWithDesiredPhone(PhoneShops phoneShops)
        {
            var listOfShopsWithDesiredPhoneModel = new Dictionary<Shop, Phone>();

            foreach (var shop in phoneShops.Shops)
            {
                foreach (var phone in shop.Phones)
                {
                    if (phone.Model.Equals(_desiredPhoneModel))
                    {
                        if (phone.IsAvailable)
                        {
                            _isPhoneModelAvailable = true;
                            listOfShopsWithDesiredPhoneModel.Add(shop, phone);
                        }

                        _isPhoneModelExist = true;
                    }
                }
            }

            ChekThatPhoneAvailableToOrder(_isPhoneModelExist, _isPhoneModelAvailable);
            return listOfShopsWithDesiredPhoneModel;
        }

        private static void ChekThatPhoneAvailableToOrder(bool isPhoneModelExist, bool isPhoneModelAvailable)
        {
            if (!isPhoneModelExist && !isPhoneModelAvailable)
            {
                log.Info($"The product you entered was not found: {_desiredPhoneModel}. Please, try again:");
                throw new PhoneNotFoundException($"Phone model '{_desiredPhoneModel}' is not exist.");
            }
            else if (!isPhoneModelAvailable && isPhoneModelExist)
            {
                log.Info($"This product is absent in shop: {_desiredPhoneModel}. Please, try again:");
                throw new PhoneNotAvailableException($"Phone model '{_desiredPhoneModel}' is absent in shop.");
            }
        }

        public static void MakeOrder(Dictionary<Shop, Phone> listOfShopsWithDesiredPhoneModel)
        {
            while (string.IsNullOrEmpty(_desiredShopName))
            {
                log.Info($"\nIn which shop do you want to buy {_desiredPhoneModel}?");
                _desiredShopName = Console.ReadLine().Trim();

                try
                {
                    if (IsFoundDesiredShop(listOfShopsWithDesiredPhoneModel))
                    {
                        var phoneToOrder = new Phone();
                        foreach (var shop in listOfShopsWithDesiredPhoneModel.Keys)
                        {
                            if (shop.Name.ToUpper().Equals(_desiredShopName.ToUpper()))
                            {
                                phoneToOrder = listOfShopsWithDesiredPhoneModel[shop];
                            }
                        }

                        log.Info(
                            $"The order {phoneToOrder} for the amount {phoneToOrder.Price} has been successfully placed!");
                    }
                }
                catch (ShopNotFoundException ex)
                {
                    log.Info($"Shop '{_desiredShopName}' is absent in the list. Please try again: ");
                    log.Error(
                        $"There was an error when searching for the desired shop '{_desiredShopName}': {ex.Message}");

                    _desiredShopName = null;
                }
            }
        }

        private static bool IsFoundDesiredShop(Dictionary<Shop, Phone> listOfShopsWithDesiredPhoneModel)
        {
            var isShopFound = false;

            foreach (var shop in listOfShopsWithDesiredPhoneModel.Keys)
            {
                if (shop.Name.ToUpper().Equals(_desiredShopName.ToUpper()))
                {
                    isShopFound = true;
                }

                if (!isShopFound)
                {
                    throw new ShopNotFoundException($"Shop '{_desiredShopName}' is not exist.");
                }
            }

            return isShopFound;
        }
    }
}