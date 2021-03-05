using System;
using System.Collections.Generic;
using NLog;
using PhoneShop.Entities;
using PhoneShop.Exceptions;
using PhoneShop.Utils;

namespace PhoneShop.Actions
{
    public class Order
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private static string _desiredPhoneModel;

        public static Dictionary<Shop, Phone> FindShopsWithDesiredPhoneModel(string fileName)
        {
            PhoneShops phoneShops = FileReader.ReadTheFile(fileName);

            Dictionary<Shop, Phone> listOfShopsWithDesiredPhoneModel = new Dictionary<Shop, Phone>();

            while (string.IsNullOrEmpty(_desiredPhoneModel))
            {
                log.Info("\nWhich phone do you want to buy?");

                _desiredPhoneModel = Console.ReadLine().Trim();

                bool isPhoneModelExist = false;
                bool isPhoneModelAvailable = false;

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
                            }

                            isPhoneModelExist = true;
                        }
                    }

                    listOfShopsWithDesiredPhoneModel.Add(shop, selectedPhone);
                }

                if (!isPhoneModelExist && !isPhoneModelAvailable)
                {
                    log.Info($"The product you entered was not found: {_desiredPhoneModel}.");
                    listOfShopsWithDesiredPhoneModel.Clear();
                    _desiredPhoneModel = null;
                }
                else if (!isPhoneModelAvailable && isPhoneModelExist)
                {
                    log.Info($"This product is absent in shop: {_desiredPhoneModel}.");
                    listOfShopsWithDesiredPhoneModel.Clear();
                    _desiredPhoneModel = null;
                }
                else
                {
                    foreach (var shop in listOfShopsWithDesiredPhoneModel.Keys)
                    {
                        log.Info($"{shop} - {listOfShopsWithDesiredPhoneModel[shop]}");
                    }
                }
            }

            return listOfShopsWithDesiredPhoneModel;
        }

        public static void MakeOrder(Dictionary<Shop, Phone> listOfShopsWithDesiredPhoneModel)
        {
            string desiredShopName = null;

            while (string.IsNullOrEmpty(desiredShopName))
            {
                log.Info($"\nIn which shop do you want to buy {_desiredPhoneModel}?");
                try
                {
                    desiredShopName = Console.ReadLine().Trim().ToUpper();
                    var phoneToOrder = FindDesiredShop(listOfShopsWithDesiredPhoneModel, desiredShopName);

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
            bool isShopFound = false;

            foreach (Shop shop in listOfShopsWithDesiredPhoneModel.Keys)
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