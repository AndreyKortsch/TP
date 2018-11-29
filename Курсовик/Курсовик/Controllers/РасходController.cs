using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Курсовик.DAO;
using Курсовик.Models;

namespace Курсовик.Controllers
{
    [Authorize(Roles = "Заведующий складом, Администратор")]
    public class РасходController : Controller
    {
        РасходDAO РасходDAO = new РасходDAO();
        ПродукцияDAO ПродукцияDAO = new ПродукцияDAO();
        // GET: Расход
        public ActionResult Index()
        {
            String sql = "SELECT * FROM Список_продукции WHERE статус is NUll";
            return View(ПродукцияDAO.Список_продукции(sql));
        }
        public ActionResult Index1()
        {
            String sql = "SELECT * FROM Список_продукции WHERE статус is not NUll";
            return View(ПродукцияDAO.Список_продукции(sql));
        }
        public ActionResult Index2()
        {
            if (РасходDAO.Обновить_статус1())
                return RedirectToAction("Index","Поставщик");
            else
                return View("Index1");
            
        }
        public ActionResult Index3()
        {
            if (РасходDAO.Обновить_статус2())
                return RedirectToAction("Index", "Поставщик");
            else
                return View("Index1");

        }
        public ActionResult Index4()
        {
            String sql = "SELECT "+ 
        "m.код_продукции as a, "+ 
        "m.название as b, "+
        "m.расход_по_норме as c, "+ 
        "m.статус, "+ 
        "sum(u.количество) as d, "+
        "u.код_продукции, "+
        "sum(n.количество) as e, "+
        "n.код_продукции "+
        "FROM Список_продукции m "+
            "INNER JOIN Журнал_выдач u "+
                "ON m.код_продукции = u.код_продукции "+
            "INNER JOIN Журнал_поступлений n "+
                 "ON m.код_продукции = n.код_продукции "+
        "WHERE m.статус = 'создан' "+
        "Group By u.код_продукции, m.код_продукции, "+
        "n.код_продукции, m.название, m.статус, " +
        "m.расход_по_норме";
            return View(РасходDAO.Табель_расхода(sql));
        }
        // GET: Расход/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Расход/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Расход/Create
        [HttpPost]
        public ActionResult Create(Расход расход)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Расход/Edit/5
        public ActionResult Edit(String id)
        {
            return View();
        }

        // POST: Расход/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, Расход расход)
        {
            try
            {
                // TODO: Add update logic here
                if (РасходDAO.Обновить_статус(id, расход))
                    return RedirectToAction("Index");
                else
                    return View("Create");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Расход/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Расход/Delete/5
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
