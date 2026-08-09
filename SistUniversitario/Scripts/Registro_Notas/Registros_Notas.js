///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmRegistroNota").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            id_estudiante: {
                required: true
            },
            id_curso: {
                required: true
            },
            id_sede: {
                required: true

            },
            notafinal: {
                required: true,
                range: [0, 10],
                number: true

            },

            id_estado: {
                required: true
            },
        }
    });
}
