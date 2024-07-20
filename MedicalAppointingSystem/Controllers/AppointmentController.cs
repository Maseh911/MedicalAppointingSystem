using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalAppointingSystem.Areas.Identity.Data;
using MedicalAppointingSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace MedicalAppointingSystem.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly MedicalAppointingDbContext _context;

        public AppointmentController(MedicalAppointingDbContext context)
        {
            _context = context;
        }

        // GET: Appointmentthe searchString parameter represents a keyword of a search which is used for filtering
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber) // The sortOrder parameter represents the sort order of a list, The searchString parameter represents a keyword of a search which will be used for filtering, the currentFilter parameters represents a current filter being applied to a list this is used for pagination in maintaining the filter, the int? pagenumber parameter is used for pagination, the '?' represents the current page number // 
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : ""; // This will determine the next sort order parameter based on the current order (if it has been selected/ordered yet) for name //
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";          // This will determine the next sort order parameter based on the current order (if it has been selected/ordered yet) for date //
            ViewData["CurrentFilter"] = searchString;       // This will pass the filter value from the controller to the view to display the filtered value //
            ViewData["CurrentSort"] = sortOrder;    // This will pass the the sort order value from the controller to the view to display the sort order value //

            if (searchString != null)        
            {
                pageNumber = 1;
            }
            else                                       // if the searchString is not null it will reset the pagination and set the page to 1 //
            {
                searchString = currentFilter;
            }                   

            var appointments = from a in _context.AppointmentTime.Include(a => a.Patient).Include(a => a.Doctor) select a;

            if (!String.IsNullOrEmpty(searchString))  // If the searchString is not empty then it will exectute the statement //
            {
                appointments = appointments.Where(a => a.Patient.FirstName.Contains(searchString) // It can filter the patient's First name //
                                       || a.Doctor.FirstName.Contains(searchString));     // It can filter the doctor's First name //
            };

            switch (sortOrder)      // This is for the sorting //
            {
                case "name_desc":
                    appointments = appointments.OrderByDescending(a => a.Patient.FirstName);   // This sorts the Patients First name (Descending) //
                    break;
                case "Date":
                    appointments = appointments.OrderBy(s => s.Date);   // This sorts the Date, from the earliest to the latest (Descending) //
                    break;
                case "date_desc":
                    appointments = appointments.OrderByDescending(s => s.Date);     // This sorts the Date, from the earliest to the latest (Descending) //
                    break;
                default:
                    appointments = appointments.OrderBy(s => s.Patient.FirstName);      // This sorts the Patients First name (Descending) //
                    break;
            }

            int pageSize = 15;  // This indicates how much results will show in each page //
            return View(await PaginatedList<Appointment>.CreateAsync(appointments.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.AppointmentTime
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointment/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "FirstName");
            ViewData["PatientId"] = new SelectList(_context.Patient, "PatientId", "FirstName");
            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,Date,PatientId,DoctorId")] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "FirstName", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "PatientId", "FirstName", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.AppointmentTime.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "FirstName", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "PatientId", "FirstName", appointment.PatientId);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,Date,PatientId,DoctorId")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "FirstName", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "PatientId", "FirstName", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.AppointmentTime
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.AppointmentTime.FindAsync(id);
            if (appointment != null)
            {
                _context.AppointmentTime.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.AppointmentTime.Any(e => e.AppointmentId == id);
        }
    }
}
