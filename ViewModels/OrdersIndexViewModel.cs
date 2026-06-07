using System.Collections.Generic;
using VerstaOrderPrjoect.Dtos;

namespace VerstaOrderPrjoect.ViewModels
{
    public class OrdersIndexViewModel
    {
        public IEnumerable<OrderDto>? Orders { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public int TotalPages => (int)System.Math.Ceiling((double)TotalCount / PageSize);
    }
}
