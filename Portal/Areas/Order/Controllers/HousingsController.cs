using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EfCoreGenericRepository;
using EfCoreGenericRepository.Models;
using Portal.ViewModel;

namespace Portal.Areas.Order.Controllers
{
    [Area("Order")]
    public class HousingsController : Controller
    {
        private readonly PlutoContext _context;

        public HousingsController(PlutoContext context)
        {
            _context = context;
        }

        // GET: Order/Housings
        public async Task<IActionResult> Index()
        {
            //var plutoContext = _context.Housings.Include(h => h.Request);
            //return View(await plutoContext.ToListAsync());

            return View();
        }

        // GET: Order/Housings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housing = await _context.Housings
                .Include(h => h.Request)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (housing == null)
            {
                return NotFound();
            }

            return View(housing);
        }

        // GET: Order/Housings/Create
        public IActionResult Create()
        {
            ViewData["RequestID"] = new SelectList(_context.Requests, "ID", "ID");
            var HousingVM = new HousingViewModel();
            //{

            //};
            return View(HousingVM);
        }

        // POST: Order/Housings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HousingViewModel housingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(housingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RequestID"] = new SelectList(_context.Requests, "ID", "ID", housingModel.Housing.RequestID);
            return View(housingModel);
        }

        // GET: Order/Housings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housing = await _context.Housings.SingleOrDefaultAsync(m => m.ID == id);
            if (housing == null)
            {
                return NotFound();
            }
            ViewData["RequestID"] = new SelectList(_context.Requests, "ID", "ID", housing.RequestID);
            return View(housing);
        }

        // POST: Order/Housings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HouseingDetails,StartDate,EndDate,TotalAmount,MonthlyInstallment,NoOfInstallment,ContractPeriod,LoanStartDate,LOANTYPECODE,RequestID")] Housing housing)
        {
            if (id != housing.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(housing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HousingExists(housing.ID))
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
            ViewData["RequestID"] = new SelectList(_context.Requests, "ID", "ID", housing.RequestID);
            return View(housing);
        }

        // GET: Order/Housings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housing = await _context.Housings
                .Include(h => h.Request)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (housing == null)
            {
                return NotFound();
            }

            return View(housing);
        }

        // POST: Order/Housings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var housing = await _context.Housings.SingleOrDefaultAsync(m => m.ID == id);
            _context.Housings.Remove(housing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HousingExists(int id)
        {
            return _context.Housings.Any(e => e.ID == id);
        }
    }
}
