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
{
    [Authorize(Roles = "Organization")]
    public class OrganizationsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public OrganizationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Organizations
        public async Task<IActionResult> Index(Organization organization)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            organization.IdentityUserId = userId;
            var organizationInfo = _context.Organizations.Where(o => o.IdentityUserId == userId).Include(o => o.Address).Include(o => o.IdentityUser);
            return View(await organizationInfo.ToListAsync());
        }

        // GET: Organizations/Details/5
        public async Task<IActionResult> Details(int? Organizationid)
        {
            if (Organizationid == null)
            {
                return NotFound();
            }
            var organization = await _context.Organizations
                .Include(o => o.Name)
                .Include(o => o.Address.Street)
                .Include(o => o.Address.City)
                .Include(o => o.Address.State)
                .Include(o => o.Address.ZipCode)
                .Include(o => o.IdentityUser)
                .FirstOrDefaultAsync(m => m.OrganizationId == Organizationid);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // GET: Organizations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Organization organization, [Bind("OrganizationId,Street,City,State,ZipCode")] Address address, [Bind("ItemId, Name")] Item item)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                organization.IdentityUserId = userId;
                _context.Add(organization);
                _context.Add(item);
                _context.SaveChanges();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", organization.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", organization.IdentityUserId);
            return View(organization);
        }

        // GET: Organizations/Edit/5
        public IActionResult Edit(Organization organization)
        {
            if (organization == null)
            {
                return NotFound();
            }
            //ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "ItemId", organization.ItemId);
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", organization.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", organization.IdentityUserId);
            return View(organization);

        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizationId,Name,AddressId,ItemId,IdentityUserId")] Organization organization)
        {
            if (id != organization.OrganizationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationExists(organization.OrganizationId))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", organization.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", organization.IdentityUserId);
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations
                .Include(o => o.Address)
                .Include(o => o.IdentityUser)
                .FirstOrDefaultAsync(m => m.OrganizationId == id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationExists(int id)
        {
            return _context.Organizations.Any(e => e.OrganizationId == id);
        }
    }
}
