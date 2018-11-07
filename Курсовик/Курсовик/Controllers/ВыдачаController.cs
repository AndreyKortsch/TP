using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Курсовик.Models;
using Курсовик.DAO;

namespace Курсовик.Controllers
{
    public class ВыдачаController : Controller
    {
        ВыдачаDAO ВыдачаDAO = new ВыдачаDAO();
        // GET: Выдача
        public ActionResult Index()
        {
            return View(ВыдачаDAO.Журнал_выдач());
        }

        // GET: Выдача/Details/5
        public ActionResult Details(int id)
        {
            return View(ВыдачаDAO.Выдача(id));
        }

        // GET: Выдача/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Выдача/Create
        [HttpPost]
        public ActionResult Create(String id, Выдача выдача)
        {
            try
            {
                // TODO: Add insert logic here
                if (ВыдачаDAO.Добавить_выдачу(id,выдача))
                    return RedirectToAction("Index","Категория");
                else
                    return View("Create");

            }
            catch
            {
                return View();
            }
        }

        // GET: Выдача/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ВыдачаDAO.Выдача(id));
        }

        // POST: Выдача/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Выдача выдача)
        {
            try
            {

                if (ВыдачаDAO.Изменить_выдачу(id, выдача))
                    return RedirectToAction("Index");
                else
                    return View("Edit");

            }
            catch
            {
                return View();
            }
        }

        // GET: Выдача/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Выдача/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Выдача выдача)
        {
            try
            {
                if (ВыдачаDAO.Удалить_выдачу(id, выдача))
                    return RedirectToAction("Index");
                else
                    return View("Delete");


            }
            catch
            {
                return View();
            }
        }
        public ActionResult Index3(String id)
        {
            Выдача av = new Выдача();
            av.Код_продукции = id;
            av.Дата_и_время = DateTime.Now;
            return View(av);
        }
        [HttpPost]
        public ActionResult Index3(String id, Выдача b)
        {
            try
            {
                if (ВыдачаDAO.Добавить_выдачу(id,b))
                    return RedirectToAction("Index", "Категория");
                else
                    return View("Index3");
            }
            catch
            {
                return View();
            }
        }
    }
}