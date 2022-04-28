using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ModalMessage
/// </summary>
public class ModalMessage
{
    public string GetModal(int tipo, string mensaje)
    {
        string ret = "";
        string cls = "";
        string icon = "";
        string color = "";
        string title = "";

        switch (tipo)
        {
            case 1:
                cls = "success";
                icon = "<span class='fa fa-lg fa-check' style='color: green; padding-right: 10px; padding-top: 7px;'></span>";
                title = "OK";
                color = "green";
                break;
            case 2:
                cls = "danger";
                icon = "<span class='fa fa-lg fa-exclamation-circle' style='color: #ff0017; padding-right: 10px; padding-top: 7px;'></span>";
                title = "ERROR";
                color = " #ff0017";
                break;
            case 3:
                cls = "info";
                icon = "<span class='fa fa-lg fa-exclamation-circle' style='color: blue; padding-right: 10px; padding-top: 7px;'></span>";
                title = "AVISO";
                color = "blue";
                break;
            case 4:
                cls = "warning";
                icon = "<span class='fa fa-lg fa-exclamation-circle' style='color: orange; padding-right: 10px; padding-top: 7px;'></span>";
                title = "ATENCION";
                color = "orange";
                break;
        }

        ret += "<div id='ModalAlert' class='modal' tabindex='-1' role='dialog' aria-labelledby='ModalAlert' aria-hidden='true' style='display:block;background-color: #0000008f;'  clientidmode='Static' >";
        ret += "<div class='modal-dialog' role='document'>";
        ret += " <div class='modal-content'>";
        ret += "   <div class='modal-header alert alert-" + cls + "'>";
        ret += icon;
        ret += "      <h5 class='modal-title' style='color:" + color + ";'>" + title + "</h5>";
        ret += "      <button type='button' class='close' data-dismiss='modal' aria-label='Close' onclick='ocultarPopUp();'>";
        ret += "          <span aria-hidden='true'>&times;</span>";
        ret += "      </button>";
        ret += "   </div>";
        ret += "   <div class='modal-body'>";
        ret += mensaje;
        ret += "    </div>";
        ret += "   <div class='modal-footer'>";
        ret += "       <button type='button' class='btn btn-primary' onclick='ocultarPopUp();'>Aceptar</button>";
        ret += "   </div>";
        ret += "    </div>";
        ret += "   </div>";
        ret += "   </div>";

        return ret;
    }


    public ModalMessage()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}