using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAO;
using DAO.Model;

namespace BanGiay.Views
{
    public class ShoeModelsController : Controller
    {
        private readonly DataContext _context;

        public ShoeModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: ShoeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShoeModels.ToListAsync());
        }

        // GET: ShoeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeModel = await _context.ShoeModels
                .FirstOrDefaultAsync(m => m.ShoesId == id);
            if (shoeModel == null)
            {
                return NotFound();
            }

            return View(shoeModel);
        }

        // GET: ShoeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShoeName,ShoeSize,ShoeImg,ShoeCateId,ShoeDesc,Status,CreateId,CreateDate,UpdadeId,UpdateDate")] ShoeModel shoeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoeModel);
        }

        // GET: ShoeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeModel = await _context.ShoeModels.FindAsync(id);
            if (shoeModel == null)
            {
                return NotFound();
            }
            return View(shoeModel);
        }

        // POST: ShoeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoesId,ShoeName,ShoeSize,ShoeImg,ShoeCateId,ShoeDesc,Status,CreateId,CreateDate,UpdadeId,UpdateDate")] ShoeModel shoeModel)
        {
            if (id != shoeModel.ShoesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoeModelExists(shoeModel.ShoesId))
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
            return View(shoeModel);
        }

        // GET: ShoeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeModel = await _context.ShoeModels
                .FirstOrDefaultAsync(m => m.ShoesId == id);
            if (shoeModel == null)
            {
                return NotFound();
            }

            return View(shoeModel);
        }

        // POST: ShoeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoeModel = await _context.ShoeModels.FindAsync(id);
            _context.ShoeModels.Remove(shoeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoeModelExists(int id)
        {
            return _context.ShoeModels.Any(e => e.ShoesId == id);
        }
    }
}
