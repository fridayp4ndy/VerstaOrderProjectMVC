using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VerstaOrderPrjoect.Dtos
{
    public record OrderDto
    (
        int id,
        string citySender,
        string addressSender,
        string cityRecipient,
        string addressRecipient,
        double weight,
        DateOnly pickupDate
    );
}