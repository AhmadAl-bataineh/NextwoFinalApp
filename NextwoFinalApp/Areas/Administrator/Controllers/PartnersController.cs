using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NextwoFinalApp.Data;
using NextwoFinalApp.Models;
using Microsoft.AspNetCore.Authorization;


namespace NextwoFinalApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize]

    public class PartnersController : Controller
    {
        private readonly FinalDbContext _context;

        public PartnersController(FinalDbContext context)
        {
            _context = context;
        }

        // GET: Administrator/Partners
        public async Task<IActionResult> Index()
        {
              return _context.partners != null ? 
                          View(await _context.partners.ToListAsync()) :
                          Problem("Entity set 'FinalDbContext.partners'  is null.");
        }

        // GET: Administrator/Partners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.partners == null)
            {
                return NotFound();
            }

            var partner = await _context.partners
                .FirstOrDefaultAsync(m => m.PartnerId == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // GET: Administrator/Partners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Partners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartnerId,PartnerName,PartnerImg,CreationDate,IsPublished,IsDeleted,UserId")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partner);
        }

        // GET: Administrator/Partners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.partners == null)
            {
                return NotFound();
            }

            var partner = await _context.partners.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            return View(partner);
        }

        // POST: Administrator/Partners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartnerId,PartnerName,PartnerImg,CreationDate,IsPublished,IsDeleted,UserId")] Partner partner)
        {
            if (id != partner.PartnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerExists(partner.PartnerId))
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
            return View(partner);
        }

        // GET: Administrator/Partners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.partners == null)
            {
                return NotFound();
            }

            var partner = await _context.partners
                .FirstOrDefaultAsync(m => m.PartnerId == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // POST: Administrator/Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.partners == null)
            {
                return Problem("Entity set 'FinalDbContext.partners'  is null.");
            }
            var partner = await _context.partners.FindAsync(id);
            if (partner != null)
            {
                _context.partners.Remove(partner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerExists(int id)
        {
          return (_context.partners?.Any(e => e.PartnerId == id)).GetValueOrDefault();
        }
    }
}
