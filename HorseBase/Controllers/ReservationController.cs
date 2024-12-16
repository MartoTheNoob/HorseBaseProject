using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HorseBase.Models;
using System.Linq;
using System.Threading.Tasks;
using HorseBase.Data;

namespace HorseBase.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservation/Create
        public async Task<IActionResult> Create(int horseId)
        {
            var horse = await _context.horses.FindAsync(horseId);
            if (horse == null)
            {
                return NotFound();
            }

            var reservation = new Reservation
            {
                Horse = horse,
                Price = 0 // Initial value, dynamically updated based on user input
            };

            return View(reservation);
        }

        public IActionResult CreateReservation(int horseId)
        {
            var horse = _context.horses.Include(h => h.Breed).FirstOrDefault(h => h.Id == horseId);

            if (horse == null)
            {
                return NotFound();
            }

            var reservation = new Reservation
            {
                Horse = horse, // Pass the selected horse
                Price = horse.Price, // Default price calculation
                TakeHour = DateTime.Now, // Optional: Initialize default values
                ReturnHour = DateTime.Now.AddHours(1)
            };

            return View(reservation); // Pass the reservation model to the view
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TakeHour,ReturnHour,Horse")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                // Fetch horse details to calculate price
                var horse = await _context.horses.FindAsync(reservation.Horse.Id);

                if (horse == null)
                {
                    return NotFound();
                }

                // Calculate price
                var hours = (reservation.ReturnHour - reservation.TakeHour).TotalHours;
                reservation.Price = horse.Price * hours;

                _context.Add(reservation);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Reservation");
            }
            return View(reservation);
        }

    }
}
