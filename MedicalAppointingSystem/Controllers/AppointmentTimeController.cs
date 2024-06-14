using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalAppointingSystem.Areas.Identity.Data;
using MedicalAppointingSystem.Models;

namespace MedicalAppointingSystem.Controllers
{
    public class AppointmentTimeController : Controller
    {
        private readonly MedicalAppointingDbContext _context;

        public AppointmentTimeController(MedicalAppointingDbContext context)
        {
            _context = context;
        }

        // GET: AppointmentTime
        public async Task<IActionResult> Index()
        {
            var medicalAppointingDbContext = _context.AppointmentTime.Include(a => a.Patients);
            return View(await medicalAppointingDbContext.ToListAsync());
        }

        // GET: AppointmentTime/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentTime = await _context.AppointmentTime
                .Include(a => a.Patients)
                .FirstOrDefaultAsync(m => m.AppointedId == id);
            if (appointmentTime == null)
            {
                return NotFound();
            }

            return View(appointmentTime);
        }

        // GET: AppointmentTime/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "PatientsId", "FirstName");
            return View();
        }

        // POST: AppointmentTime/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointedId,AppointedTime,PatientId")] AppointmentTime appointmentTime)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(appointmentTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "PatientsId", "FirstName", appointmentTime.PatientId);
            return View(appointmentTime);
        }

        // GET: AppointmentTime/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentTime = await _context.AppointmentTime.FindAsync(id);
            if (appointmentTime == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "PatientsId", "FirstName", appointmentTime.PatientId);
            return View(appointmentTime);
        }

        // POST: AppointmentTime/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointedId,AppointedTime,PatientId")] AppointmentTime appointmentTime)
        {
            if (id != appointmentTime.AppointedId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentTimeExists(appointmentTime.AppointedId))
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
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "PatientsId", "FirstName", appointmentTime.PatientId);
            return View(appointmentTime);
        }

        // GET: AppointmentTime/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentTime = await _context.AppointmentTime
                .Include(a => a.Patients)
                .FirstOrDefaultAsync(m => m.AppointedId == id);
            if (appointmentTime == null)
            {
                return NotFound();
            }

            return View(appointmentTime);
        }

        // POST: AppointmentTime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentTime = await _context.AppointmentTime.FindAsync(id);
            if (appointmentTime != null)
            {
                _context.AppointmentTime.Remove(appointmentTime);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentTimeExists(int id)
        {
            return _context.AppointmentTime.Any(e => e.AppointedId == id);
        }
    }
}
