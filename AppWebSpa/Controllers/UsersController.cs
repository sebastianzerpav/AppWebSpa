﻿using AppWebSpa.Data;
using AppWebSpa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWebSpa.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        //View Index with list of Users
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<User> Users = await _context.Users.ToListAsync();
            return View(Users);
        }

        //View specific user details
        [HttpGet]
        public async Task<IActionResult> UserDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                User? user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == id);
                if (user == null) { return NotFound(); }
                else { return View(user); }
            }
        }

        // View create
        public IActionResult Create()
        {
            return View();
        }

        // Method Create - Register user
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            { return RedirectToAction(nameof(Index)); }
        }

        // View Edit
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                User? user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
        }

        // Method Edit user 
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            { return RedirectToAction(nameof(Index)); }
        }

        // View Delete specific user
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                User? user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == id);
                if (user == null)
                { return NotFound(); }

                return View(user);
            }
        }

        // Method Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> AcceptDelete(int id)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
