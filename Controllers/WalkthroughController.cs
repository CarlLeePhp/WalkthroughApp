using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalkthroughApp.Data;
using WalkthroughApp.Models;

namespace WalkthroughApp.Controllers
{
    public class WalkthroughController : Controller
    {
        private readonly ApplicationDbContext _context;
        public WalkthroughController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(DateOnly? startDate, DateOnly? endDate, string searchProcedure = "",
            string searchDepartment = "", string searchAuditor = "", string searchCompliant = "")
        {
            // filters
            if (endDate == null)
            {
                endDate = DateOnly.FromDateTime(DateTime.Now);
            }

            if (startDate == null)
            {
                startDate = endDate?.AddMonths(-6);
            }

            if (startDate >= endDate)
            {
                return BadRequest("The start date cannot be later than the end date");
            }

            var wk = _context.Walkthrough
                .Include(i => i.Department)
                .Include(i => i.Procedure)
                .Include(i => i.Auditor)
                .Where(i => i.CheckDate >= startDate && i.CheckDate <= endDate);

            
            // filters process
            if (!String.IsNullOrEmpty(searchProcedure))
            {
                wk = wk.Where(i => i.Procedure.Description.Contains(searchProcedure));
            }

            if (!String.IsNullOrEmpty(searchDepartment))
            {
                wk = wk.Where(i => i.Department.Name.Contains(searchDepartment));
            }

            if (!String.IsNullOrEmpty(searchAuditor))
            {
                wk = wk.Where(i => i.Auditor.Name.Contains(searchAuditor));
            }

            if (!String.IsNullOrEmpty(searchCompliant))
            {
                wk = wk.Where(i => i.Compliant.Contains(searchCompliant));
            }

            
            // Get data from database
            List<Walkthrough> walkthroughs = await wk.OrderByDescending(i => i.CheckDate).ToListAsync();

            return View(walkthroughs);
        }

        // GET: Walkthrough/Create
        public async Task<IActionResult> Create()
        {
            // Lists of Departments, Procedures, Auditors
            List<Department> departments = await _context.Department
                .Where(i => i.IsActive == true)
                .ToListAsync();
            List<Procedure> procedures = await _context.Procedure
                .Where(i => i.IsActive == true)
                .ToListAsync();
            List<Auditor> auditors = await _context.Auditor
                .Where(i => i.IsActive == true)
                .ToListAsync();

            ViewBag.Departments = departments;
            ViewBag.Procedures = procedures;
            ViewBag.Auditors = auditors;

            return View();
        }



        // POST: Auditors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckDate,Species,Shift,CheckTime,Compliant,Status,Comments,CorrectiveAction,DepartmentId,ProcedureId,AuditorId")] Walkthrough walkthrough)
        {
            if (ModelState.IsValid)
            {
                _context.Add(walkthrough);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Lists of Departments, Procedures, Auditors
            List<Department> departments = await _context.Department
                .Where(i => i.IsActive == true)
                .ToListAsync();
            List<Procedure> procedures = await _context.Procedure
                .Where(i => i.IsActive == true)
                .ToListAsync();
            List<Auditor> auditors = await _context.Auditor
                .Where(i => i.IsActive == true)
                .ToListAsync();

            ViewBag.Departments = departments;
            ViewBag.Procedures = procedures;
            ViewBag.Auditors = auditors;

            return View(walkthrough);
        }

        // GET: Walkthrough/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walkthrough = await _context.Walkthrough.FindAsync(id);
            if (walkthrough == null)
            {
                return NotFound();
            }

            // Lists of Departments, Procedures, Auditors
            List<Department> departments = await _context.Department
                .Where(i => i.IsActive == true)
                .ToListAsync();
            List<Procedure> procedures = await _context.Procedure
                .Where(i => i.IsActive == true)
                .ToListAsync();
            List<Auditor> auditors = await _context.Auditor
                .Where(i => i.IsActive == true)
                .ToListAsync();

            ViewBag.Departments = departments;
            ViewBag.Procedures = procedures;
            ViewBag.Auditors = auditors;

            return View(walkthrough);
        }

        // POST: Walkthrough/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CheckDate,Species,Shift,CheckTime,Compliant,Status,Comments,CorrectiveAction,DepartmentId,ProcedureId,AuditorId")] Walkthrough walkthrough)
        {
            if (id != walkthrough.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(walkthrough);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalkthroughExists(walkthrough.Id))
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

            // Lists of Departments, Procedures, Auditors
            List<Department> departments = await _context.Department
                .Where(i => i.IsActive == true)
                .ToListAsync();
            List<Procedure> procedures = await _context.Procedure
                .Where(i => i.IsActive == true)
                .ToListAsync();
            List<Auditor> auditors = await _context.Auditor
                .Where(i => i.IsActive == true)
                .ToListAsync();

            ViewBag.Departments = departments;
            ViewBag.Procedures = procedures;
            ViewBag.Auditors = auditors;

            return View(walkthrough);
        }


        private bool WalkthroughExists(int id)
        {
            return _context.Auditor.Any(e => e.Id == id);
        }


    }
}
