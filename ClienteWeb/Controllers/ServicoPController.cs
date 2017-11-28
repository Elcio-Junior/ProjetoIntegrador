using Modelo;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClienteWeb.Controllers
{
    public class ServicoPController : Controller
    {
        private Contexto db = new Contexto();


        // GET: Ordem
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


    }
}