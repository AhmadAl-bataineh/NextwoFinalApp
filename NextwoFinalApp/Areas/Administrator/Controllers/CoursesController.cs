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
using NextwoFinalApp.Models.ViewModels;

namespace NextwoFinalApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly FinalDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;

        public CoursesController(FinalDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Administrator/Courses
        public async Task<IActionResult> Index()
        {
            var finalDbContext = _context.courses.Include(c => c.Category);
            return View(await finalDbContext.ToListAsync());
        }

        // GET: Administrator/Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.courses == null)
            {
                return NotFound();
            }

            var course = await _context.courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Administrator/Courses/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Administrator/Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                string ImgName = FileUpload(model);
                Course course = new Course
                {
                CourseId = model.CourseId,
                    CourseDesc = model.CourseDesc,
                    CourseTitle = model.CourseTitle,
                    CreationDate=model.CreationDate,
                    Duration=model.Duration,
                     Hours=model.Hours,
                     IsDeleted=model.IsDeleted,
                     IsPublished=model.IsPublished,
                     Price=model.Price,
                     Rate=model.Rate,
                     StartDate=model.StartDate,
                     StartTime=model.StartTime,
                     UserId= model.UserId,
                     venu=(Course.Venus)model.Venu,
                     Img = ImgName


                };

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", model.CategoryId);
            return View(model);
        }

        // GET: Administrator/Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.courses == null)
            {
                return NotFound();
            }

            var course = await _context.courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", course.CategoryId);
            return View(course);
        }

        // POST: Administrator/Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,CourseDesc,Price,Img,StartTime,Hours,venu,CategoryId,CreationDate,IsPublished,IsDeleted,UserId")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", course.CategoryId);
            return View(course);
        }

        // GET: Administrator/Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.courses == null)
            {
                return NotFound();
            }

            var course = await _context.courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Administrator/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.courses == null)
            {
                return Problem("Entity set 'FinalDbContext.courses'  is null.");
            }
            var course = await _context.courses.FindAsync(id);
            if (course != null)
            {
                _context.courses.Remove(course);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
          return (_context.courses?.Any(e => e.CourseId == id)).GetValueOrDefault();
        }
        public string FileUpload(CourseViewModel model)
        {

            return "";
        }
    }
}
