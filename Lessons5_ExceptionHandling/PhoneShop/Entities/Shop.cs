using System.Collections.Generic;

namespace PhoneShop.Entities
{
    public class Shop : PhoneShops
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<Phone> Phones { get; set; }

        public override string ToString()
        {
            return "Shop: {" +
                   "Id = '" + Id + '\'' +
                   ", Name = " + Name +
                   ", Description = " + Description +
                   '}';
        }
    }
}