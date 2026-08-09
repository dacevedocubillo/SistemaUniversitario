using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class InicioController : Controller
    {

        UniversidadEntities modeloBD = new UniversidadEntities();
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Bievenida()
        {
            bool sesionIniciada = false;


            //consultar si el key "logueado" de la sesion
            //posee un valor


            if (this.Session["logueado"] != null)
            {
                sesionIniciada = Convert.ToBoolean(this.Session["logueado"]);
            }

            if (sesionIniciada == true)
            {
                //recontruir datos del modelo accediendo al objeto session

                RetornaUsuarioCorreoPwd_Result modelo = (RetornaUsuarioCorreoPwd_Result)this.Session["datosusuario"];

                return View(modelo);
            }
            else
            {
                //redireccionar al metodo indes del controlador login


                return RedirectToAction("", "");

            }
        }

    }
}