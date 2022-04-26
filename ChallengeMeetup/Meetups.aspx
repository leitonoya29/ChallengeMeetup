<%@ Page Title="Meetups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Meetups.aspx.cs" Inherits="Meetups" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="mt-2" style="display: inline-flex;">
            <asp:DropDownList ID="uiEventos" runat="server" CssClass="form-control mr-3" onchange="MuestraEventos();" ClientIDMode="Static">
                <asp:ListItem Value="2" Selected="True">Todos ...</asp:ListItem>
                <asp:ListItem Value="0">Sin Registrar</asp:ListItem>
                <asp:ListItem Value="1">Registrado</asp:ListItem>
            </asp:DropDownList>
            <input type="button" id="btnNuevo" name="btnNuevo" runat="server" value="Nuevo" class="btn btn-sm btn-success float-right mt-1" clientidmode="Static" />
        </div>
        <hr />
        <div class="content">
            <div class="row">
                <asp:HiddenField ID="uiHMeet" runat="server" ClientIDMode="Static" />
                <div id="divPrueba" runat="server" style="display: contents; width: 100%;"></div>
                <div id="divError" runat="server" style="display: contents; width: 100%;"></div>
            </div>

            <div id="DivModal" runat="server" clientidmode='Static'></div>
            <!-- Modal Radar -->
            <div id="ModalLoad" runat="server" class="modal" tabindex="-1" role="dialog" aria-labelledby="ModalLoad" aria-hidden="true" style="display:block;background-color: #0000008f;" clientidmode='Static'>
                <div class="modal-dialog" role="document">
                    <div class="modal-content ">
                        <div class="modal-body text-center">
                            <div class="spinner-border text-danger" style=" width: 200px; height: 200px;" role="status">
                                <span class="sr-only">Loading...</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="Meetups.js"></script>
</asp:Content>
