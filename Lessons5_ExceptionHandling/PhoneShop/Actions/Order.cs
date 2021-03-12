using System;
using System.Collections.Generic;
using NLog;
using PhoneShop.Exceptions;
using PhoneShop.Models;

namespace PhoneShop.Actions
{
    public class Order
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private static string _desiredPhoneModel;

        public static Dictionary<Shop, Phone> FindShopsWithDesiredPhoneModel(PhoneShops phoneShops)
        {
            var listOfShopsWithDesiredPhoneModel = new Dictionary<Shop, Phone>();

            while (string.IsNullOrEmpty(_desiredPhoneModel))
            {
                log.Info("\nWhich phone do you want to buy?");

                _desiredPhoneModel = Console.ReadLine().Trim();

                var isPhoneModelExist = false;
                var isPhoneModelAvailable = false;

                foreach (var shop in phoneShops.Shops)
                {
                    var selectedPhone = new Phone();

                    foreach (var phone in shop.Phones)
                    {
                        if (phone.Model.Equals(_desiredPhoneModel))
                        {
                            if (phone.IsAvailable)
                            {
                                isPhoneModelAvailable = true;
                                selectedPhone = phone;
                                listOfShopsWithDesiredPhoneModel.Add(shop, selectedPhone);
                            }

                            isPhoneModelExist = true;
                        }
                    }
                }

                try
                {
                    if (IsPhoneAvailableToOrder(isPhoneModelExist, isPhoneModelAvailable))
                    {
                        foreach (var shop1 in listOfShopsWithDesiredPhoneModel.Keys)
                        {
                            log.Info($"{shop1} - {listOfShopsWithDesiredPhoneModel[shop1]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is PhoneNotFoundException || ex is PhoneNotAvailableException)
                    {
                        listOfShopsWithDesiredPhoneModel.Clear();
                        _desiredPhoneModel = null;
                        log.Info($"Please, try again.");
                    }
                }
            }

            return listOfShopsWithDesiredPhoneModel;
        }

        private static bool IsPhoneAvailableToOrder(bool isPhoneModelExist, bool isPhoneModelAvailable)
        {
            if (!isPhoneModelExist && !isPhoneModelAvailable)
            {
                log.Info($"The product you entered was not found: {_desiredPhoneModel}.");
                throw new PhoneNotFoundException($"Phone model '{_desiredPhoneModel}' is not exist.");
            }
            else if (!isPhoneModelAvailable && isPhoneModelExist)
            {
                log.Info($"This product is absent in shop: {_desiredPhoneModel}.");
                throw new PhoneNotAvailableException($"Phone model '{_desiredPhoneModel}' is absent in shop.");
            }

            return true;
        }
        
        public static void MakeOrder(Dictionary<Shop, Phone> listOfShopsWithDesiredPhoneModel)
        {
            string desiredShopName = null;

            while (string.IsNullOrEmpty(desiredShopName))
            {
                log.Info($"\nIn which shop do you want to buy {_desiredPhoneModel}?");
                try
                {
                    desiredShopName = Console.ReadLine().Trim();
                    var phoneToOrder = FindDesiredShop(listOfShopsWithDesiredPhoneModel, desiredShopName.ToUpper());

                    log.Info(
                        $"The order {phoneToOrder} for the amount {phoneToOrder.Price} has been successfully placed!");
                }
                catch (ShopNotFoundException ex)
                {
                    log.Info($"Shop '{desiredShopName}' is absent in the list. Please try again: ");
                    log.Debug($"Shop '{desiredShopName}' is absent in the list.\n{ex.StackTrace}");

                    desiredShopName = null;
                }
            }
        }
        
        private static Phone FindDesiredShop(Dictionary<Shop, Phone> listOfShopsWithDesiredPhoneModel,
            string desiredShopName)
        {
            var phoneToOrder = new Phone();

            var isShopFound = false;
            foreach (var shop in listOfShopsWithDesiredPhoneModel.Keys)
            {
                if (shop.Name.ToUpper().Equals(desiredShopName))
                {
                    isShopFound = true;
                    phoneToOrder = listOfShopsWithDesiredPhoneModel[shop];
                }

                if (!isShopFound)
                {
                    throw new ShopNotFoundException($"Shop '{desiredShopName}' is not exist.");
                }
            }

            return phoneToOrder;
        }
    }
}