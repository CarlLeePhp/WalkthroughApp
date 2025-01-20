using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalkthroughApp.Data;
using WalkthroughApp.Models;

namespace WalkthroughApp.Controllers
{
    public class AuditorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AuditorsController (ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Auditors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auditor
                .Where(a => a.IsActive == true)
                .ToListAsync());
        }

        // GET: Auditors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auditors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsActive")] Auditor auditor)
        {
            if (ModelState.IsValid)
            {
                auditor.IsActive = true;
                _context.Add(auditor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auditor);
        }


        // GET: Auditors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditor = await _context.Auditor.FindAsync(id);
            if (auditor == null)
            {
                return NotFound();
            }
            return View(auditor);
        }

        // POST: Auditors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsActive")] Auditor auditor)
        {
            if (id != auditor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auditor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditorExists(auditor.Id))
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
            return View(auditor);
        }

        // GET: Auditors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditor = await _context.Auditor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auditor == null)
            {
                return NotFound();
            }

            return View(auditor);
        }

        // POST: Auditors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auditor = await _context.Auditor.FindAsync(id);

            auditor.IsActive = false;
            _context.Update(auditor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditorExists(int id)
        {
            return _context.Auditor.Any(e => e.Id == id);
        }

    }
}
