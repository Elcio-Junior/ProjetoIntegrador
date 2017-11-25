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
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Ordem ordem = db.Ordems.Find(id);
            //if (ordem == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(ordem);
            var list = ordemService.Get(id);
            return View(list);

        }

        // GET: Ordem/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            return View();
        }

        // POST: Ordem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroOS,DtAberturaOs,DtFechamentoOS,Status,ClienteId")] Ordem ordem)
        {
            if (ModelState.IsValid)
            {
                db.Ordems.Add(ordem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", ordem.ClienteId);
            return View(ordem);
        }

        // GET: Ordem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordem ordem = db.Ordems.Find(id);
            if (ordem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", ordem.ClienteId);
            return View(ordem);
        }

        // POST: Ordem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroOS,DtAberturaOs,DtFechamentoOS,Status,ClienteId")] Ordem ordem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", ordem.ClienteId);
            return View(ordem);
        }

        // GET: Ordem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordem ordem = db.Ordems.Find(id);
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
            Ordem ordem = db.Ordems.Find(id);
            db.Ordems.Remove(ordem);
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
