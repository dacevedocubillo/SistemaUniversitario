///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmfuncionario").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            nombre: {
                required: true,
                maxlength: 100,
                minlenght: 50
            },
            cedula: {
                number: true,
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
            fecha_contratacion: {
                required: true
            },

        }
    });
}
