using Modelo;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClienteWeb.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteService service;

        public ClienteController()
        {
            service = new ClienteService();
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var lista = service.Load();
            return View(lista);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var cliente = service.Get(id);
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente entity)
        {
            try
            {
                service.Save(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = service.Get(id);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente entity)
        {
            try
            {
                service.Update(id, entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = service.Get(id);
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                service.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
