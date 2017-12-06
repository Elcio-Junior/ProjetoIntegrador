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
        //Estancia as Camadas de serviços
        private EquipamentoService service;
        private ClienteService clienteService;

        // Inicialisa os contrutores
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
        //busco o Cliente e add em uma ViewBag
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
                //Salvo no Banco
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
            //busco equipamento pelo ID 
            var entity =  service.Get(id);
            var returnCliente = clienteService.Load();
            //Coloco os Clientes em uma ViewBag
            ViewBag.ClienteID = new SelectList(returnCliente, "Id", "Nome",entity.ClienteId);
            return View(entity);
        }

        // POST: Equipamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Equipamento entity)
        {
            try
            {
                var result = service.Get(id);

                if (ModelState.IsValid && result != null)
                {
                    result.Ano = entity.Ano;
                    result.ClienteId = entity.ClienteId;
                    result.Modelo = entity.Modelo;
                    result.NumeroSerie = entity.NumeroSerie;
                    result.Tipo = entity.Tipo;

                    service.Update(id, result);
                    return RedirectToAction("Index");
                }
                else{
                    return RedirectToAction("Shared/Erro");
                }
                
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Equipamento/Delete/5
        public ActionResult Delete(int id)
        {
            //busco um Equipamento e retorno os detalhes dele na view
            var entity = service.Get(id);

            return View(entity);
        }

        // POST: Equipamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Equipamento model)
        {
            try
            {
                //clienteService.Get(model.ClienteId);
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
