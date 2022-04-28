$(document).ready(function () {

    $('#btnAceptar').dblclick(function (e) {
        e.preventDefault();
    });

    $(".form-control").blur(function () {
        if ($(this).val() != "") {
            $(this).removeClass('is-invalid');
        }
    });

    $("#btnAceptar").click(function () {
        var ret = true;

        if ($("#uiTitulo").val() == "") {
            $("#uiTitulo").addClass('is-invalid');
            ret = false;
        }
        else {
            $("#uiTitulo").removeClass('is-invalid');
        }

        if ($("#uiFecha").val() == "") {
            $("#uiFecha").addClass('is-invalid');
            ret = false;
        }
        else {
            $("#uiFecha").removeClass('is-invalid');
        }

        if ($("#uiHora").val() == "") {
            $("#uiHora").addClass('is-invalid');
            ret = false;
        }
        else {
            $("#uiHora").removeClass('is-invalid');
        }

        if ($("#uiDireccion").val() == "") {
            $("#uiDireccion").addClass('is-invalid');
            ret = false;
        }

        else {
            $("#uiDireccion").removeClass('is-invalid');
        }

        if (isNaN(parseFloat($("#uiLatitud").val().replace(",", ".")))) {
            $("#uiLatitud").addClass('is-invalid');
            ret = false;
        }
        else {
            $("#uiLatitud").removeClass('is-invalid');
        }

        if (isNaN(parseFloat($("#uiLongitud").val().replace(",", ".")))) {
            $("#uiLongitud").addClass('is-invalid');
        }

        else {
            $("#uiLongitud").removeClass('is-invalid');
        }


        if (ret) {

            __doPostBack("Grabar", "");
        }
    });

    $('.datepicker').datepicker({
        language: 'es',
        format: 'dd/mm/yyyy',
        autoclose: true,
        todayHighlight: true,
        clearBtn: true
    });

    $(".datepicker").inputmask('99/99/9999');
    $('.time').inputmask('99:99');
});

function ocultarPopUp() {
    $("#ModalAlert").hide();
}
