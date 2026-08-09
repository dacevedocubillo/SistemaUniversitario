///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmCursoNuevo").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            codigo: {
                number: true,
                required: true
            },
            nombreCurso: {
                required: true,
                maxlength: 25,
                minlenght: 15
           },
        }
    });
}
