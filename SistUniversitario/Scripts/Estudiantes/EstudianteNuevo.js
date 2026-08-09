///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmestudiante").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            id_matriculaes: {
                required: true
            },
            Nombre: {
                required: true,
                maxlength: 100,
                minlenght: 50
            },
            cedula: {
                required: true,
                maxlength: 9,
                number: true
              
            },
            id_provincia: {
                required: true,
            },

            id_canton: {
                required: true
            },
            id_distrito: {
                required: true
            },
            Carne:{
                required: true,
                number: true
             },


        }
    });
}
