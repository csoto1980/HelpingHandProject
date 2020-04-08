using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHand.Data;
using HelpingHand.Library.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace HelpingHand.Controllers
{   [Authorize(Roles = "Donor")]
    public class DonorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Donors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Donors.Include(d => d.Address).Include(d => d.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Donors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors
                .Include(d => d.Address)
                .Include(d => d.IdentityUser)
                .FirstOrDefaultAsync(m => m.DonorId == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // GET: Donors/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City");
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonorId,Name,AddressId,IdentityUserId")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                if (donor.DonorId == 0)
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    donor.IdentityUserId = userId;
                    _context.Donors.Add(donor);
                }
                else
                {
                    var donorInDb = _context.Donors.Single(d => d.DonorId == donor.DonorId);
                    donorInDb.Name = donor.Name;
                    donorInDb.AddressId = donor.AddressId;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", donor.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", donor.IdentityUserId);
            return View(donor);
        }

        // GET: Donors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", donor.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", donor.IdentityUserId);
            return View(donor);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonorId,Name,AddressId,IdentityUserId")] Donor donor)
        {
            if (id != donor.DonorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var donorInDb = _context.Donors.Single(d => d.DonorId == donor.DonorId);
                    donorInDb.Name = donor.Name;
                    donorInDb.AddressId = donor.AddressId;
                    _context.Update(donor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorExists(donor.DonorId))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", donor.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", donor.IdentityUserId);
            return View(donor);
        }

        // GET: Donors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors
                .Include(d => d.Address)
                .Include(d => d.IdentityUser)
                .FirstOrDefaultAsync(m => m.DonorId == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonorExists(int id)
        {
            return _context.Donors.Any(e => e.DonorId == id);
        }
    }
}
