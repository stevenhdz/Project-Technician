using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Technician.Data;
using Project_Technician.ViewModels;

namespace Project_Technician.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactViewModel.ToListAsync());
        }

        // GET: Contact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactViewModel = await _context.ContactViewModel
                .FirstOrDefaultAsync(m => m.IdContact == id);
            if (contactViewModel == null)
            {
                return NotFound();
            }

            return View(contactViewModel);
        }

        // GET: Contact/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContact,Name,Mail,Phone,Mensaje")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                TempData["msg"] = "Enviado, este pendiente de su correo en 24 hrs o menos recibira respuesta";
                _context.Add(contactViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(contactViewModel);
        }

        // GET: Contact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactViewModel = await _context.ContactViewModel.FindAsync(id);
            if (contactViewModel == null)
            {
                return NotFound();
            }
            return View(contactViewModel);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContact,Name,Mail,Phone,Mensaje")] ContactViewModel contactViewModel)
        {
            if (id != contactViewModel.IdContact)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactViewModelExists(contactViewModel.IdContact))
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
            return View(contactViewModel);
        }

        // GET: Contact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactViewModel = await _context.ContactViewModel
                .FirstOrDefaultAsync(m => m.IdContact == id);
            if (contactViewModel == null)
            {
                return NotFound();
            }

            return View(contactViewModel);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactViewModel = await _context.ContactViewModel.FindAsync(id);
            _context.ContactViewModel.Remove(contactViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactViewModelExists(int id)
        {
            return _context.ContactViewModel.Any(e => e.IdContact == id);
        }
    }
}
