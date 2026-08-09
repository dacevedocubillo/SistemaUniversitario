using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class CarrerasController : Controller
    {

        UniversidadEntities modeloBD = new UniversidadEntities();

        // GET: Carreras
    
        public ActionResult ListaCarrera()
        {

            ///crea la variable que muestra los registros obtenidos

            List<saCarrUniversitariasSelect_Result> modeloVista =
                new List<saCarrUniversitariasSelect_Result>();

            ///asigna la  variable al resultado y llama al procedimiento alamacenadao
            modeloVista = this.modeloBD.saCarrUniversitariasSelect("").ToList();


            ///muestra la vista en el modelo
            return View(modeloVista);

        }


        public ActionResult CarreraModifica(int idCuniversitaria)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaCarrera_ID_Result modeloVista = new saRetornaCarrera_ID_Result();

            modeloVista = this.modeloBD.saRetornaCarrera_ID(idCuniversitaria).FirstOrDefault();

            this.AgregaDireccionViewBag();

            ///Enviar modelo a la vista 
            return View(modeloVista);


        }

        [HttpPost]

        public ActionResult CarreraModifica(saRetornaCarrera_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saCarrUniversitariasUpdate(
                    modeloVista.idCuniversitaria,
                    modeloVista.idDireccionCarrera,
                    modeloVista.Nombre,
                    modeloVista.Codigo
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

            this.AgregaDireccionViewBag();
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);
          
        }

        void AgregaDireccionViewBag()
        {
            this.ViewBag.ListaDireccion =
       this.modeloBD.RetornaDireccion("").ToList();

        }


        public ActionResult CarreraNueva()
        {
            this.AgregaDireccionViewBag();
            return View();
        }


        [HttpPost]

        public ActionResult CarreraNueva(saCarrUniversitariasSelect_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados =
                      this.modeloBD.saCarrUniversitariasInsert(
                         modeloVista.idDireccionCarrera,
                         modeloVista.Nombre,
                         modeloVista.Codigo
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

            this.AgregaDireccionViewBag();
            /// Unico modelo 
            /// Conexion entre la vista y el modelo
            ///
            return View();
        }

        public ActionResult CarreraElimina(int idCuniversitaria)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaCarrera_ID_Result modeloVista = new saRetornaCarrera_ID_Result();

            modeloVista = this.modeloBD.saRetornaCarrera_ID(idCuniversitaria).FirstOrDefault();

            this.AgregaDireccionViewBag();

            ///Enviar modelo a la vista 
            return View(modeloVista);

        }

        [HttpPost]

        public ActionResult CarreraElimina(saRetornaCarrera_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saCarrUniversitariasDelete(
                    modeloVista.idCuniversitaria);
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

            this.AgregaDireccionViewBag();
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);

        }
    }
}