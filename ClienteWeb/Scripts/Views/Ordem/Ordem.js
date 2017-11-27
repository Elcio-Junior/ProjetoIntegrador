$(document).ready(function () {

    var url = window.location.pathname;

    if (url.indexOf("Edit") > 0) {
        var id = $("#Id").val();
        ListarItens(id);
    }

});

function SalvarOrdem() {

    var descricao = $("#Descricao").val();
    var clienteId = $("#ClienteId").val();
    var equipamentoId = $("#EquipamentoId").val();

    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Pedido/Create"] input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

    var url = urlOrdem + "/Create";

    $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        headers: headersadr,
        data: {
            OrdemId: 0,
            Descricao: descricao,
            ClienteId: clienteId,
            EquipamentoId: equipamentoId,
            __RequestVerificationToken: token
        },
        success: function (data) {
            if (data.Resultado > 0) {
                ListarItens(data.Resultado);
            }
        }
    });
}

function ListarItens(ordemId) {

    var url = urlOrdemItem + "/ListarItens";
        
    $.ajax({
        url: url,
        type: "GET",
        data: { id: ordemId },
        datatype: "html",
        success: function (data) {
            var divItens = $("#divItens");
            divItens.empty();
            divItens.show();
            divItens.html(data);
        }
    });

}


function SalvarItens() {

    var quantidade = $("#Quantidade").val();
    var servicoId = $("#ServicoId").val();
    var valor = $("#Valor").val();
    var ordemId = $("#OrdemId").val();

    valor = valor.replace(",", ".");

    var url = urlOrdemItem + "/SalvarItens";

    $.ajax({
        url: url,
        data: {
            quantidade: quantidade,
            servicoId: servicoId,
            valor: valor,
            ordemId: ordemId
        },
        type: "GET",
        datatype: "html",
        success: function (data) {
            if (data.Resultado > 0) {
                ListarItens(ordemId);
            }
        }
    });
}

function ExcluirItem(id) {

    var url = urlOrdemItem + "/Excluir";

    $.ajax({
        url: url,
        data: {
            id: id
        },
        type: "POST",
        datatype: "json",
        success: function (data) {
            if (data.Resultado) {
                //ListarItens(ordemId);

                var linha = "#tr" + id;
                $(linha).fadeOut(500);
            }
        }
    });

}