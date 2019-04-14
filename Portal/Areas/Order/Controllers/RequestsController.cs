using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EfCoreGenericRepository;
using EfCoreGenericRepository.Models;

namespace Portal.Areas.Order.Controllers
{
    [Area("Order")]
    public class RequestsController : Controller
    {
        private readonly PlutoContext _context;

        public RequestsController(PlutoContext context)
        {
            _context = context;
        }

        // GET: Order/Requests
        public async Task<IActionResult> Index()
        {
            var plutoContext = _context.Requests.Include(r => r.RequestType);
            return View(await plutoContext.ToListAsync());
        }

        // GET: Order/Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.RequestType)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Order/Requests/Create
        public IActionResult Create()
        {
            ViewData["RequestTypeID"] = new SelectList(_context.RequestTypes, "id", "id");
            return View();
        }

        // POST: Order/Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EmployeeID,RequestTypeID,StatusID,CreatedDate,CreatedBy,IsDelegate,IsDelegateApprove,DelegateFromID,DelegateToID")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RequestTypeID"] = new SelectList(_context.RequestTypes, "id", "id", request.RequestTypeID);
            return View(request);
        }

        // GET: Order/Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.SingleOrDefaultAsync(m => m.ID == id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["RequestTypeID"] = new SelectList(_context.RequestTypes, "id", "id", request.RequestTypeID);
            return View(request);
        }

        // POST: Order/Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EmployeeID,RequestTypeID,StatusID,CreatedDate,CreatedBy,IsDelegate,IsDelegateApprove,DelegateFromID,DelegateToID")] Request request)
        {
            if (id != request.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.ID))
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
            ViewData["RequestTypeID"] = new SelectList(_context.RequestTypes, "id", "id", request.RequestTypeID);
            return View(request);
        }

        // GET: Order/Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.RequestType)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Order/Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.SingleOrDefaultAsync(m => m.ID == id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.ID == id);
        }
    }
}
