﻿using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace MIS442Store.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _Repo;// = new ProductRepository();

        public ProductController()
        {
            _Repo = new ProductRepository();
        }
            
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "MIS442 News";
            ViewBag.Header = "MIS442 News";
            //List<Product> productList = _Repo.GetList();
            return View(_Repo.GetList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Add(Product prod)
        {
            if (!ModelState.IsValid)
            {
                return View(prod);
            }
            _Repo.Save(prod);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    Product prod = _Repo.Get(id);
        //    return View(prod);
        //}

        //[HttpPost]
        //public ActionResult Edit(Product prod)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(prod);
        //    }
        //    _Repo.Save(prod);
        //    return RedirectToAction("Index");
        //}

        //THomas
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = _Repo.Get(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _Repo.Save(product);
            return RedirectToAction("Index");
        }

    }
}