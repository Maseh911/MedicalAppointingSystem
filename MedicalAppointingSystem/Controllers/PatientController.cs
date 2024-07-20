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
    public class PatientController : Controller
    {
        private readonly MedicalAppointingDbContext _context;

        public PatientController(MedicalAppointingDbContext context)
        {
            _context = context;
        }

        // GET: Patient
        public async Task<IActionResult> Index(string sortOrder, string searchString) // The sortOrder parameter represents the sort order of a list, The searchString parameter represents a keyword of a search which will be used for filtering //
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : ""; // This will determine the next sort order parameter based on the current order (if it has been selected/ordered yet) for name //
            ViewData["CurrentFilter"] = searchString;       // This will pass the filter value from the controller to the view to display the filtered value //

            var patients = from p in _context.Patient.Include(p => p.Diagnosis) select p;

            if (!String.IsNullOrEmpty(searchString))  // If the searchString is not empty then it will exectute the statement //
            {
                patients = patients.Where(p => p.LastName.Contains(searchString) // It can filter the patient's Last name //
                                       || p.FirstName.Contains(searchString)); // It can filter the patient's First name //
            }

            switch (sortOrder)
            {
                case "name_desc":
                    patients = patients.OrderByDescending(s => s.LastName);    // This sorts the Patients Last name (Descending) //
                    break;
                default:
                    patients = patients.OrderBy(s => s.LastName);    // This sorts the Patients Last name (Descending) //
                    break;
            }

            return View(await patients.ToListAsync());
        }

        // GET: Patient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .Include(p => p.Diagnosis)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patient/Create
        public IActionResult Create()
        {
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagnosisId", "DiagnosisName");
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,FirstName,LastName,Phone,Email,Address,DiagnosisId")] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagnosisId", "DiagnosisName", patient.DiagnosisId);
            return View(patient);
        }

        // GET: Patient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagnosisId", "DiagnosisName", patient.DiagnosisId);
            return View(patient);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientId,FirstName,LastName,Phone,Email,Address,DiagnosisId")] Patient patient)
        {
            if (id != patient.PatientId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.PatientId))
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
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagnosisId", "DiagnosisName", patient.DiagnosisId);
            return View(patient);
        }

        // GET: Patient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .Include(p => p.Diagnosis)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patient.FindAsync(id);
            if (patient != null)
            {
                _context.Patient.Remove(patient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.Patient.Any(e => e.PatientId == id);
        }
    }
}
