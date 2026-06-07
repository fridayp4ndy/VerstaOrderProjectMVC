using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VerstaOrderPrjoect.Dtos
{
    public record OrderCreateDto
    (
        [Required] string citySender,
        [Required] string addressSender,
        [Required] string cityRecipient,
        [Required] string addressRecipient,
        [Required] [Range(0f, double.MaxValue)] double weight,
        [Required] DateOnly pickupDate
    );
}