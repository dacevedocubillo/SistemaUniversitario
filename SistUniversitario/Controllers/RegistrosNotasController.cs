using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class RegistrosNotasController : Controller
    {
        UniversidadEntities modeloBD = new UniversidadEntities();

        // GET: RegistrosNotas
        public ActionResult ListaNotas()
        {

            ///crea la variable que muestra los registros obtenidos

            List<saRegistroNotasSelect_Result> modeloVista =
                new List<saRegistroNotasSelect_Result>();

            ///asigna la  variable al resultado y llama al procedimiento alamacenadao
            modeloVista = this.modeloBD.saRegistroNotasSelect("").ToList();


            ///muestra la vista en el modelo
            return View(modeloVista);

            
        }


        void AgregaEstadoViewBag()
        {
            this.ViewBag.ListaEstado = this.modeloBD.RetornaEstado("").ToList();

        }

        void AgregaEstudianteViewBag()
        {
            this.ViewBag.ListaEstudiante = this.modeloBD.RetornaEstudiante("").ToList();

        }

        void AgregaCursosViewBag()
        {
            this.ViewBag.ListaCursos = this.modeloBD.RetornaCurso("").ToList();
        }


        void AgregaSedesViewBag()
        {

            this.ViewBag.ListaSedes = this.modeloBD.RetornaSedes("").ToList();
        }



        public ActionResult RegistroNuevoNota()
        {
            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaEstudianteViewBag();
            this.AgregaEstadoViewBag();
            return View();
        }


        [HttpPost]

        public ActionResult RegistroNuevoNota(saRegistroNotasSelect_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados =
                      this.modeloBD.saNotasInsert(
                          modeloVista.idestudiante,
                          modeloVista.id_curso,
                          modeloVista.id_sede,
                          modeloVista.notafinal,
                          modeloVista.id_estado
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
                    resultado = "Nota ingresada correctamente";

                }
                else
                {
                    resultado = ".No se pudo ingresar la nota";

                }
            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");

            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaEstudianteViewBag();
            this.AgregaEstadoViewBag();
            return View();
        }



        public ActionResult RegistroNotaModifica(int idRegistro_Notas)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRegistro_ID_Result modeloVista = new saRegistro_ID_Result();

            modeloVista = this.modeloBD.saRegistro_ID(idRegistro_Notas).FirstOrDefault();

            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaEstudianteViewBag();
            this.AgregaEstadoViewBag();

            ///Enviar modelo a la vista 
            return View(modeloVista);


        }

        [HttpPost]

        public ActionResult RegistroNotaModifica(saRegistro_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saRegistrosUpdate(
                   modeloVista.idRegistro_Notas,
                          modeloVista.idestudiante,
                          modeloVista.id_curso,
                          modeloVista.id_sede,
                          modeloVista.notafinal,
                          modeloVista.id_estado
                    );
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

            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaEstudianteViewBag();
            this.AgregaEstadoViewBag();
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }


        public ActionResult RegistroNotaElimina(int idRegistro_Notas)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRegistro_ID_Result modeloVista = new saRegistro_ID_Result();

            modeloVista = this.modeloBD.saRegistro_ID(idRegistro_Notas).FirstOrDefault();

            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaEstudianteViewBag();
            this.AgregaEstadoViewBag();

            ///Enviar modelo a la vista 
            return View(modeloVista);


        }

        [HttpPost]

        public ActionResult RegistroNotaElimina(saRegistro_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saRegistroDelete(
                   modeloVista.idRegistro_Notas
                    );
            }
            catch (Exception error)
            {

                resultado = "Ocurrio un error " + error.Message;
            }
            finally
            {
                if (cantidadRegistrosAfectados > 0)
                {
                    resultado = "Nota eliminada correctamente";

                }
                else
                {
                    resultado = ".No se pudo eliminar la nota";

                }

            }

            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaEstudianteViewBag();
            this.AgregaEstadoViewBag();
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }



    }
}