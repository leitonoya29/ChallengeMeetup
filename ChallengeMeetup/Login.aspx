<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Async="true" %>

<!DOCTYPE html>

<html lang="es">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
     <meta name="apple-mobile-web-app-status-bar" content="#fe0000" />
    <meta name="theme-color" content="##ffffff" />

    <link rel="manifest" href="manifest.json" />
    <link rel="apple-touch-icon" href="/Images/iconSantander_144x144.png" />
    <title>Login</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-ln-bg">
                <div class="wrap-login100" style="background:  #fe0000;">
                    <div class="text-center pb-2">
                    <img src="Images/SantanderEnc.png" class="img-enc pb-5" />
                         <span class="login100-form-logo">
                        <img src="Images/iconSantander.jpg" class="loginImage" />
                    </span>
                    <span class="login100-form-title">¡Bienvenido!
                    </span>
                    </div>                   
                    <div id="divUser" class="input-ln validate-input" data-validate="Ingrese el nombre de usuario">
                        <input class="input100" type="text" id="uiUserName" runat="server" name="username" placeholder="Usuario" autocomplete="new-password" />
                        <span class="focus-input100 user"></span>
                    </div>
                    <div id="divPassword" class="input-ln validate-input" data-validate="Ingrese la contraseña">
                        <input class="input100" type="password" id="uiUserPassword" runat="server" name="pass" placeholder="Contraseña" autocomplete="new-password" />
                        <span class="focus-input100 password"></span>
                    </div>
                    <div class="div-login-btn">
                        <asp:LinkButton ID="btnLogin" runat="server" CssClass="login-btn" OnClick="btnLogin_Click">Iniciar Sesion</asp:LinkButton>
                    </div>

                </div>
                <!-- Modal -->
                <div class="modal" id="ModalError" runat="server" tabindex="-1" role="dialog" aria-labelledby="ModalError" aria-hidden="true" style="background-color: #0000008f;">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-header alert alert-danger">
                                <span class="fa fa-lg fa-exclamation-circle" style="color: #ff0017; padding-right: 10px; padding-top: 7px;"></span>
                                <h5 class="modal-title" id="exampleModalCenterTitle">Error</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div id="divmensaje" runat="server" class="modal-body">
                                Error de credenciales, el usuario o contraseña es invalido.
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-outline-primary" onclick="ocultarPopUp();">Reintentar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <script src="Scripts/jquery-3.4.1.min.js"></script>
            <script src="Scripts/umd/popper.min.js"></script>
            <script src="Scripts/bootstrap.min.js"></script>
            <script src="Login.js"></script>
             <script>
                if ('serviceWorker' in navigator) {
                    navigator.serviceWorker
                        .register('./sw_pwa.js')
                        .then(function () { console.log("Service Worker Registered"); });
                }
             </script>
        </div>
    </form>
</body>
</html>
