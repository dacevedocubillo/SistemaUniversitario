using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class CreacionCuatrimestreController : Controller
    {
        UniversidadEntities modeloBD = new UniversidadEntities();


        public ActionResult CuatrimestreLista()
        {

            List<saCreacionSelect_Result> modeloVista =
                new List<saCreacionSelect_Result>();

         
            modeloVista = this.modeloBD.saCreacionSelect().ToList();

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





        public ActionResult CreacionCuatrimestre()
        {
            this.AgregaCuatrimestreViewBag();
            this.AgregaCursosViewBag();
            this.AgregaSedesViewBag();
            return View();
        }


        [HttpPost]
        public ActionResult CreacionCuatrimestre(saCreacionSelect_Result modeloVista)
        {

            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados =
                      this.modeloBD.saCreacionInsert(
                         modeloVista.id_sede,
                         modeloVista.id_ncuatrimestre,
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
                    resultado = "Cuatrimestre creado";

                }
                else
                {
                    resultado = ".No se pudo crear el cuatrimestre";

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