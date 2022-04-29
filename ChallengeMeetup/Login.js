$(document).ready(function () {

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