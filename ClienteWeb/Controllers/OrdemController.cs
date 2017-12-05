using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Servico;

namespace ClienteWeb.Controllers
{
    [Authorize]
    public class OrdemController : Controller
    {
        private Contexto db = new Contexto();

        private EquipamentoService equipamentoService;
        private ClienteService clienteService;
        private OrdemService ordemService;

        public OrdemController()
        {
            equipamentoService = new EquipamentoService();
            clienteService = new ClienteService();
            ordemService = new OrdemService();
        }

        // GET: Ordem
        public ActionResult Index()
        {
            var lista = db.Ordens.AsNoTracking().Include(n => n.Cliente).Include(n => n.Equipamento).ToList();
            return View(lista);
        }

        // GET: Ordem/Details/5
        public ActionResult Details(int id)
        {
            var list = ordemService.Get(id);
            foreach (var item in list.Itens)
            {
                item.Total = item.Valor * (item.Quantidade);
                ViewBag.totalitem = db.OrdemItens.Where(n => n.OrdemId == id).Sum(n=> n.Valor *n.Quantidade);
                
            }
            return View(list);
        }

        // GET: Ordem/Create
        public ActionResult Create()
        {
            //ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            //ViewBag.EquipamentoId = new SelectList(db.Equipamentos, "Id", "Modelo");
            //ViewBag.ServicoId = new SelectList(db.Servicos, "Id", "Descricao");

            CarregarViewBag();

            return View();
        }

        public JsonResult ListaEquipamentos(int clienteId)
        {
            var equipamentos = db.Equipamentos.AsNoTracking().Where(n => n.ClienteId == clienteId).ToList();

            var lista = equipamentos.Select(n => new
            {
                n.Id,
                n.Modelo,
                n.NumeroSerie
            })
            .ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        // POST: Ordem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ordem ordem)
        {
            try
            {
                if (ordem?.Id == 0)
                {
                    ordem.Abertura = DateTime.Now;
                    db.Ordens.Add(ordem);
                    db.SaveChanges();
                    return RedirectToAction("Edit", new { id = ordem.Id });
                }
            }
            catch
            {
                CarregarViewBag(ordem);
                return View();
            }



            //if (ordem?.Id == 0)
            //{
            //    ordem.Abertura = DateTime.Now;
            //    db.Ordens.Add(ordem);
            //    db.SaveChanges();
            //    return RedirectToAction("Edit", new { id = ordem.Id });
            //}

            //CarregarViewBag(ordem);

            return View();
        }

        // GET: Ordem/Edit/5
        public ActionResult Edit(int? id)
        {
            Ordem ordem = db.Ordens.Find(id);

            if (ordem == null)
            {
                return HttpNotFound();
            }

            CarregarViewBag(ordem);

            return View(ordem);
        }

        // POST: Ordem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ordem ordem)
        {
            var item = db.Ordens.Find(ordem.Id);

            if (ModelState.IsValid && item != null)
            {
                item.ClienteId = ordem.ClienteId;
                item.EquipamentoId = ordem.EquipamentoId;
                item.Descricao = ordem.Descricao;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CarregarViewBag(ordem);

            return View(ordem);
        }

        private void CarregarViewBag(Ordem ordem = null)
        {
            CarregarClientesNaViewBag(ordem);
            CarregarEquipametosNaViewBag(ordem);

            if (ordem != null)
                CarregarServicosNaViewBag();
        }

        private void CarregarClientesNaViewBag(Ordem ordem = null)
        {
            var clientes = new List<Cliente>
            {
                //new Cliente { Nome = "Escolha um cliente..." }
            };

            var lista = db.Clientes.AsNoTracking().ToList();
            clientes.AddRange(lista);

            ViewBag.Clientes = clientes;
            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nome", ordem?.ClienteId);
        }

        private void CarregarEquipametosNaViewBag(Ordem ordem = null)
        {
            var equipamentos = new List<Equipamento>
            {
                //new Equipamento { Modelo = "Escolha um equipamento..." }
            };

            if (ordem?.ClienteId > 0)
            {
                var lista = db.Equipamentos.AsNoTracking().Where(n => n.ClienteId == ordem.ClienteId).ToList();
                equipamentos.AddRange(lista);
            }

            ViewBag.Equipamentos = equipamentos;
            ViewBag.EquipamentoId = new SelectList(equipamentos, "Id", "Modelo", ordem?.EquipamentoId);
        }

        private void CarregarServicosNaViewBag()
        {
            ViewBag.ServicoId = new SelectList(db.Servicos.AsNoTracking(), "Id", "Descricao");
        }


        // GET: Ordem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ordem ordem = db.Ordens.Find(id);

            if (ordem == null)
            {
                return HttpNotFound();
            }

            return View(ordem);
        }

        // POST: Ordem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var ordem = db.Ordens.Find(id);

            if (ordem == null)
            {
                return RedirectToAction("Index");
            }

            var itens = ordem.Itens;
            db.OrdemItens.RemoveRange(itens);
            db.Ordens.Remove(ordem);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult FinalizarOrdem(int id)
        {
            var item = db.Ordens.Find(id);

            if (ModelState.IsValid && item != null)
            {
                item.Fechamento = DateTime.Now;
                db.SaveChanges();
                return Redirect("index");
            }
            return HttpNotFound();

        }
    }
}
