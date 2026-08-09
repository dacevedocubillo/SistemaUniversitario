using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class CursosController : Controller
    {
        UniversidadEntities modeloBD = new UniversidadEntities();

        // GET: Cursos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaCurso()
        {

            ///crea la variable que muestra los registros obtenidos

            List<saCursosSelect_Result> modeloVista =
                new List<saCursosSelect_Result>();

            ///asigna la  variable al resultado y llama al procedimiento alamacenadao

            modeloVista = this.modeloBD.saCursosSelect("").ToList();


            ///muestra la vista en el modelo
            return View(modeloVista);
        }

        public ActionResult CursoModifica(int id_curso)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaCurso_ID_Result modeloVista = new saRetornaCurso_ID_Result();

            modeloVista = this.modeloBD.saRetornaCurso_ID(id_curso).FirstOrDefault();

            ///Enviar modelo a la vista 
            return View(modeloVista);

  

        }

        [HttpPost]

        public ActionResult CursoModifica(saRetornaCurso_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saCursosUpdate(
                    modeloVista.idCurso,
                    modeloVista.Codigo,
                    modeloVista.nombreCurso
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
            return View(modeloVista);

        }

        public ActionResult CursoElimina(int id_curso)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaCurso_ID_Result modeloVista = new saRetornaCurso_ID_Result();

            modeloVista = this.modeloBD.saRetornaCurso_ID(id_curso).FirstOrDefault();

            ///Enviar modelo a la vista 
            return View(modeloVista);

        }


        [HttpPost]
        public ActionResult CursoElimina(saRetornaCurso_ID_Result modeloVista)
        {

            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {


                cantidadRegistrosAfectados = this.modeloBD.saCursosDelete(modeloVista.idCurso);


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
         
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);
        }


        public ActionResult CursoNuevo()
        {
            return View();
        }


        [HttpPost]

        public ActionResult CursoNuevo(saCursosSelect_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados =
                      this.modeloBD.saCursosInsert(
                          modeloVista.Codigo,
                          modeloVista.Curso
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

          
            /// Unico modelo 
            /// Conexion entre la vista y el modelo
            ///
            return View();
        }


    }
}