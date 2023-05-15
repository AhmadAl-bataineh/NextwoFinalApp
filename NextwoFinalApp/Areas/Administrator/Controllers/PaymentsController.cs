using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NextwoFinalApp.Data;
using NextwoFinalApp.Models;

namespace NextwoFinalApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize]

    public class PaymentsController : Controller
    {
        private readonly FinalDbContext _context;

        public PaymentsController(FinalDbContext context)
        {
            _context = context;
        }

        // GET: Administrator/Payments
        public async Task<IActionResult> Index()
        {
              return _context.payments != null ? 
                          View(await _context.payments.ToListAsync()) :
                          Problem("Entity set 'FinalDbContext.payments'  is null.");
        }

        // GET: Administrator/Payments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.payments == null)
            {
                return NotFound();
            }

            var payment = await _context.payments
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Administrator/Payments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,InvoiceId,Total,IsSuccess,CreationDate,IsPublished,IsDeleted,UserId")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                payment.PaymentId = Guid.NewGuid();
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
        }

        // GET: Administrator/Payments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.payments == null)
            {
                return NotFound();
            }

            var payment = await _context.payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        // POST: Administrator/Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PaymentId,InvoiceId,Total,IsSuccess,CreationDate,IsPublished,IsDeleted,UserId")] Payment payment)
        {
            if (id != payment.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentId))
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
            return View(payment);
        }

        // GET: Administrator/Payments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.payments == null)
            {
                return NotFound();
            }

            var payment = await _context.payments
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Administrator/Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.payments == null)
            {
                return Problem("Entity set 'FinalDbContext.payments'  is null.");
            }
            var payment = await _context.payments.FindAsync(id);
            if (payment != null)
            {
                _context.payments.Remove(payment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(Guid id)
        {
          return (_context.payments?.Any(e => e.PaymentId == id)).GetValueOrDefault();
        }
    }
}
