$(function () {
    ///llamamos a la función que se encargará de crear los eventos
    //que nos permitirán controlar cuando se haga una selección en las respectivas listas
    estableceEventosChange();
    ///Carga inicialmente la lista der provincias, ya que es 
    //la lista con la que iniciaremos.
    cargaDropdownListProvincias();
});

//función que registrará los eventos necesarios para "monitorear"
//cuando se ejecute el método change de las respectivas listas
function estableceEventosChange() {
    //evento change lista de provincia
    $("#id_provincia").change(function () {
        // obtenemos id de provincia seleccionada

        var provincia = $("#id_provincia").val();

        ///llamamos a la funcion que nos permitira cargar todos los cantones asociados
        // a la provincia seleccionada

        cargaDropdownListCantones(provincia);
    });


    //evento change lista de canton
    $("#id_canton").change(function () {
        // obtenemos id de provincia seleccionada

        var canton = $("#id_canton").val();

        ///llamamos a la funcion que nos permitira cargar todos los cantones asociados
        // a la provincia seleccionada

        cargaDropdownListDistritos(canton);
    });



}


///carga los registros de las provincias
function cargaDropdownListProvincias() {
    ///dirección a donde se enviarán los datos
    var url = '/Sedes/RetornaProvincias';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoProvincias(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

/*
 * toma el resultado del método RetornaProvincias
 * y lo procesa, recorriendo cada posición
 */
function procesarResultadoProvincias(data) {
    //mediante un selector nos posicionamos sobre la lista de provincia

    var ddlProvincias = $("#id_provincia");

    //limpiamos todas las opciones de la lista de provincias

    ddlProvincias.empty();

    //creamos la primera opcion de la lista, con un valor vacio y el texto de "Seleccione un valor"
    var nuevaopcion = "<option value=''>Seleccione una provincia</option>";

    //agregamos la opcion al dropdownlist
    ddlProvincias.append(nuevaopcion);


    //empezamos a recorrer cada uno de los registros obtenidos
    $(data).each(function () {

        //obtenemos el objeto de tipo provincia haciendo uso de la clausla "this"
        //ahora podemos acceder a todas las propiedades
        //por ejemplo ProvinciaActual.nombre nos retorna el nombre de la provincia

        var provinciaActual = this

        //creamos opcion de la lista, con el valor id provincia y el nombre
        nuevaopcion = "<option value='" + provinciaActual.id_Provincia + "'>" + provinciaActual.nombre + "</option>";

        //agregamos opcion al dropdownlist

        ddlProvincias.append(nuevaopcion)

    });
}

///carga los registros de los cantones
function cargaDropdownListCantones(pIdProvincia) {

    ///dirección a donde se enviarán los datos
    var url = '/Sedes/RetornaCantones';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        id_Provincia: pIdProvincia


    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoCantones(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}


function procesarResultadoCantones(data) {

    //mediante un selector nos posicionamos sobre la lista cantones
    var ddlCantones = $("#id_canton")

    //limpiamos todas las opciones de la lista de provincias

    ddlCantones.empty();

    //creamos la primera opcion de la lista, con un valor vacio y el texto de "Seleccione un valor"
    var nuevaopcion = "<option value=''>Seleccione una canton</option>";

    //agregamos la opcion al dropdownlist
    ddlCantones.append(nuevaopcion);

    //empezamos a recorrer cada uno de los registros obtenidos

    $(data).each(function () {

        //obtenemos el objeto de tipo provincia haciendo uso de la clausla "this"
        //ahora podemos acceder a todas las propiedades
        //por ejemplo ProvinciaActual.nombre nos retorna el nombre de la provincia

        var cantonactual = this

        //creamos opcion de la lista, con el valor id provincia y el nombre
        nuevaopcion = "<option value='" + cantonactual.id_Canton + "'>" + cantonactual.nombre + "</option>";

        //agregamos opcion al dropdownlist

        ddlCantones.append(nuevaopcion)

    });
}

function cargaDropdownListDistritos(pIdCanton) {


    ///dirección a donde se enviarán los datos
    var url = '/Sedes/RetornaDistritos';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {

        id_Canton: pIdCanton

    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoDistritos(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

function procesarResultadoDistritos(data) {
    //mediante un selector nos posicionamos sobre la lista distritos
    var ddlDistritos = $("#id_distrito")

    //limpiamos todas las opciones de la lista de distrito

    ddlDistritos.empty();

    //creamos la primera opcion de la lista, con un valor vacio y el texto de "Seleccione un valor"
    var nuevaopcion = "<option value=''>Seleccione una canton</option>";

    $(data).each(function () {

        //obtenemos el objeto de tipo distrito haciendo uso de la clausla "this"
        //ahora podemos acceder a todas las propiedades
        //por ejemplo ProvinciaActual.nombre nos retorna el nombre de la provincia

        var distritoactual = this

        //creamos opcion de la lista, con el valor id provincia y el nombre
        nuevaopcion = "<option value='" + distritoactual.id_Distrito + "'>" + distritoactual.nombre + "</option>";

        //agregamos opcion al dropdownlist

        ddlDistritos.append(nuevaopcion)

    });

}




