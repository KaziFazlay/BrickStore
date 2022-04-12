﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrickStore.Data;
using BrickStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrickStore.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationTypes;
            return View(objList);
        }


        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }


        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationTypes.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}