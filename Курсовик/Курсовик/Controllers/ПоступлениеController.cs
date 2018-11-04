using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Курсовик.Models;
using Курсовик.DAO;

namespace Курсовик.Controllers
{
    public class ПоступлениеController : Controller
    {
        ПоступлениеDAO ПоступлениеDAO = new ПоступлениеDAO();
        // GET: Поступление
        public ActionResult Index()
        {
            return View(ПоступлениеDAO.Журнал_поступлений());
        }

        // GET: Поступление/Details/5
        public ActionResult Details(int id)
        {
            return View(ПоступлениеDAO.Поступление(id));
        }

        // GET: Поступление/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Поступление/Create
        [HttpPost]
        public ActionResult Create(Поступление поступление)
        {
            try
            {
                if (ПоступлениеDAO.Добавить_поступление(поступление))
                    return RedirectToAction("Index");
                else
                    return View("Create");

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Поступление/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ПоступлениеDAO.Поступление(id));
        }

        // POST: Поступление/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Поступление поступление)
        {
            try
            {
                if (ПоступлениеDAO.Изменить_поступление(поступление))
                    return RedirectToAction("Index");
                else
                    return View("Edit");

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Поступление/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Поступление/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Поступление поступление)
        {
            try
            {
                if (ПоступлениеDAO.Удалить_поступление(поступление))
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
