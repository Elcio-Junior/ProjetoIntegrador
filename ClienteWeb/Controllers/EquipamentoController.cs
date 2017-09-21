using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Servico;

namespace ClienteWeb.Controllers
{
    public class EquipamentoController : Controller
    {
        private EquipamentoService service;
        private ClienteService clienteService;
        public EquipamentoController()
        {
            service = new EquipamentoService();
            clienteService = new ClienteService();
        }
        // GET: Equipamento
        public ActionResult Index()
        {
            var lista = service.Load();
            return View(lista);
        }

        // GET: Equipamento/Details/5
        public ActionResult Details(int id)
        {
            var equipamento = service.Get(id);
            return View(equipamento);
        }

        // GET: Equipamento/Create
        public ActionResult Create()
        {
            Cliente Newblank = new Cliente { Id = 0, Nome = "Selecione o Cliente" };
            var listCliente = new List<Cliente>();

            listCliente.Add(Newblank);
            var returnCliente = clienteService.Load();

            listCliente.AddRange(returnCliente);
            return View();
        }

        // POST: Equipamento/Create
        [HttpPost]
        public ActionResult Create(Equipamento entity)
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

        // GET: Equipamento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Equipamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Equipamento entity)
        {
            try
            {
                //var edit = service.Get(id, entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Equipamento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Equipamento/Delete/5
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
