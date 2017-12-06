using Modelo;
using Servico;
using System.Web.Mvc;

namespace ClienteWeb.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private ClienteService service;


        public ClienteController()
        {
            service = new ClienteService();
        }

        /// <summary>
        /// Metodo Lista todos os Clientes
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        // GET: Cliente
        public ActionResult Index()
        {
            var lista = service.Load();
            return View(lista);
        }

        /// <summary>
        /// Detalhes de 1 Cliente
        /// </summary>
        /// <param name="id">ID Cliente</param>
        /// <returns></returns>
        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var result = service.Get(id);
            return View(result);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Cria um novo Cliente 
        /// </summary>
        /// <param name="entity">Objeto do tipo Cliente</param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Edita o Cliente
        /// </summary>
        /// <param name="id">ID Cliente</param>
        /// <returns></returns>
        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var result = service.Get(id);
            return View(result);
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

        /// <summary>
        /// Deleta um Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            var result = service.Get(id);
            return View(result);
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
