﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portal.Areas.Order.Data.Model;
using Portal.Data;

namespace Portal.Areas.Order.Controllers
{
    [Area("Order")]
    public class AmendmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AmendmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order/Amendments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Amendment.Include(a => a.AmendmentReason).Include(a => a.RequestType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Order/Amendments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amendment = await _context.Amendment
                .Include(a => a.AmendmentReason)
                .Include(a => a.RequestType)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (amendment == null)
            {
                return NotFound();
            }

            return View(amendment);
        }

        // GET: Order/Amendments/Create
        public IActionResult Create()
        {
            ViewData["AmendmentReasonId"] = new SelectList(_context.Set<AmendmentReason>(), "ID", "ID");
           // ViewData["RequestID"] = new SelectList(_context.ESS_Requests, "ID", "ID");
            return View();
        }

        // POST: Order/Amendments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DocumentID,RequestID,AmendmentReasonId,MonthYear,MonthDate,MonthDay,Description,Time,TimeIn,TimeOut,Type,FilePath,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Amendment amendment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amendment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmendmentReasonId"] = new SelectList(_context.Set<AmendmentReason>(), "ID", "ID", amendment.AmendmentReasonId);
           // ViewData["RequestID"] = new SelectList(_context.ESS_Requests, "ID", "ID", amendment.RequestID);
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
           // ViewData["RequestID"] = new SelectList(_context.ESS_Requests, "ID", "ID", amendment.RequestID);
            return View(amendment);
        }

        // POST: Order/Amendments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DocumentID,RequestID,AmendmentReasonId,MonthYear,MonthDate,MonthDay,Description,Time,TimeIn,TimeOut,Type,FilePath,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Amendment amendment)
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
           // ViewData["RequestID"] = new SelectList(_context.ESS_Requests, "ID", "ID", amendment.RequestID);
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
                .Include(a => a.RequestType)
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
