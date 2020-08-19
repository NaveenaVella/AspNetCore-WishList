﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var items = _context.Items.ToList();
            return View("Index", items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Models.Item items)
        {
            _context.Items.Add(items);
            _context.SaveChanges();
            return View("Index");
        }

        public IActionResult Delete(int Id)
        {
            var itemId = _context.Items.FirstOrDefault(item => item.Id == Id);
            _context.Items.Remove(itemId);
            _context.SaveChanges();
            return View("Index");
        }
    }
}
