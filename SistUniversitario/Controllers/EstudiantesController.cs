using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class EstudiantesController : Controller
    {

        UniversidadEntities modeloBD = new UniversidadEntities();
        // GET: Estudiantes
        public ActionResult ListaEstudiantes()
        {

            ///crea la variable que muestra los registros obtenidos

            List<saEstudiantesSelect_Result> modeloVista =
                new List<saEstudiantesSelect_Result>();

            ///asigna la  variable al resultado y llama al procedimiento alamacenadao
            modeloVista = this.modeloBD.saEstudiantesSelect("").ToList();

            ///muestra la vista en el modelo
            return View(modeloVista);

        }

        public ActionResult EstudianteModifica(int id_estudiante)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

           saRetornaEstudiante_ID_Result modeloVista = new saRetornaEstudiante_ID_Result();

            modeloVista = this.modeloBD.saRetornaEstudiante_ID(id_estudiante).FirstOrDefault();

         
            ///Enviar modelo a la vista 
            return View(modeloVista);


        }

        [HttpPost]

        public ActionResult EstudianteModifica(saRetornaEstudiante_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saEstudiantesUpdate(
                    modeloVista.id_estudiante,
                    modeloVista.nombre,
                    modeloVista.cedula,
                    modeloVista.id_provincia,
                    modeloVista.id_canton,
                    modeloVista.id_distrito,
                    modeloVista.carne
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


        public ActionResult EstudianteNuevo()
        {
           
            return View();
        }


        [HttpPost]

        public ActionResult EstudianteNuevo(saEstudiantesSelect_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados =
                      this.modeloBD.saEstudiantesInsert(
                         modeloVista.Nombre,
                         modeloVista.cedula,
                         modeloVista.id_provincia,
                         modeloVista.id_canton,
                         modeloVista.id_distrito,
                         modeloVista.Carne
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

        public ActionResult EstudianteElimina(int id_estudiante)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaEstudiante_ID_Result modeloVista = new saRetornaEstudiante_ID_Result();

            modeloVista = this.modeloBD.saRetornaEstudiante_ID(id_estudiante).FirstOrDefault();

           
            this.AgregaDistritosViewBag();
            this.AgregaProvinciasViewBag();
            this.AgregaCantonesViewBag();

            ///Enviar modelo a la vista 
            return View(modeloVista);

        }

        [HttpPost]

        public ActionResult EstudianteElimina(saRetornaEstudiante_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saEstudiantesDelete(
                    modeloVista.id_estudiante);
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

         
            this.AgregaDistritosViewBag();
            this.AgregaProvinciasViewBag();
            this.AgregaCantonesViewBag();

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }

  
        void AgregaProvinciasViewBag()
        {
            this.ViewBag.ListaProvincias = this.modeloBD.RetornaProvincias(null).ToList();

        }

        void AgregaCantonesViewBag()
        {
            this.ViewBag.ListaCantones = this.modeloBD.RetornaCantones(null, null).ToList();

        }

        void AgregaDistritosViewBag()
        {
            this.ViewBag.ListaDistrito = this.modeloBD.RetornaDistritos(null, null).ToList();
        }


    }
}