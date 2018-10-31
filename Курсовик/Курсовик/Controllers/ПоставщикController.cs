using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Курсовик.Models;
using Курсовик.DAO;

namespace Курсовик.Controllers
{
    [Authorize(Roles = "Администратор")]
    public class ПоставщикController : Controller
    {
        ПоставщикDAO ПоставщикDAO = new ПоставщикDAO();
       
        
        public ActionResult Index()
        {
            return View(ПоставщикDAO.Список_поставщиков());
        }

        // GET: Home1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home1/Create
        [HttpPost]
        public ActionResult Create(Поставщик поставщик)
        {
            try
            {
                // TODO: Add insert logic here
                if (ПоставщикDAO.Добавить_поставщика(поставщик))
                    return RedirectToAction("Index");
                else
                    return View("Create");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Home1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
