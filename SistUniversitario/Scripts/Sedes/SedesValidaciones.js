///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmSede").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            nombre: {
                required: true
            },
            codigo: {
                number: true,
                required: true
            },
            id_funcionario: {
                required: true
            },
            id_provincia: {
                required: true
            },

            id_canton: {
                required: true
            },

            id_distrito: {
                required: true
            },
            DireccionFisica: {
                required: true,
                maxlength: 100,
                minlenght:50
            },

        }
    });
}
