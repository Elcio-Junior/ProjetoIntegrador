using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Servico;

namespace ClienteWeb.Controllers
{
    [Authorize]
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
            var lista = service.Load().Include(x => x.Cliente);
            //var clienteResult = clienteService.Get(x=> x.Id == lista.)

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
            BuscarCliente();
            return View();
        }

        private void BuscarCliente()
        {
            Cliente Newblank = new Cliente { Id = 0, Nome = "Selecione o Cliente" };
            var listCliente = new List<Cliente>();

            listCliente.Add(Newblank);
            var returnCliente = clienteService.Load();

            listCliente.AddRange(returnCliente);

            ViewBag.ClienteID = new SelectList(listCliente, "Id", "Nome");
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
                BuscarCliente();

                return View();
            }
        }

        // GET: Equipamento/Edit/5
        public ActionResult Edit(int id)
        {
            var entity =  service.Get(id);
            var returnCliente = clienteService.Load();
            ViewBag.StateID = new SelectList(returnCliente, "Id", "Nome");
            return View();
        }

        // POST: Equipamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Equipamento entity)
        {
            try
            {
                service.Update(id, entity);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Equipamento/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = service.Get(id);

            return View(entity);
        }

        // POST: Equipamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Equipamento entity)
        {
            try
            {
                // TODO: Add delete logic here
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
