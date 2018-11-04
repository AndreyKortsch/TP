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
            return View(ПоставщикDAO.Поставщик(id));
        }

        // GET: Home1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home1/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "код_поставщика")]Поставщик поставщик)
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
            return View(ПоставщикDAO.Поставщик(id));
        }

        // POST: Home1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Поставщик поставщик)
        {
            try
            {
                // TODO: Add update logic here
                if (ПоставщикDAO.Изменить_поставщика(id,поставщик))
                    return RedirectToAction("Index");
                else
                    return View("Edit");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Home1/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ПоставщикDAO.Поставщик(id));
        }

        // POST: Home1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Поставщик поставщик)
        {
            try
            {
                if (ПоставщикDAO.Удалить_поставщика(id))
                    return RedirectToAction("Index");
                else
                    return View("Delete");
            }
            catch
            {
                return View();
            }
        }
    }
}
