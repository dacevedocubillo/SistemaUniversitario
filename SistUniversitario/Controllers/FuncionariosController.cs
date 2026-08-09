using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class FuncionariosController : Controller
    {

        UniversidadEntities modeloBD = new UniversidadEntities();
        // GET: Funcionarios
        public ActionResult ListaFuncionarios()
        {

            ///crea la variable que muestra los registros obtenidos

            List<saFuncionariosSelect_Result> modeloVista =
                new List<saFuncionariosSelect_Result>();

            ///asigna la  variable al resultado y llama al procedimiento alamacenadao
            modeloVista = this.modeloBD.saFuncionariosSelect("").ToList();

            ///muestra la vista en el modelo
            return View(modeloVista);
        }


        public ActionResult FuncionarioNuevo()
        {

            return View();
        }


        [HttpPost]

        public ActionResult FuncionarioNuevo(saFuncionariosSelect_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados =
                      this.modeloBD.saFuncionarioInsert(
                         modeloVista.funcionario,
                         modeloVista.cedula,
                         modeloVista.id_provincia,
                         modeloVista.id_canton,
                         modeloVista.id_distrito,
                         modeloVista.fecha_contratacion);
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



        public ActionResult FuncionarioModifica(int id_funcionario)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaFuncionario_ID_Result modeloVista = new saRetornaFuncionario_ID_Result();

            modeloVista = this.modeloBD.saRetornaFuncionario_ID(id_funcionario).FirstOrDefault();



            ///Enviar modelo a la vista 
            return View(modeloVista);


        }


        [HttpPost]

        public ActionResult FuncionarioModifica(saRetornaFuncionario_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saFuncionarioUpdate(
                    modeloVista.id_funcionario,
                    modeloVista.nombre,
                    modeloVista.cedula,
                    modeloVista.id_provincia,
                    modeloVista.id_canton,
                    modeloVista.id_distrito,
                    modeloVista.fecha_contratacion
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




        public ActionResult FuncionarioElimina(int id_funcionario)
        {

            //obtener registro que se desea modificar
            /// utilizando el parametro del método id_Persona

            saRetornaFuncionario_ID_Result modeloVista = new saRetornaFuncionario_ID_Result();

            modeloVista = this.modeloBD.saRetornaFuncionario_ID(id_funcionario).FirstOrDefault();
            this.AgregaProvinciasViewBag();
            this.AgregaDistritosViewBag();
            this.AgregaCantonesViewBag();

            ///Enviar modelo a la vista 
            return View(modeloVista);


        }


        [HttpPost]

        public ActionResult FuncionarioElimina(saRetornaFuncionario_ID_Result modeloVista)
        {
            //Variable que registra la cantidad de registros afectados
            //si un procedimiento que ejecuta insert,delete y update
            //no afecta regristros implica que hubo error
            int cantidadRegistrosAfectados = 0;
            string resultado = "";

            try
            {
                cantidadRegistrosAfectados = this.modeloBD.saFuncionarioDelete(modeloVista.id_funcionario );
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
                    resultado = ".No se pudo eliminado";

                }

            }

            this.AgregaProvinciasViewBag();
            this.AgregaDistritosViewBag();
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
