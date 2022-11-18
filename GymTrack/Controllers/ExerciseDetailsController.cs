using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymTrack.Data;
using GymTrack.Models;
using Microsoft.AspNetCore.Authorization;

namespace GymTrack.Controllers
{
    [Authorize]
    public class ExerciseDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExerciseDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExerciseDetails
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExerciseDetail.Include(e => e.Exercise);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExerciseDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExerciseDetail == null)
            {
                return NotFound();
            }

            var exerciseDetail = await _context.ExerciseDetail
                .Include(e => e.Exercise)
                .FirstOrDefaultAsync(m => m.ExerciseDetailId == id);
            if (exerciseDetail == null)
            {
                return NotFound();
            }

            return View(exerciseDetail);
        }

        // GET: ExerciseDetails/Create
        public IActionResult Create()
        {
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "ExerciseId", "ExerciseId");
            return View();
        }

        // POST: ExerciseDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseDetailId,ExerciseId,Sets,Reps,Weight")] ExerciseDetail exerciseDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exerciseDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "ExerciseId", "ExerciseId", exerciseDetail.ExerciseId);
            return View(exerciseDetail);
        }

        // GET: ExerciseDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExerciseDetail == null)
            {
                return NotFound();
            }

            var exerciseDetail = await _context.ExerciseDetail.FindAsync(id);
            if (exerciseDetail == null)
            {
                return NotFound();
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "ExerciseId", "ExerciseId", exerciseDetail.ExerciseId);
            return View(exerciseDetail);
        }

        // POST: ExerciseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseDetailId,ExerciseId,Sets,Reps,Weight")] ExerciseDetail exerciseDetail)
        {
            if (id != exerciseDetail.ExerciseDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exerciseDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseDetailExists(exerciseDetail.ExerciseDetailId))
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
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "ExerciseId", "ExerciseId", exerciseDetail.ExerciseId);
            return View(exerciseDetail);
        }

        // GET: ExerciseDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExerciseDetail == null)
            {
                return NotFound();
            }

            var exerciseDetail = await _context.ExerciseDetail
                .Include(e => e.Exercise)
                .FirstOrDefaultAsync(m => m.ExerciseDetailId == id);
            if (exerciseDetail == null)
            {
                return NotFound();
            }

            return View(exerciseDetail);
        }

        // POST: ExerciseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExerciseDetail == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ExerciseDetail'  is null.");
            }
            var exerciseDetail = await _context.ExerciseDetail.FindAsync(id);
            if (exerciseDetail != null)
            {
                _context.ExerciseDetail.Remove(exerciseDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseDetailExists(int id)
        {
          return _context.ExerciseDetail.Any(e => e.ExerciseDetailId == id);
        }
    }
}
