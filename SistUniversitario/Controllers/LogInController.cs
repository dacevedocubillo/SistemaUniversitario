using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class LogInController : Controller
    {
        UniversidadEntities modeloBD = new UniversidadEntities();

        // GET: LogIn
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        //Método post de login (cuando da click es el boton submit)
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult VerificaLogin(RetornaUsuarioCorreoPwd_Result pModelo)
        {
            if (pModelo == null || string.IsNullOrWhiteSpace(pModelo.correoElectronico) || string.IsNullOrWhiteSpace(pModelo.contrasena))
            {
                ModelState.AddModelError("", "Debe ingresar el correo y la contraseña.");
                return View("Index", pModelo);
            }

            //Buscar el usuario tomando en cuenta la contraseña y el correo electronico 

            RetornaUsuarioCorreoPwd_Result usuarioBuscar =
                this.modeloBD.RetornaUsuarioCorreoPwd(pModelo.correoElectronico, pModelo.contrasena).FirstOrDefault();

            //Si la consulta retorna null
            //indica que la consulata (usuario y contraseña) no
            //retorno ningun valor, es decir la combinacion (and)


            if (usuarioBuscar == null)
            {

                //permanecee en el index del controlador
                this.ModelState.AddModelError("", "Usuario o contraseña inválidos. Por favor verifique");
                return View("Index");
            }
            else
            {
                ///establecer los datos de sesion para que
                /// cuando el layout consulte dichos datos
                /// no redireccione el login

                this.Session["logueado"] = true;


                ///agregamos todo el modelo del usuario
                this.Session["datosusuario"] = usuarioBuscar;
                this.Session["ultimoAcceso"] = usuarioBuscar.Fecha_Ingreso;

                //redireccionar al metodo
                //index del controlador

                return RedirectToAction("Bievenida", "Inicio");


            }


        }

        /// <summary>
        /// Cierra la sesion y establece los valores de las variables de sesion
        /// </summary>
        /// <returns></returns>

        public ActionResult CierraSesion()
        {

            ///establecer los datos de sesion para 
            ///cuando el layout consulte por dichos datos
            ///re-direccione a log in

            this.Session.Clear();
            this.Session.Abandon();

            //redireccionar al método
            //index del controlador login

            return RedirectToAction("Index", "Login");

        }


    }



}
