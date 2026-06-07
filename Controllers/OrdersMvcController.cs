using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VerstaOrderPrjoect.Data;
using VerstaOrderPrjoect.Dtos;
using VerstaOrderPrjoect.Models;
using VerstaOrderPrjoect.ViewModels;

namespace VerstaOrderPrjoect.Controllers
{
    public class OrdersMvcController : Controller
    {
        private readonly OrdersContext _db;
        private const int PageSize = 10;

        public OrdersMvcController(OrdersContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            if (page < 1) page = 1;

            var total = await _db.Orders.CountAsync();

            var orders = await _db.Orders
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(o => new OrderDto(
                    o.Id,
                    o.CitySender,
                    o.AddressSender,
                    o.CityRecipient,
                    o.AddressRecipient,
                    o.Weight,
                    o.PickupDate
                ))
                .ToListAsync();

            var vm = new OrdersIndexViewModel
            {
                Orders = orders,
                Page = page,
                PageSize = PageSize,
                TotalCount = total
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new OrderCreateViewModel { PickupDate = DateOnly.FromDateTime(DateTime.Now) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var order = new Order
            {
                CitySender = model.CitySender,
                AddressSender = model.AddressSender,
                CityRecipient = model.CityRecipient,
                AddressRecipient = model.AddressRecipient,
                Weight = model.Weight,
                PickupDate = model.PickupDate
            };

            _db.Orders.Add(order);

            try
            {
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(string.Empty, "Ошибка при сохранении: " + ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _db.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }
    }
}
