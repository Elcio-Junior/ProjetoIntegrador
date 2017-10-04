using Modelo;
using Servico;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ClienteWeb.Controllers
{
    [Authorize]
    public class OrdemController : Controller
    {
        private Contexto db = new Contexto();
        private EquipamentoService equipamentoService;
        private ClienteService clienteService;
        private OrdemService service;
        
        public OrdemController()
        {
            equipamentoService = new EquipamentoService();
            clienteService = new ClienteService();
            service = new OrdemService();
        }

        // GET: Ordem
        public async Task<ActionResult> Index()
        {
            //var ordems = db.Ordems.Include(o => o.cliente);
            //return View(await ordems.ToListAsync());


            var  lista = service.Load();
            return View( lista.ToList());
        }

        // GET: Ordem/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordem ordem = await db.Ordems.FindAsync(id);
            if (ordem == null)
            {
                return HttpNotFound();
            }
            return View(ordem);
        }

        // GET: Ordem/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            return View();
        }

        // POST: Ordem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NumeroOS,DtAberturaOs,DtFechamentoOS,Status,ClienteId")] Ordem ordem)
        {
            if (ModelState.IsValid)
            {
                db.Ordems.Add(ordem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", ordem.ClienteId);
            return View(ordem);
        }

        // GET: Ordem/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordem ordem = await db.Ordems.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,NumeroOS,DtAberturaOs,DtFechamentoOS,Status,ClienteId")] Ordem ordem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", ordem.ClienteId);
            return View(ordem);
        }

        // GET: Ordem/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordem ordem = await db.Ordems.FindAsync(id);
            if (ordem == null)
            {
                return HttpNotFound();
            }
            return View(ordem);
        }

        // POST: Ordem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ordem ordem = await db.Ordems.FindAsync(id);
            db.Ordems.Remove(ordem);
            await db.SaveChangesAsync();
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
