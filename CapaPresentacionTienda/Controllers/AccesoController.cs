using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionTienda.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }


        public ActionResult Restablecer()
        {
            return View();
        }

        public ActionResult CambiarClave()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Registrar(Cliente objeto)
        {

            int resultado;
            string mensaje = string.Empty;

            ViewData["Nombres"] = string.IsNullOrEmpty(objeto.Nombres) ? "" : objeto.Nombres;
            ViewData["Apellidos"] = string.IsNullOrEmpty(objeto.Apellidos) ? "" : objeto.Apellidos;
            ViewData["Correo"] = string.IsNullOrEmpty(objeto.Correo) ? "" : objeto.Correo;

            if (objeto.Clave != objeto.ConfirmarClave)
            {
                ViewBag.Error = "Las constraseñas no coinciden";
                return View();
            }

            resultado = new CN_Cliente ().Registrar(objeto, out mensaje); 

            if (resultado > 0)
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Accesso");
            }
            else
            {
                ViewBag.Error = mensaje;
                return View();
            }

           
        }

    }
}