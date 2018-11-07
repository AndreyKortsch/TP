using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Курсовик.Models;
using Курсовик.DAO;


namespace Курсовик.Controllers
{
    [Authorize(Roles = "Заведующий складом,Учетчик выдачи")]
    public class ПродукцияController : Controller
    {   
        ПродукцияDAO ПродукцияDAO = new ПродукцияDAO();
       // GET: /Home/
        
        public ActionResult Index()
        {
            String sql = "SELECT * FROM Список_продукции";
            return View(ПродукцияDAO.Список_продукции(sql));
        }
        public ActionResult Index1(int id)
        {
            String sql = "SELECT * FROM Список_продукции WHERE номер_категории="+id;
            return View(ПродукцияDAO.Список_продукции(sql));
        }
        // GET: /Home/Details/5
        public ActionResult Details(String id)
        {
            return View(ПродукцияDAO.Продукция(id));
        }
        //
        // GET: /Home/Create
        [Authorize(Roles = "Заведующий складом")]
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
        [Authorize(Roles = "Заведующий складом")]

        // GET: Home/Edit/5
        public ActionResult Edit(String id)
        {
            return View(ПродукцияDAO.Продукция(id));
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, Продукция продукция)
        {
            try
            {
                if (ПродукцияDAO.Изменить_продукцию(id,продукция))
                    return RedirectToAction("Index");
                else
                    return View("Edit");

                
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Заведующий складом")]
        // GET: Home/Delete/5
        public ActionResult Delete(String id)
        {
            return View(ПродукцияDAO.Продукция(id));
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(String id, Продукция продукция)
        {
            try
            {
                if (ПродукцияDAO.Удалить_продукцию(id,продукция))
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
