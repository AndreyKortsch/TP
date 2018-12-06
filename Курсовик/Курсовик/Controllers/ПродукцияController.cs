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
        Кат_продукцияDAO Кат_ПродукцияDAO = new Кат_продукцияDAO();
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
        public ActionResult Index3(Продукция продукция)
        {
            if (ПродукцияDAO.Добавить_категорию(продукция))
            {
                String sql = "SELECT * FROM Список_продукции";
                return View(ПродукцияDAO.Список_продукции(sql));
            }
            else return RedirectToAction("Сreate","Продукция");
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
        public ActionResult Create(Кат_продукция продукция)
        {
            try
            {
                return RedirectToAction("Index2", "Категория", продукция);
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
        
        // POST: Категория/Delete/5
        
        public ActionResult Index4(Кат_продукция id)
        {
            try
            {
                Продукция продукция = new Продукция();
                продукция.Категория = id.Код_категории;
                продукция.Код_продукции = id.Код_продукции;
                продукция.Количество = id.Количество;
                продукция.Масса = id.Масса;
                продукция.Материал = id.Материал;
                продукция.Название = id.Название_продукции;
                продукция.Цена_за_единицу = id.Цена_за_единицу;

                if (ПродукцияDAO.Добавить_продукт(продукция))
                    return RedirectToAction("Index");
                else
                    return View("Index3");


            }
            catch(Exception ex)
            {
                String a = ex.Message;
                return View();
            }
        }
    }
}
