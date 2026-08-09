using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class CursosCarreraController : Controller
    {
        UniversidadEntities modeloBD = new UniversidadEntities();
        // GET: CursosCarrera


        public ActionResult ListaCursosCarrera()
        {

            ///crea la variable que muestra los registros obtenidos

            List<saCursosCarreraSelect_Result> modeloVista =
                new List<saCursosCarreraSelect_Result>();

            ///asigna la  variable al resultado y llama al procedimiento alamacenadao
            modeloVista = this.modeloBD.saCursosCarreraSelect("").ToList();

            ///muestra la vista en el modelo
            return View(modeloVista);

        }



        public ActionResult CursoCarreraNuevo()
        {
            this.AgregaCarreraViewBag();
            this.AgregaCursosViewBag();
            return View();
        }


        [HttpPost]

        public ActionResult CursoCarreraNuevo(saCursosCarreraSelect_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados =
                      this.modeloBD.saCursosCarreraInsert(
                          modeloVista.id_carrera,
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

            this.AgregaCarreraViewBag();
            this.AgregaCursosViewBag();

            /// Unico modelo 
            /// Conexion entre la vista y el modelo
            ///
            return View();
        }

        void AgregaCursosViewBag()
        {
            this.ViewBag.ListaCursos = this.modeloBD.RetornaCurso("").ToList();

        }

        void AgregaCarreraViewBag()
        {
            this.ViewBag.ListaCarrera =this.modeloBD.RetornaCarrera("").ToList();
        }


        public ActionResult CursosCarreraModifica(int id_cursoscarrera)
        {
            ///obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaCursosCarrera_ID_Result modeloVista = new saRetornaCursosCarrera_ID_Result();

            modeloVista = this.modeloBD.saRetornaCursosCarrera_ID(id_cursoscarrera).FirstOrDefault();

            this.AgregaCarreraViewBag();
            this.AgregaCursosViewBag();

            ///Enviar modelo a la vista 
            return View(modeloVista);
        }

        [HttpPost]

        public ActionResult CursosCarreraModifica(saRetornaCursosCarrera_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saCursosCarreraUpdate(
                    modeloVista.id_cursoscarrera,
                    modeloVista.id_carrera,
                    modeloVista.id_curso
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
                    resultado = "Registro modificado";

                }
                else
                {
                    resultado = ".No se pudo modificar";

                }

            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            this.AgregaCarreraViewBag();
            this.AgregaCursosViewBag();
            return View(modeloVista);

        }


        public ActionResult CursosCarreraElimina(int id_cursoscarrera)
        {

            ///obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona
            saRetornaCursosCarrera_ID_Result modeloVista = new saRetornaCursosCarrera_ID_Result();

            modeloVista = this.modeloBD.saRetornaCursosCarrera_ID(id_cursoscarrera).FirstOrDefault();
            this.AgregaCarreraViewBag();
            this.AgregaCursosViewBag();

            return View(modeloVista);

        }

        [HttpPost]
        public ActionResult CursosCarreraElimina(saRetornaCursosCarrera_ID_Result modeloVista)
        {

            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {


                cantidadRegistrosAfectados = this.modeloBD.saCursosCarreraDelete(modeloVista.id_cursoscarrera);


            }
            catch (Exception error)
            {
                resultado = "Ocurrio un error " + error.Message;
            }
            finally
            {
                if (cantidadRegistrosAfectados > 0)
                {
                    resultado = "Registro eliminado";

                }
                else
                {
                    resultado = ".No se pudo eliminar";

                }

            }

            this.AgregaCarreraViewBag();
            this.AgregaCursosViewBag();

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }

    }
}