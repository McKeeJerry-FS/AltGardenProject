using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AltGardenProject.Data;
using AltGardenProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace AltGardenProject.Controllers
{
    [Authorize]
    [Controller]
    [Route("[controller]/[action]")]
    public class GardensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GardensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gardens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gardens.ToListAsync());
        }

        // GET: Gardens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garden = await _context.Gardens
                .FirstOrDefaultAsync(m => m.GardenId == id);
            if (garden == null)
            {
                return NotFound();
            }

            return View(garden);
        }

        // GET: Gardens/Create
        public IActionResult Create()
        {
            ViewBag.LocationList = new SelectList(Enum.GetValues(typeof(Models.Enums.Location)).Cast<Models.Enums.Location>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }), "Value", "Text");
            ViewBag.GardenTypeList = new SelectList(Enum.GetValues(typeof(Models.Enums.GardenType)).Cast<Models.Enums.GardenType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }), "Value", "Text");
            return View();
        }

        // POST: Gardens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GardenId,UserId,Name,Location,Type,Description,Created,Updated,EndDate,LastWatered,LastFertilized,Humidity,Temperature,PH,VPD,LightingStrength")] Garden garden)
        {
            if (ModelState.IsValid)
            {
                garden.UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                _context.Add(garden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garden);
        }

        // GET: Gardens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.LocationList = new SelectList(Enum.GetValues(typeof(Models.Enums.Location)).Cast<Models.Enums.Location>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }), "Value", "Text");
            ViewBag.GardenTypeList = new SelectList(Enum.GetValues(typeof(Models.Enums.GardenType)).Cast<Models.Enums.GardenType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }), "Value", "Text");

            if (id == null)
            {
                return NotFound();
            }

            var garden = await _context.Gardens.FindAsync(id);
            if (garden == null)
            {
                return NotFound();
            }
            return View(garden);
        }

        // POST: Gardens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GardenId,UserId,Name,Location,Type,Description,Created,Updated,EndDate,LastWatered,LastFertilized,Humidity,Temperature,PH,VPD,LightingStrength")] Garden garden)
        {
            if (id != garden.GardenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GardenExists(garden.GardenId))
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
            return View(garden);
        }

        // GET: Gardens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garden = await _context.Gardens
                .FirstOrDefaultAsync(m => m.GardenId == id);
            if (garden == null)
            {
                return NotFound();
            }

            return View(garden);
        }

        // POST: Gardens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garden = await _context.Gardens.FindAsync(id);
            if (garden != null)
            {
                _context.Gardens.Remove(garden);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GardenExists(int id)
        {
            return _context.Gardens.Any(e => e.GardenId == id);
        }
    }
}
