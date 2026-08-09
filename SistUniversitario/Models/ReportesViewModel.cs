using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistUniversitario.Models
{
    public class ReportesViewModel
    {
        [Display(Name = "Curso")]
        public int? IdCurso { get; set; }
        [Display(Name = "Estudiante")]
        public int? IdEstudiante { get; set; }
        [Display(Name = "Sede")]
        public int? IdSede { get; set; }
        [Display(Name = "Cuatrimestre")]
        public int? IdCuatrimestre { get; set; }
        public IList<ReporteAcademicoFila> Resultados { get; set; } = new List<ReporteAcademicoFila>();
    }

    public class ReporteAcademicoFila
    {
        public int IdMatricula { get; set; }
        public string Estudiante { get; set; }
        public string Carne { get; set; }
        public string Curso { get; set; }
        public string Sede { get; set; }
        public string Cuatrimestre { get; set; }
        public decimal? NotaFinal { get; set; }
        public string Estado { get; set; }
    }
}
