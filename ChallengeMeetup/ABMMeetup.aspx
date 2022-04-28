<%@ Page Title="Meetup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ABMMeetup.aspx.cs" Inherits="ABMMeetup" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-row mt-2">
        <div class="form-group col-md-6 col-lg-4">
            <label for="uiTitulo">Titulo</label>
            <input type="text" id="uiTitulo" runat="server" class="form-control" clientidmode="Static" />
        </div>
        <div class="form-group col-md-6 col-lg-4">
            <label for="uiFecha">Fecha</label>
            <div class="input-group mb-3 ">
                <div class="input-group-prepend">
                    <span class="input-group-text fa fa-calendar" style="padding-top: 10px;"></span>
                </div>
                <input type="text" id="uiFecha" runat="server" class="form-control datepicker mr-2" title="Fecha de evento" style="max-width: 120px;" placeholder="dd/mm/yyyy" data-inputmask-alias="datetime" data-inputmask-inputformat="dd/mm/yyyy" clientidmode="Static" />

                <div class="input-group-prepend">
                    <span class="input-group-text fa fa-clock-o" style="padding-top: 10px;"></span>
                </div>
                <input type="text" id="uiHora" runat="server" class="form-control time" style="max-width: 80px;" placeholder="HH:MM" data-inputmask-alias="datetime" data-inputmask-inputformat="HH:MM" clientidmode="Static" />
            </div>
        </div>
        <div class="form-group col-md-6 col-lg-4">
            <label for="uiDireccion">Direccion</label>
            <input type="text" id="uiDireccion" runat="server" class="form-control" clientidmode="Static" />
        </div>
        <div class="form-group col-md-6 col-lg-4">
            <label for="uiLatitud">Latitud</label>
            <input type="text" id="uiLatitud" runat="server" class="form-control" clientidmode="Static" />
        </div>
        <div class="form-group col-md-6 col-lg-4">
            <label for="uiLongitud">Logintud</label>
            <input type="text" id="uiLongitud" runat="server" class="form-control" clientidmode="Static" />
        </div>
        <div class="form-group col-md-6 col-lg-4">
            <label for="uiDesc">Descripcion</label>
            <textarea id="uiDesc" runat="server" class="form-control" rows="3" clientidmode="Static" />
        </div>
        <div class="form-group col-12">
            <input type="button" id="btnAceptar" class="btn btn-primary float-right" value="Aceptar" clientidmode="Static" />
        </div>
        <div id="DivModal" runat="server" clientidmode='Static'></div>
        <script src="ABMMeetup.js"></script>
    </div>
</asp:Content>
