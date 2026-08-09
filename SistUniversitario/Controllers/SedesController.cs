using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class SedesController : Controller
    {
        UniversidadEntities modeloBD = new UniversidadEntities();

        // GET: Sedes
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ListaSedes()
        {

            ///crea la variable que muestra los registros obtenidos

            List<saSedesSelect_Result> modeloVista =
                new List<saSedesSelect_Result>();

            ///asigna la  variable al resultado y llama al procedimiento alamacenadao
            modeloVista = this.modeloBD.saSedesSelect(null).ToList();


            ///muestra la vista en el modelo
            return View(modeloVista);

        }


        public ActionResult SedeNueva()
        {
            this.AgregaSedesViewBag();
            this.AgregaFuncionarioViewBag();
            return View();
        }


        [HttpPost]

        public ActionResult SedeNueva(saSedesSelect_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados =
                      this.modeloBD.saSedesInsert(
                        modeloVista.idSedeuniversitaria,
                        modeloVista.codigo,
                        modeloVista.id_funcionario,
                        modeloVista.id_provincia,
                        modeloVista.id_canton,
                        modeloVista.id_distrito,
                        modeloVista.DireccionFisica
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


            this.AgregaSedesViewBag();
            this.AgregaFuncionarioViewBag();

            /// Unico modelo 
            /// Conexion entre la vista y el modelo
            ///
            return View();
        }

        public ActionResult SedeElimina(int idSedeuniversitaria)
        {

            ///obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona
            saRetornaSede_ID_Result modeloVista = new saRetornaSede_ID_Result();

            modeloVista = this.modeloBD.saRetornaSede_ID(idSedeuniversitaria).FirstOrDefault();

            this.AgregaCantonesViewBag();
            this.AgregaDistritosViewBag();
            this.AgregaSedesViewBag();
            this.AgregaFuncionarioViewBag();
            this.AgregaProvinciasViewBag();
            return View(modeloVista);

        }

        [HttpPost]
        public ActionResult SedeElimina(saRetornaSede_ID_Result modeloVista)
        {

            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {


                cantidadRegistrosAfectados = this.modeloBD.saSedeDelete(modeloVista.idSedeuniversitaria);


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


            this.AgregaCantonesViewBag();
            this.AgregaDistritosViewBag();
            this.AgregaSedesViewBag();
            this.AgregaFuncionarioViewBag();
            this.AgregaProvinciasViewBag();
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }

        /// <summary>
        /// Retorna todas las provincias
        /// </summary>
        /// <returns></returns>
        public ActionResult RetornaProvincias()
        {
            List<RetornaProvincias_Result> provincias =
                this.modeloBD.RetornaProvincias("").ToList();

            return Json(provincias);
        }

        /// <summary>
        /// Retorna Cantones
        /// </summary>
        /// <param name="id_Provincia">id de provincia</param>
        /// <returns></returns>

        public ActionResult RetornaCantones(int id_Provincia)
        {
            List<RetornaCantones_Result> cantones =
               this.modeloBD.RetornaCantones(null, id_Provincia)
               .ToList();

            return Json(cantones);

        }

        /// <summary>
        /// Retorna Distritos
        /// </summary>
        /// <returns></returns>
        public ActionResult RetornaDistritos(int id_Canton)
        {
            List<RetornaDistritos_Result> distritos =
                this.modeloBD.RetornaDistritos("", id_Canton).ToList();

            return Json(distritos);
        }

        void AgregaFuncionarioViewBag()
        {
            this.ViewBag.ListaFuncionario =
                this.modeloBD.RetornaFuncionario(null).ToList();

        }

        void AgregaSedesViewBag()
        {
            this.ViewBag.ListaSedes = this.modeloBD.RetornaSedes(null).ToList();

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


        public ActionResult SedeModifica(int idSedeuniversitaria)
        {
            ///obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaSede_ID_Result modeloVista = new saRetornaSede_ID_Result();

            modeloVista = this.modeloBD.saRetornaSede_ID(idSedeuniversitaria).FirstOrDefault();
            this.AgregaSedesViewBag();
            this.AgregaFuncionarioViewBag();
            ///Enviar modelo a la vista 
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult SedeModifica(saRetornaSede_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saSedesUpdate(
                   modeloVista.idSedeuniversitaria,
    modeloVista.id_matriculasede,
    modeloVista.codigo,
    modeloVista.id_funcionario,
    modeloVista.id_provincia,
    modeloVista.id_canton,
    modeloVista.id_distrito,
    modeloVista.DireccionFisica
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
            this.AgregaCantonesViewBag();
            this.AgregaDistritosViewBag();
            this.AgregaSedesViewBag();
            this.AgregaFuncionarioViewBag();
            this.AgregaProvinciasViewBag();
            return View(modeloVista);

        }
    }
}