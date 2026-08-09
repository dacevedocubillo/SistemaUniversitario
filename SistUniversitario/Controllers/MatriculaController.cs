using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class MatriculaController : Controller
    {

        UniversidadEntities modeoloBD = new UniversidadEntities();


        void AgregaEstudianteViewBag()
        {
            this.ViewBag.ListaEstudiante = this.modeoloBD.RetornaEstudiante("").ToList();

        }


        void AgregaCursosViewBag()
        {
            this.ViewBag.ListaCursos = this.modeoloBD.RetornaCurso("").ToList();
        }


        void AgregaSedesViewBag()
        {

            this.ViewBag.ListaSedes = this.modeoloBD.RetornaSedes("").ToList();
        }


        void AgregaCuatrimestreViewBag()
        {

            this.ViewBag.ListaCuatrimestre = this.modeoloBD.RetornaCuatrimestre("").ToList();
        }


        // GET: Matricula
        public ActionResult ListaMatricula()
        {
            ///crea la variable que muestra los registros obtenidos

            List<saMatriculaSelect_Result> modeloVista =
                new List<saMatriculaSelect_Result>();

            ///asigna la  variable al resultado y llama al procedimiento alamacenadao
            modeloVista = this.modeoloBD.saMatriculaSelect("").ToList();


            ///muestra la vista en el modelo
            return View(modeloVista);

        }



        public ActionResult MatriculaNueva()
        {
            this.AgregaEstudianteViewBag();
            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaCuatrimestreViewBag();
            return View();
        }


        [HttpPost]

        public ActionResult MatriculaNueva(saMatriculaSelect_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados =
                      this.modeoloBD.saMatriculaInsert(
                          modeloVista.id_estudiante,
                          modeloVista.id_curso,
                          modeloVista.id_sede,
                          modeloVista.id_cuatrimestre
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
                    resultado = "Matricula realizada correctamente";

                }
                else
                {
                    resultado = ".No se pudo realizar la matrícula";

                }
            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");

            this.AgregaEstudianteViewBag();
            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaCuatrimestreViewBag();

            return View();
        }

        public ActionResult MatriculaModifica(int id_matricula)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaMatricula_ID_Result modeloVista = new saRetornaMatricula_ID_Result();

            modeloVista = this.modeoloBD.saRetornaMatricula_ID(id_matricula).FirstOrDefault();

            this.AgregaEstudianteViewBag();
            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaCuatrimestreViewBag();

            ///Enviar modelo a la vista 
            return View(modeloVista);


        }

        [HttpPost]

        public ActionResult MatriculaModifica(saRetornaMatricula_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeoloBD.saMatriculaUpdate(
                          modeloVista.id_matricula,
                          modeloVista.id_estudiante,
                          modeloVista.id_curso,
                          modeloVista.id_sede,
                          modeloVista.id_cuatrimestre
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
                    resultado = "Matricula editada correctamente";

                }
                else
                {
                    resultado = ".No se pudo editar la matrícula";

                }

            }

            this.AgregaEstudianteViewBag();
            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaCuatrimestreViewBag();
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }



        public ActionResult MatriculaElimina(int id_matricula)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaMatricula_ID_Result modeloVista = new saRetornaMatricula_ID_Result();

            modeloVista = this.modeoloBD.saRetornaMatricula_ID(id_matricula).FirstOrDefault();

            this.AgregaEstudianteViewBag();
            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaCuatrimestreViewBag();


            ///Enviar modelo a la vista 
            return View(modeloVista);


        }

        [HttpPost]

        public ActionResult MatriculaElimina(saRetornaMatricula_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeoloBD.saMatriculaDelete(
                   modeloVista.id_matricula
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
                    resultado = "Matricula eliminada correctamente";

                }
                else
                {
                    resultado = ".No se pudo eliminar la matrícula";

                }

            }

            this.AgregaEstudianteViewBag();
            this.AgregaSedesViewBag();
            this.AgregaCursosViewBag();
            this.AgregaCuatrimestreViewBag();
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }





    }
}