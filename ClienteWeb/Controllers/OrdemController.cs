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
            //var ordems = db.Ordems.Include(o => o.cliente);
            //return View(ordems.ToList());
            var lista = ordemService.Load().Include(x => x.Cliente).Include(x=>x.Equipamento);
            return View(lista);
        }

        // GET: Ordem/Details/5
        public ActionResult Details(int id)
        {
            var list = ordemService.Get(id);
            return View(list);
        }

        // GET: Ordem/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.EquipamentoId = new SelectList(db.Equipamentos, "Id", "Modelo");
            ViewBag.ServicoId = new SelectList(db.Servicos, "Id", "Descricao");

            return View();
        }

        //private void CarregarViewBag(int clienteId)
        //{
        //    var equipamentos = db.Equipamentos.Where(n => n.ClienteId == clienteId).ToList();

        //    ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
        //    ViewBag.EquipamentoId = new SelectList(equipamentos, "Id", "Modelo");
        //    ViewBag.ServicoId = new SelectList(db.Servicos, "Id", "Descricao");
        //}

        public JsonResult ListaEquipamentos(int clienteId)
        {
            //var telefones = (from u in model.telefones where u.ClienteID select u.telefone).toList(); //Nesse caso estou usando uma tabela ficticia com os telefones do cliente cadastrado

            var equipamentos = db.Equipamentos.Where(n => n.ClienteId == clienteId).ToList();

            return Json(equipamentos, JsonRequestBehavior.AllowGet);
        }

        // POST: Ordem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ordem ordem)
        {
            if (ordem?.Id == 0)
            {
                ordem.Abertura = DateTime.Now;
                db.Ordens.Add(ordem);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = ordem.Id });
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", ordem.ClienteId);
            ViewBag.EquipamentoId = new SelectList(db.Equipamentos, "Id", "Modelo", ordem.EquipamentoId);
            ViewBag.ServicoId = new SelectList(db.Servicos, "Id", "Descricao");

            //return Json(new { Resultado = ordem.Id }, JsonRequestBehavior.AllowGet);

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

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", ordem.ClienteId);
            ViewBag.EquipamentoId = new SelectList(db.Equipamentos, "Id", "Modelo", ordem.EquipamentoId);
            ViewBag.ServicoId = new SelectList(db.Servicos, "Id", "Descricao");

            return View(ordem);
        }

        // POST: Ordem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
                //return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", ordem.ClienteId);
            ViewBag.EquipamentoId = new SelectList(db.Equipamentos, "Id", "Modelo", ordem.EquipamentoId);
            ViewBag.ServicoId = new SelectList(db.Servicos, "Id", "Descricao");

            return View(ordem);
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
    }
}
