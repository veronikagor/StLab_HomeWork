using PhoneShop.Models.Enums;

namespace PhoneShop.Models
{
    public class Phone
    {
        public string Model { get; set; }

        public OperationSystemType OperationSystemType { get; set; }

        public string MarketLaunchDate { get; set; }

        public string Price { get; set; }

        public bool IsAvailable { get; set; }


        public override string ToString()
        {
            return
                " \n Phone: {" +
                "Model = " + Model +
                ", OperationSystemType = " + OperationSystemType +
                ", MarketLaunchDate = " + MarketLaunchDate +
                ", Price = " + Price +
                '}';
        }
    }
}