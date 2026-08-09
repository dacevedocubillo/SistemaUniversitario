using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;


namespace SistUniversitario.Controllers
{
    
    public class CuatrimestreController : Controller
    {

        UniversidadEntities modeloBD = new UniversidadEntities();


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



        void AgregaEstadoViewBag()
        {
            this.ViewBag.ListaEstado = this.modeloBD.RetornaEstado("").ToList();

        }

        // GET: Cuatrimestre
        public ActionResult ListaCuatrimestre()
        {
            
                ///crea la variable que muestra los registros obtenidos

                List<saCuatrimestreSelect_Result> modeloVista =
                    new List<saCuatrimestreSelect_Result>();

                ///asigna la  variable al resultado y llama al procedimiento alamacenadao
                modeloVista = this.modeloBD.saCuatrimestreSelect().ToList();


                ///muestra la vista en el modelo
                return View(modeloVista);

            }


        public ActionResult CierreCuatrimestre(int idCuatrimestre)
        {
            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaCuatrimestre_ID_Result modeloVista = new saRetornaCuatrimestre_ID_Result();

            modeloVista = this.modeloBD.saRetornaCuatrimestre_ID(idCuatrimestre).FirstOrDefault();

            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaEstadoViewBag();

            ///Enviar modelo a la vista 
            return View(modeloVista);

        }


        [HttpPost]

        public ActionResult CierreCuatrimestre(saRetornaCuatrimestre_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.Database.ExecuteSqlCommand(
                    "EXEC dbo.saCuatrimestreCerrar @p0", modeloVista.idCuatrimestre);
            }
            catch (Exception error)
            {

                resultado = "No fue posible cerrar el cuatrimestre: " + error.GetBaseException().Message;
            }
            finally
            {
                if (cantidadRegistrosAfectados > 0)
                {
                    resultado = "Cuatrimestre Cerrado";

                }
                else
                {
                    resultado = "No se pudo cerrar el cuatrimestre.";

                }

            }

            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaEstadoViewBag();

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }



    }
}
