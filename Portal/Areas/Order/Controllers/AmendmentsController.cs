using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portal.Areas.Order.Data.Interfaces;
using Portal.Areas.Order.Data.Model;
using Portal.Data;

namespace Portal.Areas.Order.Controllers
{
    [Area("Order")]
    public class AmendmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRequestRepository _requestRepository;
        private readonly IAmendmentRepository _amendmentRepository;

        public AmendmentsController(ApplicationDbContext context, IRequestRepository requestRepository, IAmendmentRepository amendmentRepository)
        {
            _context = context;
            _requestRepository = requestRepository;
            _amendmentRepository = amendmentRepository;
        }

        // GET: Order/Amendments
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Amendment.Include(a => a.AmendmentReason).Include(a => a.Request) ;
            //return View(await applicationDbContext.ToListAsync());

            IEnumerable<Amendment> amendments = null;
            HttpResponseMessage result = GlobalVaribales.WebApiClient.GetAsync("Amendments").Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IEnumerable<Amendment>>();
                readTask.Wait();

                amendments = readTask.Result;
            }
            else //web api sent error response 
            { 
                amendments = Enumerable.Empty<Amendment>(); 
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            } 
            return View(amendments);

        }

        // GET: Order/Amendments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            } 
            Amendment amendment = null;
            HttpResponseMessage result = GlobalVaribales.WebApiClient.GetAsync("Amendments/" + id.ToString()).Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Amendment>();
                readTask.Wait();

                amendment = readTask.Result;
            }
            return View( amendment);
        }

        // GET: Order/Amendments/Create
        public IActionResult Create()
        {
            ViewData["AmendmentReasonId"] = new SelectList(_context.Set<AmendmentReason>(), "ID", "AmendReasonEn");
            //ViewData["RequestID"] = new SelectList(_context.Requests, "ID", "ID");
            //ViewData["RequestTypeID"] = new SelectList(_context.RequestType, "id", "id");
            return View();
        }

        // POST: Order/Amendments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Amendment amendment)
        {
            if (ModelState.IsValid)
            {
                Request request = new Request();
                request.RequestTypeID = 5;
                request.StatusID = 1;
                request.EmployeeID = 1;
                request.Amendments = new List<Amendment>();
               // request.Amendments.Add(new Amendment());
                request.Amendments.Add(amendment);

                var postTask = GlobalVaribales.WebApiClient.PostAsJsonAsync("Amendments", request);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Message"] = "تم الحفظ  !";
                    return RedirectToAction("Index");
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["AmendmentReasonId"] = new SelectList(_context.Set<AmendmentReason>(), "ID", "AmendReasonEn", amendment.AmendmentReasonId);
            //ViewData["RequestID"] = new SelectList(_context.Requests, "ID", "ID", amendment.RequestID);
            //ViewData["RequestTypeID"] = new SelectList(_context.RequestType, "id", "id", amendment.RequestTypeID);
            return View(amendment);
        }

        // GET: Order/Amendments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amendment = await _context.Amendment.SingleOrDefaultAsync(m => m.ID == id);
            if (amendment == null)
            {
                return NotFound();
            }
            ViewData["AmendmentReasonId"] = new SelectList(_context.Set<AmendmentReason>(), "ID", "ID", amendment.AmendmentReasonId);
            ViewData["RequestID"] = new SelectList(_context.Requests, "ID", "ID", amendment.RequestID);
            
            return View(amendment);
        }

        // POST: Order/Amendments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Type,AmendmentReasonId,MonthYear,MonthDate,MonthDay,Description,Time,TimeIn,TimeOut,FilePath,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,RequestID,RequestTypeID")] Amendment amendment)
        {
            if (id != amendment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amendment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmendmentExists(amendment.ID))
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
            ViewData["AmendmentReasonId"] = new SelectList(_context.Set<AmendmentReason>(), "ID", "ID", amendment.AmendmentReasonId);
            ViewData["RequestID"] = new SelectList(_context.Requests, "ID", "ID", amendment.RequestID);
             
            return View(amendment);
        }

        // GET: Order/Amendments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amendment = await _context.Amendment
                .Include(a => a.AmendmentReason)
                .Include(a => a.Request)
                 
                .SingleOrDefaultAsync(m => m.ID == id);
            if (amendment == null)
            {
                return NotFound();
            }

            return View(amendment);
        }

        // POST: Order/Amendments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amendment = await _context.Amendment.SingleOrDefaultAsync(m => m.ID == id);
            _context.Amendment.Remove(amendment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmendmentExists(int id)
        {
            return _context.Amendment.Any(e => e.ID == id);
        }
    }
}
