using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VerstaOrderPrjoect.Data;
using VerstaOrderPrjoect.Dtos;
using VerstaOrderPrjoect.Models;

namespace VerstaOrderPrjoect.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController
    {
        [HttpGet]
        public async Task<Results<Ok<List<OrderDto>>, NotFound>> GetOrders(int pageNum, int lineCount, OrdersContext dbContext)
        {
            var orders = await dbContext.Orders
            .AsNoTracking()
            .Select(order => 
                new OrderDto
                (
                    order.Id, 
                    order.CitySender, 
                    order.AddressSender, 
                    order.CityRecipient, 
                    order.AddressRecipient, 
                    order.Weight, 
                    order.PickupDate
                ))
            .Skip(pageNum * lineCount)
            .Take(lineCount)
            .ToListAsync<OrderDto>();

            return orders.Count == 0 ? TypedResults.NotFound() : TypedResults.Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<Results<Ok<OrderDto>, NotFound>> GetOrderId(int id, OrdersContext dbContext)
        {
            var order = await dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(order => order.Id == id);

            if (order != null)
            {
                var orderDto = new OrderDto
                (
                    order.Id, 
                    order.CitySender, 
                    order.AddressSender, 
                    order.CityRecipient, 
                    order.AddressRecipient, 
                    order.Weight, 
                    order.PickupDate
                );

                return TypedResults.Ok(orderDto);
            }

            return TypedResults.NotFound();
        }

        [HttpPost]
        public async Task<Results<Created<OrderDto>, BadRequest>> CreateOrder(OrderCreateDto orderCreateDto, OrdersContext dbContext)
        {
            var order = new Order
            {
                CitySender = orderCreateDto.citySender,
                AddressSender = orderCreateDto.addressSender,
                CityRecipient = orderCreateDto.cityRecipient,
                AddressRecipient = orderCreateDto.addressRecipient,
                Weight = orderCreateDto.weight,
                PickupDate = orderCreateDto.pickupDate
            };

            dbContext.Orders.Add(order);

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error while creating order: {ex.Message}");
                return TypedResults.BadRequest();
            }

            var returnOrderDto = new OrderDto
            (
                order.Id,
                order.CitySender,
                order.AddressSender,
                order.CityRecipient,
                order.AddressRecipient,
                order.Weight,
                order.PickupDate
            );

            return TypedResults.Created($"/Orders/{order.Id}", returnOrderDto);
        }
    }
}