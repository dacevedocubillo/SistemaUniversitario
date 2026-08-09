(function ($) {
    'use strict';
    $(function () {
        $('main table.table').each(function (index) {
            var table = $(this);
            if (!table.parent().hasClass('table-responsive') && !table.parent().hasClass('result-card')) {
                table.wrap('<div class="table-responsive"></div>');
            }
            if (table.data('sin-busqueda') || table.prev('.table-search').length) return;

            var id = 'busquedaTabla' + index;
            var search = $('<div class="table-search"><label for="' + id + '">Buscar en la lista</label><input id="' + id + '" type="search" class="form-control" placeholder="Nombre, código o descripción" /></div>');
            table.closest('.table-responsive, .result-card').before(search);

            search.find('input').on('input', function () {
                var term = $.trim($(this).val()).toLocaleLowerCase('es');
                table.find('tr').not(':first').each(function () {
                    $(this).toggle($(this).text().toLocaleLowerCase('es').indexOf(term) !== -1);
                });
            });
        });
    });
}(jQuery));
