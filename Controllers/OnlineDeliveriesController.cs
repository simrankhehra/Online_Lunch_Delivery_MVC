using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Lunch_Delivery_MVC.Data;
using Online_Lunch_Delivery_MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Lunch_Delivery_MVC.Controllers
{
    [Authorize]
    public class OnlineDeliveriesController : Controller
    {
        private readonly Online_Lunch_Delivery_DBContext _context;

        public OnlineDeliveriesController(Online_Lunch_Delivery_DBContext context)
        {
            _context = context;
        }

        // GET: OnlineDeliveries
        public async Task<IActionResult> Index()
        {
            var online_Lunch_Delivery_DBContext = _context.OnlineDelivery.Include(o => o.Customer).Include(o => o.DeliveryAgent).Include(o => o.LunchPack);
            return View(await online_Lunch_Delivery_DBContext.ToListAsync());
        }

        // GET: OnlineDeliveries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlineDelivery = await _context.OnlineDelivery
                .Include(o => o.Customer)
                .Include(o => o.DeliveryAgent)
                .Include(o => o.LunchPack)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (onlineDelivery == null)
            {
                return NotFound();
            }

            return View(onlineDelivery);
        }

        // GET: OnlineDeliveries/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id");
            ViewData["DeliveryAgentId"] = new SelectList(_context.DeliveryAgent, "Id", "Id");
            ViewData["LunchPackId"] = new SelectList(_context.LunchPack, "Id", "Id");
            return View();
        }

        // POST: OnlineDeliveries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeliveryAgentId,LunchPackId,CustomerId,NumberOfPacks,Address")] OnlineDelivery onlineDelivery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(onlineDelivery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", onlineDelivery.CustomerId);
            ViewData["DeliveryAgentId"] = new SelectList(_context.DeliveryAgent, "Id", "Id", onlineDelivery.DeliveryAgentId);
            ViewData["LunchPackId"] = new SelectList(_context.LunchPack, "Id", "Id", onlineDelivery.LunchPackId);
            return View(onlineDelivery);
        }

        // GET: OnlineDeliveries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlineDelivery = await _context.OnlineDelivery.FindAsync(id);
            if (onlineDelivery == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", onlineDelivery.CustomerId);
            ViewData["DeliveryAgentId"] = new SelectList(_context.DeliveryAgent, "Id", "Id", onlineDelivery.DeliveryAgentId);
            ViewData["LunchPackId"] = new SelectList(_context.LunchPack, "Id", "Id", onlineDelivery.LunchPackId);
            return View(onlineDelivery);
        }

        // POST: OnlineDeliveries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeliveryAgentId,LunchPackId,CustomerId,NumberOfPacks,Address")] OnlineDelivery onlineDelivery)
        {
            if (id != onlineDelivery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onlineDelivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnlineDeliveryExists(onlineDelivery.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", onlineDelivery.CustomerId);
            ViewData["DeliveryAgentId"] = new SelectList(_context.DeliveryAgent, "Id", "Id", onlineDelivery.DeliveryAgentId);
            ViewData["LunchPackId"] = new SelectList(_context.LunchPack, "Id", "Id", onlineDelivery.LunchPackId);
            return View(onlineDelivery);
        }

        // GET: OnlineDeliveries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlineDelivery = await _context.OnlineDelivery
                .Include(o => o.Customer)
                .Include(o => o.DeliveryAgent)
                .Include(o => o.LunchPack)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (onlineDelivery == null)
            {
                return NotFound();
            }

            return View(onlineDelivery);
        }

        // POST: OnlineDeliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var onlineDelivery = await _context.OnlineDelivery.FindAsync(id);
            _context.OnlineDelivery.Remove(onlineDelivery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnlineDeliveryExists(int id)
        {
            return _context.OnlineDelivery.Any(e => e.Id == id);
        }
    }
}
