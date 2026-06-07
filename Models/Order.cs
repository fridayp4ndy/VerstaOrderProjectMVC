using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerstaOrderPrjoect.Models
{
    public class Order
    {
        private double weight;

        public int Id {get; set;}
        public required string CitySender {get; set;}
        public required string AddressSender {get; set;}
        public required string CityRecipient {get; set;}
        public required string AddressRecipient {get; set;}
        public required double Weight
        {
            get => weight;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Weight), "Вес груза должен быть больше 0.");
                }

                weight = value;
            }
        }

        public required DateOnly PickupDate {get; set;}
    }
}