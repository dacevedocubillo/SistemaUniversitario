using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class OfertaController : Controller
    {

        UniversidadEntities modeloBD = new UniversidadEntities();
        // GET: Oferta
        public ActionResult Oferta()
        {

            ///crea la variable que muestra los registros obtenidos

            List<saOfertaSelect_Result> modeloVista =
                new List<saOfertaSelect_Result>();

            ///asigna la  variable al resultado y llama al procedimiento alamacenadao
            modeloVista = this.modeloBD.saOfertaSelect("").ToList();


            ///muestra la vista en el modelo
            return View(modeloVista);
        }


        void AgregaCursosViewBag()
        {
            this.ViewBag.ListaCursos = this.modeloBD.RetornaCurso("").ToList();
        }


        void AgregaSedesViewBag()
        {

            this.ViewBag.ListaSedes = this.modeloBD.RetornaSedes("").ToList();
        }


        void AgregaCuatrimestreViewBag()
        {

            this.ViewBag.ListaCuatrimestre = this.modeloBD.RetornaCuatrimestre("").ToList();
        }



        public ActionResult OfertaNueva()
        {
            this.AgregaCuatrimestreViewBag();
            this.AgregaCursosViewBag();
            this.AgregaSedesViewBag();
            return View();
        }


        [HttpPost]

        public ActionResult OfertaNueva(saOfertaSelect_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados =
                      this.modeloBD.saOfertaInsert(
                         modeloVista.id_sede,
                         modeloVista.id_cuatrimestre,
                         modeloVista.id_curso
                          );
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error " + error.Message;
            }
            finally
            {
                if (cantidadRegistrosAfectados > 0)
                {
                    resultado = "Registro insertado";

                }
                else
                {
                    resultado = ".No se pudo insertar";

                }
            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");

            this.AgregaCuatrimestreViewBag();
            this.AgregaCursosViewBag();
            this.AgregaSedesViewBag();

            return View();
        }



    }
}