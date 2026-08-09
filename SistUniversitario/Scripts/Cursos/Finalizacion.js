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
            idestudiante: {
                required: true
            },
            id_curso: {
                required: true
            },

            notafinal: {
                required: true,
                range: [0, 10]
            },

            id_estado: {
                required: true

            }

        }
    });
}


function Select() {
    $(document).ready(function () {
        $("#boton02").click(function () {
            //saco el valor accediendo a un input de tipo text y name = nombre2 y lo asigno a uno con name = nombre3 
            $("#nombre3").val($("#nombre2").val());
        });
    });
}



if (notafinal>=10) {

}
else {
    if (notafinal<10) {

    }
}