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
using System.Security.Permissions;

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
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder)? "name_desc" : "";


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

                ViewData["CurrentFilter"] = searchString;
            var patients = from p in _context.Patient.Include(p => p.Doctor).Include(p => p.Diagnosis) select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(p => p.LastName.Contains(searchString)
                                       || p.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    patients = patients.OrderByDescending(s => s.LastName);
                    break;
                default:
                    patients = patients.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Patient>.CreateAsync(patients.AsNoTracking(), pageNumber ?? 1, pageSize));
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
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(m => m.PatientsId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patient/Create
        public IActionResult Create()
        {
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagnosisId", "Diagnosis_Name");
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "FirstName");
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientsId,FirstName,LastName,Phone,Email,Address,DoctorId,DiagnosisId")] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagnosisId", "Diagnosis_Name", patient.DiagnosisId);
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "DoctorId", patient.Doctor.FirstName);
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
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagnosisId", "Diagnosis_Name", patient.DiagnosisId);
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "DoctorId", patient.DoctorId);
            return View(patient);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientsId,FirstName,LastName,Phone,Email,Address,DoctorId,DiagnosisId")] Patient patient)
        {
            if (id != patient.PatientsId)
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
                    if (!PatientExists(patient.PatientsId))
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
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagnosisId", "Diagnosis_Name", patient.DiagnosisId);
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "DoctorId", patient.DoctorId);
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
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(m => m.PatientsId == id);
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
            return _context.Patient.Any(e => e.PatientsId == id);
        }
    }
}
