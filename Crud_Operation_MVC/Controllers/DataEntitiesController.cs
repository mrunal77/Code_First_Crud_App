using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crud_Operation_MVC.Models;

namespace Crud_Operation_MVC.Controllers
{
    public class DataEntitiesController : Controller
    {
        private readonly EntityDbContext _context;

        public DataEntitiesController(EntityDbContext context)
        {
            _context = context;
        }

        // GET: DataEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataEntities.ToListAsync());
        }

        // GET: DataEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataEntity = await _context.DataEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataEntity == null)
            {
                return NotFound();
            }

            return View(dataEntity);
        }

        // GET: DataEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DataEntity dataEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataEntity);
        }

        // GET: DataEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataEntity = await _context.DataEntities.FindAsync(id);
            if (dataEntity == null)
            {
                return NotFound();
            }
            return View(dataEntity);
        }

        // POST: DataEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DataEntity dataEntity)
        {
            if (id != dataEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataEntityExists(dataEntity.Id))
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
            return View(dataEntity);
        }

        // GET: DataEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataEntity = await _context.DataEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataEntity == null)
            {
                return NotFound();
            }

            return View(dataEntity);
        }

        // POST: DataEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataEntity = await _context.DataEntities.FindAsync(id);
            if (dataEntity != null)
            {
                _context.DataEntities.Remove(dataEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataEntityExists(int id)
        {
            return _context.DataEntities.Any(e => e.Id == id);
        }
    }
}
