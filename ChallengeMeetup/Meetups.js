$(document).ready(function () {

    $("#uiEventos").change(MuestraEventos);

    $("#btnNuevo").click(function () {
        window.open("ABMMeetup.aspx", "_self");
    });

});

function Registrar(id) {
    $("#ModalLoad").show();
    $("#uiHMeet").val(id);

    __doPostBack("Registrar", "");
}

function CheckIn(id) {
    $("#ModalLoad").show();
    $("#uiHMeet").val(id);

    __doPostBack("CheckIn", "");
}

function MuestraEventos() {
    $(".SinRegistrar").show();
    $(".Registrado").show();
    $(".Finalizado").show();
    $(".Proximo").show();

    switch ($("#uiEventos").val()) {
        case "0":
            $(".Registrado").hide();
            break;
        case "1":
            $(".SinRegistrar").hide();
            break;
    }

    switch ($("#uiFinalizados").val()) {
        case "0":
            $(".Finalizado").hide();
            break;
        case "1":
            $(".Proximo").hide();
            break;
    }
}

function ocultarPopUp() {
    $("#ModalAlert").hide();
}