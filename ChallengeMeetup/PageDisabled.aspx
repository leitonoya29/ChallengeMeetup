<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageDisabled.aspx.cs" Inherits="PageDisabled" %>

<!DOCTYPE html>

<html lang="es">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Pagina deshabilitada</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/PageDisabled.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="outer">
                <div class="middle">
                    <div class="inner text-center">
                        <i id="iconPage" class='fa fa-exclamation-triangle'></i><span id="textPage"><p>No puede acceder a la pagina por politicas de seguridad.</p><p> Por favor contacte al administrador. </p></span>
                    </div>
                </div>
            </div>            
            <script src="Scripts/jquery-3.4.1.min.js"></script>
            <script src="Scripts/umd/popper.min.js"></script>
            <script src="Scripts/bootstrap.min.js"></script>
        </div>
    </form>
</body>
</html>
