using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class FinalizacionCursoController : Controller
    {
        UniversidadEntities modeloBD = new UniversidadEntities();
        public ActionResult ListaFinalizacion()
        {
            ///crea la variable que muestra los registros obtenidos

            List<saFinalizacionSelect_Result> modeloVista =
                new List<saFinalizacionSelect_Result>();

            ///asigna la  variable al resultado y llama al procedimiento alamacenadao
            modeloVista = this.modeloBD.saFinalizacionSelect().ToList();


            ///muestra la vista en el modelo
            return View(modeloVista);
        }

   

        void AgregaCursosViewBag()
        {
            this.ViewBag.ListaCursos = this.modeloBD.RetornaCurso("").ToList();
        }

        void AgregaEstudiantesViewBag()
        {
            this.ViewBag.ListaEstudiante = this.modeloBD.RetornaEstudiante("").ToList();
        }

        void AgregaEstadoViewBag()
        {
            this.ViewBag.ListaEstado = this.modeloBD.RetornaEstado("").ToList();
        }


        public ActionResult FinalizacionModifica(int id_finalizacion)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRegistro_ID_Result modeloVista = this.modeloBD.saRegistro_ID(id_finalizacion).FirstOrDefault();
            if (modeloVista == null)
            {
                return HttpNotFound();
            }

            this.AgregaCursosViewBag();
            this.AgregaEstudiantesViewBag();
            this.AgregaEstadoViewBag();
            ///Enviar modelo a la vista 
            return View(modeloVista);


        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult FinalizacionModifica(saRegistro_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.Database.ExecuteSqlCommand(
                    "EXEC dbo.saCursoFinalizar @p0", modeloVista.idRegistro_Notas);
            }
            catch (Exception error)
            {

                resultado = "Ocurrio un error " + error.Message;
            }
            finally
            {
                if (cantidadRegistrosAfectados > 0)
                {
                    resultado = "Nota editada correctamente";

                }
                else
                {
                    resultado = ".No se pudo editar la nota";

                }

            }
            this.AgregaCursosViewBag();
            this.AgregaEstudiantesViewBag();
            this.AgregaEstadoViewBag();
     

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }





    }
}
