using System;
using System.Web.Mvc;
using Курсовик.DAO;
using Курсовик.Models;

namespace Курсовик.Controllers
{
    public class Поставщик_категорияController : Controller
    {
        Поставщик_категорияDAO Поставщик_категорияDAO = new Поставщик_категорияDAO();
        // GET: Поставщик_категория
        public ActionResult Index1(int id)
        {
            
            String sql = "SELECT * FROM Список_категорий " +
                    "WHERE номер not in (SELECT номер_категории from Поставщик_категория WHERE " +
                    "номер_поставщика=" + id + ")";
            return View(Поставщик_категорияDAO.Список_категорий(sql,id));
        }
        public ActionResult Index2(int id)
        {
            String sql = "SELECT * FROM Список_категорий " +
                    "WHERE номер in (SELECT номер_категории from Поставщик_категория WHERE " +
                    "номер_поставщика=" + id + ")";
            return View(Поставщик_категорияDAO.Список_категорий(sql,id));
        }
        public ActionResult Index4(int id, int a)
        {
            Поставщик_категория av = new Поставщик_категория();
            av.Код_поставщика = id;
            av.Код_категории = a;
            return View(av);
        }
        [HttpPost]
        public ActionResult Index4(int id, int a, Поставщик_категория b)
        {
            try
            {
                if (Поставщик_категорияDAO.Удалить_категорию(id, a))
                {
                    return RedirectToAction("Index2", new { id });
                }
                else
                    return View("Index4");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Index3(int id, int a)
        {
            Поставщик_категория av = new Поставщик_категория();
            av.Код_поставщика = id;
            av.Код_категории = a;
            return View(av);
        }
        [HttpPost]
        public ActionResult Index3(int id, int a,Поставщик_категория b)
        {
            try
            {
                if (Поставщик_категорияDAO.Добавить_категорию(id,a))
                    return RedirectToAction("Index1",new { id });
                else
                    return View("Index3");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Поставщик_категория/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Поставщик_категория/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Поставщик_категория/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Поставщик_категория/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Поставщик_категория/Edit/5
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

        // GET: Поставщик_категория/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Поставщик_категория/Delete/5
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
