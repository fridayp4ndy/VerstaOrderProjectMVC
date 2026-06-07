using System;
using System.ComponentModel.DataAnnotations;

namespace VerstaOrderPrjoect.ViewModels
{
    public class OrderCreateViewModel
    {
        [Required]
        [Display(Name = "Город отправителя")]
        public string? CitySender { get; set; }

        [Required]
        [Display(Name = "Адрес отправителя")]
        public string? AddressSender { get; set; }

        [Required]
        [Display(Name = "Город получателя")]
        public string? CityRecipient { get; set; }

        [Required]
        [Display(Name = "Адрес получателя")]
        public string? AddressRecipient { get; set; }

        [Required]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Вес должен быть больше 0")]
        [Display(Name = "Вес (кг)")]
        public double Weight { get; set; }

        [Required]
        [Display(Name = "Дата самовывоза")]
        public DateOnly PickupDate { get; set; }
    }
}
