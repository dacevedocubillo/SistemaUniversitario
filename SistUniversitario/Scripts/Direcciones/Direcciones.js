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
            codigo: {
                required: true,
                number: true
            },
            id_director: {
                required: true
            },
            id_subdirector: {
                required: true
            },

            Nombre: {
                required: true,
                maxlength: 100,
                minlenght: 50
            },
        }
    });
}
