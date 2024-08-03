﻿using Microsoft.AspNetCore.Mvc;
using VehicleDatabaseAPI.Models;
using VehicleDatabaseAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace VehicleDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public CategoryController(VehicleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Category.ToList();
            return Ok(categories);
        }

        [HttpGet("{name}")]
        public IActionResult GetCategory(string name)
        {
            var category = _context.Category.FirstOrDefault(c => c.CategoryName == name);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult PostCategory(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategory), new { name = category.CategoryName }, category);
        }

        [HttpPut("{name}")]
        public IActionResult PutCategory(string name, Category category)
        {
            if (name != category.CategoryName)
            {
                return BadRequest();
            }

            _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
             _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteCategory(string name)
        {
            var category = _context.Category.FirstOrDefault(c => c.CategoryName == name);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
