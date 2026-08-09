using System.Linq;
using System.Web.Mvc;
using SistUniversitario.Models;

namespace SistUniversitario.Controllers
{
    public class ReportesController : Controller
    {
        private readonly UniversidadEntities modeloBD = new UniversidadEntities();

        public ActionResult Index()
        {
            CargarCatalogos();
            return View(new ReportesViewModel());
        }

        [HttpGet]
        public ActionResult Consultar(ReportesViewModel filtro)
        {
            filtro.Resultados = modeloBD.Database.SqlQuery<ReporteAcademicoFila>(
                "EXEC dbo.saReporteAcademico @p0, @p1, @p2, @p3",
                filtro.IdCurso, filtro.IdEstudiante, filtro.IdSede, filtro.IdCuatrimestre).ToList();
            CargarCatalogos();
            return View("Index", filtro);
        }

        private void CargarCatalogos()
        {
            ViewBag.Cursos = new SelectList(modeloBD.RetornaCurso("").ToList(), "idCurso", "nombreCurso");
            ViewBag.Estudiantes = new SelectList(modeloBD.RetornaEstudiante("").ToList(), "id_estudiante", "nombre");
            ViewBag.Sedes = new SelectList(modeloBD.RetornaSedes("").ToList(), "idSedeuniversitaria", "nombre");
            ViewBag.Cuatrimestres = new SelectList(modeloBD.RetornaCuatrimestre("").ToList(), "id_cuatrimestre", "nombre");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) modeloBD.Dispose();
            base.Dispose(disposing);
        }
    }
}
