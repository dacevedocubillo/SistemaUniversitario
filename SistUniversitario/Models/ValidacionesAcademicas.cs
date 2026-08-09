using System;
using System.ComponentModel.DataAnnotations;

namespace SistUniversitario.Models
{
    [MetadataType(typeof(EstudianteMetadata))]
    public partial class saRetornaEstudiante_ID_Result { }
    public class EstudianteMetadata
    {
        [Required, StringLength(100, MinimumLength = 3)] public string nombre { get; set; }
        [Range(1000000, 999999999, ErrorMessage = "Ingrese una cédula válida.")] public int cedula { get; set; }
        [Range(1, int.MaxValue)] public int id_provincia { get; set; }
        [Range(1, int.MaxValue)] public int id_canton { get; set; }
        [Range(1, int.MaxValue)] public int id_distrito { get; set; }
        [Range(1, int.MaxValue)] public int carne { get; set; }
    }

    [MetadataType(typeof(FuncionarioMetadata))]
    public partial class saRetornaFuncionario_ID_Result { }
    public class FuncionarioMetadata
    {
        [Required, StringLength(100, MinimumLength = 3)] public string nombre { get; set; }
        [Range(1000000, 999999999)] public int cedula { get; set; }
        [Range(1, int.MaxValue)] public int id_provincia { get; set; }
        [Range(1, int.MaxValue)] public int id_canton { get; set; }
        [Range(1, int.MaxValue)] public int id_distrito { get; set; }
        [Required, DataType(DataType.Date)] public DateTime fecha_contratacion { get; set; }
    }

    [MetadataType(typeof(CursoMetadata))]
    public partial class saRetornaCurso_ID_Result { }
    public class CursoMetadata
    {
        [Range(1, 999999)] public int Codigo { get; set; }
        [Required, StringLength(100, MinimumLength = 3)] public string nombreCurso { get; set; }
    }

    [MetadataType(typeof(SedeMetadata))]
    public partial class saRetornaSede_ID_Result { }
    public class SedeMetadata
    {
        [Range(1, 999999)] public int codigo { get; set; }
        [Range(1, int.MaxValue)] public int id_funcionario { get; set; }
        [Range(1, int.MaxValue)] public int id_provincia { get; set; }
        [Range(1, int.MaxValue)] public int id_canton { get; set; }
        [Range(1, int.MaxValue)] public int id_distrito { get; set; }
        [Required, StringLength(250, MinimumLength = 10)] public string DireccionFisica { get; set; }
    }

    [MetadataType(typeof(CarreraMetadata))]
    public partial class saRetornaCarrera_ID_Result { }
    public class CarreraMetadata
    {
        [Range(1, int.MaxValue)] public int idDireccionCarrera { get; set; }
        [Required, StringLength(100, MinimumLength = 3)] public string Nombre { get; set; }
        [Range(1, 999999)] public int Codigo { get; set; }
    }

    [MetadataType(typeof(RegistroNotaMetadata))]
    public partial class saRegistro_ID_Result { }
    public class RegistroNotaMetadata
    {
        [Range(1, int.MaxValue)] public int idestudiante { get; set; }
        [Range(1, int.MaxValue)] public int id_curso { get; set; }
        [Range(1, int.MaxValue)] public int id_sede { get; set; }
        [Range(0, 10, ErrorMessage = "La nota debe estar entre 0 y 10.")] public int notafinal { get; set; }
    }
}
