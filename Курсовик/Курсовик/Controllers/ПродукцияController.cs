using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Курсовик.Models;
using Курсовик.DAO;


namespace Курсовик.Controllers
{
    [Authorize(Roles = "Заведующий складом")]
    public class ПродукцияController : Controller
    {   
        ПродукцияDAO ПродукцияDAO = new ПродукцияDAO();
       // GET: /Home/
        
        public ActionResult Index()
        {
            return View(ПродукцияDAO.Список_продукции());
        }
       
        // GET: /Home/Details/5
        public ActionResult Details(int id)
        {
            return View(ПродукцияDAO.Продукция(id));
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
                if (ПродукцияDAO.Добавить_продукт(продукция))
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
            return View(ПродукцияDAO.Продукция(id));
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Продукция продукция)
        {
            try
            {
                if (ПродукцияDAO.Изменить_продукцию(продукция))
                    return RedirectToAction("Index");
                else
                    return View("Edit");

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ПродукцияDAO.Продукция(id));
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Продукция продукция)
        {
            try
            {
                if (ПродукцияDAO.Удалить_продукцию(продукция))
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
