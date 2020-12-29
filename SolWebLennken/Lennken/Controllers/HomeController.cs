using Lennken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lennken.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            busLennken obj = new busLennken();
            List<Producto> ls = new List<Producto>();
            ls = obj.Obtener();
            return View(ls);
        }
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Agregar(Producto d)
        {
            busLennken obj = new busLennken();
            obj.Agregar(d);
            TempData["a"] = "Se Agrego correctamente";
            return View("Index");
        }

        public ActionResult Editar(int id)
        {
            busLennken obj = new busLennken();
            Producto a = new Producto();
            a = obj.ObtenerProduto(id);
            return View(a);
        }
        [HttpPost]
        public ActionResult Editar(Producto a)
        {
            busLennken obj = new busLennken();
            
            obj.Editar(a);
            return View(a);
        }
        public ActionResult Borrar(int id)
        {
            busLennken obj = new busLennken();
            Producto a = new Producto();
            a = obj.ObtenerProduto(id);
            return View(a);

        }
        [HttpPost]
        public ActionResult Borrar(Producto b)
        {
            busLennken obj = new busLennken();

            obj.Borrar(b.Id);
            return View("Index");
        }
        public ActionResult Detalles(Producto a)
        {
            busLennken obj = new busLennken();
           
            a = obj.ObtenerProduto(a.Id);
            return View(a);
        }
    }
}