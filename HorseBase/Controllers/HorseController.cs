using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HorseBase.Data;
using Newtonsoft.Json;

namespace HorseBase.Controllers
{
    public class HorseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HorseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Horse
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.horses.Include(h => h.Breed);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Horse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horse = await _context.horses
                .Include(h => h.Breed)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horse == null)
            {
                return NotFound();
            }

            return View(horse);
        }

        // GET: Horse/Create
        public IActionResult Create()
        {
            ViewData["BreedId"] = new SelectList(_context.breeds, "Id", "Name");
            return View();
        }

        // POST: Horse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,BreedId,BirhtYear,Gender,Height,Price,PhotoPath")] Horse horse)
        {

            _context.Add(horse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Horse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horse = await _context.horses.FindAsync(id);
            if (horse == null)
            {
                return NotFound();
            }
            ViewData["BreedId"] = new SelectList(_context.breeds, "Id", "Name", horse.BreedId);
            return View(horse);
        }

        // POST: Horse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,BreedId,BirhtYear,Gender,Height,Price,PhotoPath")] Horse horse)
        {
            if (id != horse.Id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(horse);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorseExists(horse.Id))
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

        // GET: Horse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horse = await _context.horses
                .Include(h => h.Breed)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horse == null)
            {
                return NotFound();
            }

            return View(horse);
        }

        // POST: Horse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horse = await _context.horses.FindAsync(id);
            if (horse != null)
            {
                _context.horses.Remove(horse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorseExists(int id)
        {
            return _context.horses.Any(e => e.Id == id);
        }

        public string GetAllHorses()
        {
            return JsonConvert.SerializeObject(_context.horses.Include(x => x.Breed).ToList());
        }
    }
}
