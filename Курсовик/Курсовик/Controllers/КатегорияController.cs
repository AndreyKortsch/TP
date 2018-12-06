using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Курсовик.Models;
using Курсовик.DAO;

namespace Курсовик.Controllers
{
    [Authorize(Roles = "Администратор,Учетчик выдачи, Заведующий складом")]
    public class КатегорияController : Controller
    {
        КатегорияDAO КатегорияDAO = new КатегорияDAO();
        Кат_продукцияDAO Кат_ПродукцияDAO = new Кат_продукцияDAO();
        
        // GET: Категория
        public ActionResult Index()
        {
            return View(КатегорияDAO.Список_категорий());
        }
        public ActionResult Index2(Кат_продукция продукция)
        {
            
            return View(Кат_ПродукцияDAO.Список_категорий(продукция));
            
        }
        
        // GET: Категория/Details/5
        public ActionResult Details(int id)
        {
            return View(КатегорияDAO.Категория(id));
        }

        // GET: Категория/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Категория/Create
        [HttpPost]
        public ActionResult Create(Категория категория)
        {
            try
            {
                if (КатегорияDAO.Добавить_категорию(категория))
                    return RedirectToAction("Index");
                else
                    return View("Create");


                
            }
            catch
            {
                return View();
            }
        }

        // GET: Категория/Edit/5
        public ActionResult Edit(int id)
        {
            return View(КатегорияDAO.Категория(id));
        }

        // POST: Категория/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Категория категория)
        {
            try
            {
                if (КатегорияDAO.Изменить_категорию(id,категория))
                    return RedirectToAction("Index");
                else
                    return View("Edit");
            }
            catch
            {
                return View();
            }
        }

        // GET: Категория/Delete/5
        public ActionResult Delete(int id)
        {
            return View(КатегорияDAO.Категория(id));
        }

        // POST: Категория/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Категория категория)
        {
            try
            {
                if (КатегорияDAO.Удалить_категорию(id,категория))
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
