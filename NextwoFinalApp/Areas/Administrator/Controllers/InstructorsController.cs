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

    public class InstructorsController : Controller
    {
        private readonly FinalDbContext _context;

        public InstructorsController(FinalDbContext context)
        {
            _context = context;
        }

        // GET: Administrator/Instructors
        public async Task<IActionResult> Index()
        {
              return _context.instructors != null ? 
                          View(await _context.instructors.ToListAsync()) :
                          Problem("Entity set 'FinalDbContext.instructors'  is null.");
        }

        // GET: Administrator/Instructors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.instructors == null)
            {
                return NotFound();
            }

            var instructor = await _context.instructors
                .FirstOrDefaultAsync(m => m.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // GET: Administrator/Instructors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Instructors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorId,InstructorName,InstructorImg,Position,FB,Tw,LinkedIn,CreationDate,IsPublished,IsDeleted,UserId")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        // GET: Administrator/Instructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.instructors == null)
            {
                return NotFound();
            }

            var instructor = await _context.instructors.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        // POST: Administrator/Instructors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorId,InstructorName,InstructorImg,Position,FB,Tw,LinkedIn,CreationDate,IsPublished,IsDeleted,UserId")] Instructor instructor)
        {
            if (id != instructor.InstructorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(instructor.InstructorId))
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
            return View(instructor);
        }

        // GET: Administrator/Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.instructors == null)
            {
                return NotFound();
            }

            var instructor = await _context.instructors
                .FirstOrDefaultAsync(m => m.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Administrator/Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.instructors == null)
            {
                return Problem("Entity set 'FinalDbContext.instructors'  is null.");
            }
            var instructor = await _context.instructors.FindAsync(id);
            if (instructor != null)
            {
                _context.instructors.Remove(instructor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorExists(int id)
        {
          return (_context.instructors?.Any(e => e.InstructorId == id)).GetValueOrDefault();
        }
    }
}
