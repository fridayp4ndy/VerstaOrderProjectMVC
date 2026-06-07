using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VerstaOrderPrjoect.Models;

namespace VerstaOrderPrjoect.Data
{
    public class OrdersContext (DbContextOptions<OrdersContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders => Set<Order>();
    }
}