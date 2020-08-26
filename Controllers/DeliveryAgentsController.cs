using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Lunch_Delivery_MVC.Data;
using Online_Lunch_Delivery_MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Lunch_Delivery_MVC.Controllers
{
    [Authorize]
    public class DeliveryAgentsController : Controller
    {
        private readonly Online_Lunch_Delivery_DBContext _context;

        public DeliveryAgentsController(Online_Lunch_Delivery_DBContext context)
        {
            _context = context;
        }

        // GET: DeliveryAgents
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeliveryAgent.ToListAsync());
        }

        // GET: DeliveryAgents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryAgent = await _context.DeliveryAgent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryAgent == null)
            {
                return NotFound();
            }

            return View(deliveryAgent);
        }

        // GET: DeliveryAgents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeliveryAgents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Mobile")] DeliveryAgent deliveryAgent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryAgent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryAgent);
        }

        // GET: DeliveryAgents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryAgent = await _context.DeliveryAgent.FindAsync(id);
            if (deliveryAgent == null)
            {
                return NotFound();
            }
            return View(deliveryAgent);
        }

        // POST: DeliveryAgents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Mobile")] DeliveryAgent deliveryAgent)
        {
            if (id != deliveryAgent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryAgent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryAgentExists(deliveryAgent.Id))
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
            return View(deliveryAgent);
        }

        // GET: DeliveryAgents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryAgent = await _context.DeliveryAgent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryAgent == null)
            {
                return NotFound();
            }

            return View(deliveryAgent);
        }

        // POST: DeliveryAgents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryAgent = await _context.DeliveryAgent.FindAsync(id);
            _context.DeliveryAgent.Remove(deliveryAgent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryAgentExists(int id)
        {
            return _context.DeliveryAgent.Any(e => e.Id == id);
        }
    }
}
