$(document).ready(function () {

    $("#uiEventos").change(MuestraEventos);
    $("#btnNuevo").click(function () {
        window.open("ABMMeetup.aspx", "_self");
    });


    //$(".btnCheckIn").click(function () {
    //    $("#uiHMeet").val("0");
    //    alert($("#uiHMeet").val());
    //    __doPostBack("CheckIn", 0);
    //});
    //$(".btnRegistrar").click(function () {
    //    $("#uiHMeet").val(1);
    //    alert($("#uiHMeet").val());
    //    __doPostBack("Registrar", 1);

    //});
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

    switch ($("#uiEventos").val()) {
        case "0":
            $(".Registrado").hide();
            $(".SinRegistrar").show();
            break;
        case "1":
            $(".Registrado").show();
            $(".SinRegistrar").hide();
            break;
        default:
            $(".Registrado").show();
            $(".SinRegistrar").show();
    }
}

function ocultarPopUp() {
    $("#ModalAlert").hide();
}