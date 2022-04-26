$(document).ready(function () {

    $("#uiUserPassword").on('keyup', function (e) {
        if (e.keyCode == 13) {
            alert("ok");
            $("#btnLogin").trigger('click');
        }
    });

    $("#btnLogin").click(function () {
        var ret = true;
        var sms = "";

        if ($("#uiUserName").val() == "") {
            ret = false;
            sms += "Ingrese el usuario. \n";
        }
        if ($("#uiUserPassword").val() == "") {
            ret = false;
            sms += "Ingrese la contraseña. \n";
        }

        if (!ret) {
            $("#divmensaje").html(sms);
            $("#ModalError").show();
        }

        return ret;
    });
});
function ocultarPopUp() {
    $("#ModalError").hide();
}