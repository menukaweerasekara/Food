﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Food.Areas.Identity.Data;
using Food.Models;
using Microsoft.AspNetCore.Authorization;

namespace Food.Controllers
{
    public class MenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Menus

        public async Task<IActionResult> Index(
      string sortOrder,
      string currentFilter,
      string searchString,
      int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var menus = from m in _context.Menus
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                menus = menus.Where(m => m.FoodName.Contains(searchString)
                                       || m.Country.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    menus = menus.OrderByDescending(s => s.FoodName);
                    break;
                
                default:
                    menus = menus.OrderBy(s => s.Price);
                    break;
                   
             var applicationDbContext = _context.Menus.Include(m => m.Restaurant);

            }
            int pageSize = 3;
            return View(await PaginatedList<Menu>.CreateAsync(menus.AsNoTracking(), pageNumber ?? 1, pageSize));
        }



       
        // return View(await applicationDbContext.ToListAsync());


        // GET: Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Menus == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Restaurant)
                .FirstOrDefaultAsync(m => m.MenuID == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["RestaurantID"] = new SelectList(_context.Restaurants, "RestaurantID", "RestaurantID");
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuID,FoodName,Country,Price,RestaurantID")] Menu menu)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantID"] = new SelectList(_context.Restaurants, "RestaurantID", "RestaurantID", menu.RestaurantID);
            return View(menu);
        }

        // GET: Menus/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Menus == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewData["RestaurantID"] = new SelectList(_context.Restaurants, "RestaurantID", "RestaurantID", menu.RestaurantID);
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuID,FoodName,Country,Price,RestaurantID")] Menu menu)
        {
            if (id != menu.MenuID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.MenuID))
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
            ViewData["RestaurantID"] = new SelectList(_context.Restaurants, "RestaurantID", "RestaurantID", menu.RestaurantID);
            return View(menu);
        }

        // GET: Menus/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Menus == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Restaurant)
                .FirstOrDefaultAsync(m => m.MenuID == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Menus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Menus'  is null.");
            }
            var menu = await _context.Menus.FindAsync(id);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return (_context.Menus?.Any(e => e.MenuID == id)).GetValueOrDefault();
        }
    }
}
