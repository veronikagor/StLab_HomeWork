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
        private List<Shop> _shopList;
        private List<Phone> _filteredPhoneList;

        private string _desiredPhoneModel;
        private string _desiredShopName;

        private Logger log = LogManager.GetCurrentClassLogger();

        public PhoneShopHelper(PhoneShops phoneShop)
        {
            _shopList = phoneShop.Shops;
            _filteredPhoneList = new List<Phone>();
        }

        public void PrintInfoAboutCountOfPhones()
        {
            foreach (var shop in _shopList)
            {
                var countIosIsAvailableInShop = GetCountOfPhonesInShop(shop, OperationSystemType.IOS);
                log.Info(
                    $"The count of phones with IOS in {shop.Name} is {countIosIsAvailableInShop.ToString()}");

                var countAndroidIsAvailableInShop = GetCountOfPhonesInShop(shop, OperationSystemType.Android);
                log.Info(
                    $"The count of phones with Android OS in {shop.Name} is {countAndroidIsAvailableInShop.ToString()}");
            }
        }

        private int GetCountOfPhonesInShop(Shop shop, OperationSystemType operationSystemType)
        {
            return shop.Phones.Count(phone =>
                phone.OperationSystemType == operationSystemType && phone.IsAvailable);
        }

        public void FindPhonesWithDesiredPhone()
        {
            while (string.IsNullOrEmpty(_desiredPhoneModel))
            {
                log.Info("\nWhich phone do you want to buy?");
                _desiredPhoneModel = Console.ReadLine().Trim();

                try
                {
                    _filteredPhoneList = GetPhonesWithDesiredPhoneModel();
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
        }

        private List<Phone> GetPhonesWithDesiredPhoneModel()
        {
            bool isPhoneModelExist = false;
            bool isPhoneModelAvailable = false;

            foreach (var shop in _shopList)
            {
                foreach (var phone in shop.Phones.Where(phone => phone.Model.Equals(_desiredPhoneModel)))
                {
                    if (phone.IsAvailable)
                    {
                        isPhoneModelAvailable = true;
                        _filteredPhoneList.Add(phone);
                    }

                    isPhoneModelExist = true;
                }
            }

            ChekThatPhoneAvailableToOrder( isPhoneModelExist, isPhoneModelAvailable);
            return _filteredPhoneList;
        }

        private void ChekThatPhoneAvailableToOrder(bool isPhoneModelExist, bool isPhoneModelAvailable)
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

        public void PrintPhonesAndShopsInfo()
        {
            foreach (var phone in _filteredPhoneList)
            {
                log.Info($"\nInfo about phone: {phone} - {_shopList.Find(shop => shop.Phones.Contains(phone))} ");
            }
        }

        public void MakeOrder()
        {
            Shop shopToOrder;
            Phone phoneToOrder;

            while (string.IsNullOrEmpty(_desiredShopName))
            {
                log.Info($"\nIn which shop do you want to buy {_desiredPhoneModel}?");
                _desiredShopName = Console.ReadLine().Trim();

                try
                {
                    shopToOrder = GetShopToOrder();
                    phoneToOrder = GetPhoneToOrder(shopToOrder);

                    log.Info(
                        $"The order {phoneToOrder} for the amount {phoneToOrder.Price} has been successfully placed!");
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

        private Shop GetShopToOrder()
        {
            var isShopFound = false;
            Shop shopToOrder = null;

            foreach (var shop in _shopList.Where(shop => shop.Name.ToUpper().Equals(_desiredShopName.ToUpper()))
            )
            {
                isShopFound = true;
                shopToOrder = shop;
            }

            if (!isShopFound)
            {
                throw new ShopNotFoundException($"Shop '{_desiredShopName}' is not exist.");
            }

            return shopToOrder;
        }

        private Phone GetPhoneToOrder(Shop shop)
        {
            return shop.Phones.Find(phone => phone.Model.Equals(_desiredPhoneModel));
        }
    }
}