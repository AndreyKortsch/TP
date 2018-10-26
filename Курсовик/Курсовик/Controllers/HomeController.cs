using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Курсовик.Models;
using Курсовик.DAO;

namespace Курсовик.Controllers
{
    public class HomeController : Controller
    {
        ПродукцияDAO recordsDAO = new ПродукцияDAO();
        // GET: /Home/
        [Authorize(Roles = "Заведующий складом,Учетчик выдачи")]
        public ActionResult Index()
        {
            return View(recordsDAO.Список_продукции());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /Home/Create
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Продукция продукция)
        {
            try
            {
                if (recordsDAO.Добавить_продукт(продукция))
                    return RedirectToAction("Index");
                else
                    return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }
        // GET: Home/Create
        

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
