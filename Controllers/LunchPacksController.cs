using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Lunch_Delivery_MVC.Data;
using Online_Lunch_Delivery_MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Lunch_Delivery_MVC.Controllers
{
    public class LunchPacksController : Controller
    {
        private readonly Online_Lunch_Delivery_DBContext _context;

        public LunchPacksController(Online_Lunch_Delivery_DBContext context)
        {
            _context = context;
        }

        // GET: LunchPacks
        public async Task<IActionResult> Index()
        {
            return View(await _context.LunchPack.ToListAsync());
        }

        // GET: LunchPacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lunchPack = await _context.LunchPack
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lunchPack == null)
            {
                return NotFound();
            }

            return View(lunchPack);
        }
        [Authorize]
        // GET: LunchPacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LunchPacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Price")] LunchPack lunchPack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lunchPack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lunchPack);
        }
        [Authorize]
        // GET: LunchPacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lunchPack = await _context.LunchPack.FindAsync(id);
            if (lunchPack == null)
            {
                return NotFound();
            }
            return View(lunchPack);
        }

        // POST: LunchPacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Price")] LunchPack lunchPack)
        {
            if (id != lunchPack.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lunchPack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LunchPackExists(lunchPack.Id))
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
            return View(lunchPack);
        }
        [Authorize]
        // GET: LunchPacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lunchPack = await _context.LunchPack
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lunchPack == null)
            {
                return NotFound();
            }

            return View(lunchPack);
        }

        // POST: LunchPacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lunchPack = await _context.LunchPack.FindAsync(id);
            _context.LunchPack.Remove(lunchPack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LunchPackExists(int id)
        {
            return _context.LunchPack.Any(e => e.Id == id);
        }
    }
}
