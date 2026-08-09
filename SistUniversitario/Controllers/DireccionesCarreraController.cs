using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class DireccionesCarreraController : Controller
    {
        UniversidadEntities modeloBD = new UniversidadEntities();

        // GET: DireccionesCarrera
        public ActionResult ListaDireccionCarrera()
        {
            ///crea la variable que muestra los registros obtenidos

            List<saDireccionesCarreraSelect_Result> modeloVista =
                new List<saDireccionesCarreraSelect_Result>();

            ///asigna la  variable al resultado y llama al procedimiento alamacenadao
            modeloVista = this.modeloBD.saDireccionesCarreraSelect("").ToList();

            ///muestra la vista en el modelo
            return View(modeloVista);
        }


        public ActionResult DireccionesCarreraNueva()
        {

            this.AgregaDirectorViewBag();
            this.AgregaSubDirectorViewBag();
            return View();
        }

   
        [HttpPost]

        public ActionResult DireccionesCarreraNueva(saDireccionesCarreraSelect_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados =
                    this.modeloBD.saDireccionCarreraInsert(
                        modeloVista.Codigo,
                        modeloVista.id_director,
                        modeloVista.id_subdirector,
                        modeloVista.Nombre
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
            /// this.AgregaProvinciasViewBag();

            this.AgregaDirectorViewBag();
            this.AgregaSubDirectorViewBag();
           
            return View();
        }

        void AgregaDirectorViewBag()
        {
            this.ViewBag.ListaDirector =
                this.modeloBD.RetornaFuncionario("").ToList();

        }

        void AgregaSubDirectorViewBag()
        {
            this.ViewBag.ListaSubDirector =
                this.modeloBD.RetornaFuncionario("").ToList();

        }


        public ActionResult DireccionesCarreraModifica(int idDcarrera)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaDirecciones_ID_Result modeloVista = new saRetornaDirecciones_ID_Result();

            modeloVista = this.modeloBD.saRetornaDirecciones_ID(idDcarrera).FirstOrDefault();

            this.AgregaDirectorViewBag();
            this.AgregaSubDirectorViewBag();

            ///Enviar modelo a la vista 
            return View(modeloVista);



        }

        [HttpPost]

        public ActionResult DireccionesCarreraModifica(saRetornaDirecciones_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saDireccionesCarrerasUpdate(
                    modeloVista.idDcarrera,
                    modeloVista.Codigo,
                    modeloVista.id_director,
                    modeloVista.id_subdirector,
                    modeloVista.Nombre
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

            this.AgregaDirectorViewBag();
            this.AgregaSubDirectorViewBag();
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }


        public ActionResult DireccionesCarreraElimina(int idDcarrera)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaDirecciones_ID_Result modeloVista = new saRetornaDirecciones_ID_Result();

            modeloVista = this.modeloBD.saRetornaDirecciones_ID(idDcarrera).FirstOrDefault();

            this.AgregaDirectorViewBag();
            this.AgregaSubDirectorViewBag();

            ///Enviar modelo a la vista 
            return View(modeloVista);



        }

        [HttpPost]

        public ActionResult DireccionesCarreraElimina(saRetornaDirecciones_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saDirreccionCarreraDelete(modeloVista.idDcarrera);
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

            this.AgregaDirectorViewBag();
            this.AgregaSubDirectorViewBag();
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }



    }
}