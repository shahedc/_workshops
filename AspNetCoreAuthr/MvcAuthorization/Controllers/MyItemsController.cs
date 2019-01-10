using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcAuthorization.Data;
using MvcAuthorization.Models;

namespace MvcAuthorization.Controllers
{
    public class MyItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyItem.ToListAsync());
        }

        // GET: MyItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myItem = await _context.MyItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myItem == null)
            {
                return NotFound();
            }

            return View(myItem);
        }

        // GET: MyItems/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598. 
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemName,ItemDescription")] MyItem myItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myItem);
        }

        // GET: MyItems/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myItem = await _context.MyItem.FindAsync(id);
            if (myItem == null)
            {
                return NotFound();
            }
            return View(myItem);
        }

        // POST: MyItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemName,ItemDescription")] MyItem myItem)
        {
            if (id != myItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyItemExists(myItem.Id))
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
            return View(myItem);
        }

        // GET: MyItems/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myItem = await _context.MyItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myItem == null)
            {
                return NotFound();
            }

            return View(myItem);
        }

        // POST: MyItems/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myItem = await _context.MyItem.FindAsync(id);
            _context.MyItem.Remove(myItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyItemExists(int id)
        {
            return _context.MyItem.Any(e => e.Id == id);
        }
    }
}
