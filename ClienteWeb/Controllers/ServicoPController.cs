using Modelo;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClienteWeb.Controllers
{
    [Authorize]
    public class ServicoPController : Controller
    {
        private Contexto db = new Contexto();

        private ServicoService service;
        private TipoServicoService Tiposervice;

        public ServicoPController()
        {
            service = new ServicoService();
            Tiposervice = new TipoServicoService();
        }

        // GET: Serviço
        public ActionResult Index()
        {
            var result = db.Servicos.ToList();
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            var item = db.Servicos.Find(id);
            var result = false;
            if (item != null)
            {
                db.Servicos.Remove(item);
                db.SaveChanges();
                result = true;
            }

            return Json(new { Resultado = result }, JsonRequestBehavior.AllowGet);
        }

        // GET: Servico/Create
        public ActionResult Create()
        {
            TipoServico tipo = new TipoServico { Id = 0, Descricao = "Selecionar Tipo" };
            var listTipo = new List<TipoServico>();
            listTipo.Add(tipo);

            var resultTipo = Tiposervice.Load().ToList();
            listTipo.AddRange(resultTipo);

            ViewBag.TipoServicoID = new SelectList(listTipo, "Id", "Descricao");
            return View();
        }

        // POST: Servico/Create
        [HttpPost]
        public ActionResult Create(ServicoP entity)
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

    }
}