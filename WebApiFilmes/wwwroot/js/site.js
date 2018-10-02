const uri = 'api/filme';
let lista = null;


$(document).ready(function () {
    getData();
    $('#anoLancamento').mask('00/00/0000');
});


function getData() {
    $.ajax({
        type: 'GET',
        url: uri,
        success: function (data) {
            $('#lista').empty();
            $.each(data, function (key, item) {

                let dataJson = item.anoLancamento;
                let ano = dataJson.substring(0, 4);
                let mes = dataJson.substring(5, 7);
                let dia = dataJson.substring(8, 10);
               
                $('<tr>' +
                    '<td>' + item.nome + '</td>' +
                    '<td>' + item.descricao + '</td>' +                    
                    '<td>' + dia + "/" + mes + "/" + ano + '</td>' +
                    '<td>' + item.avaliarFilme + '</td>' +
                    '<td><button  class="btn btn-secondary" onclick="editItem(' + item.id + ')">Editar</button></td>' +
                    '<td><button class="btn btn-danger" onclick="deleteItem(' + item.id + ')">Deletar</button></td>' +
                    '</tr>').appendTo($('#lista'));
            });

            lista = data;
        }
    });
}

function addItem() {
    const item = {
        'nome': $('#nome').val(),
        'descricao': $('#descricao').val(),
        'anoLancamento': $('#anoLancamento').val(),
        'avaliarFilme': $('#avaliarFilme').val()
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            getData();
            $('#nome').val('');
            $('#descricao').val('');
            $('#anoLancamento').val('');
            $('#avaliarFilme').val('');
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: function (result) {
            getData();
        }
    });
}


function editItem(id) {
    $.each(lista, function (key, item) {
        if (item.id === id) {
            $('#edit-nome').val(item.nome);
            $('#edit-descricao').val(item.descricao);
            $('#edit-id').val(item.id);
            $('#edit-anoLancamento').val(item.anoLancamento);
            $('#edit-avaliarFilme').val(item.avaliarFilme);
        }
    });
    $('#Editar').css({ 'display': 'block' });
}

$('.my-form').on('submit', function () {
    const item = {
        'nome': $('#edit-nome').val(),
        'descricao': $('#edit-descricao').val(),
        'anoLancamento': $('#edit-anoLancamento').val(),
        'avaliarFilme': $('#edit-avaliarFilme').val(),
        'id': $('#edit-id').val()
    };

    $.ajax({
        url: uri + '/' + $('#edit-id').val(),
        type: 'PUT',
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $('#Editar').css({ 'display': 'none' });
}