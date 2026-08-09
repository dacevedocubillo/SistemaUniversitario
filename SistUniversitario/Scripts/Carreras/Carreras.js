///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmCarreraNueva").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            idDireccionCarrera: {
                required: true,
            },
            Nombre: {
                required: true
            },
            Codigo: {
                required: true,
                mumber: true
            },
        }
    });
}