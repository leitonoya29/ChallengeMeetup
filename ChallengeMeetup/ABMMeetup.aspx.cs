using ModelsClass.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Web;

public partial class ABMMeetup : LNPage
{
    private ModalMessage _modal = new ModalMessage();

    private bool ValidaForm()
    {
        var ret = true;
        var mensaje = "";
        ret = (uiTitulo.Value == "" ? false : ret);
        ret = (uiFecha.Value == "" ? false : ret);
        ret = (uiHora.Value == "" ? false : ret);
        ret = (uiDireccion.Value == "" ? false : ret);
        ret = (uiLatitud.Value == "" ? false : ret);
        ret = (uiLongitud.Value == "" ? false : ret);

        try
        {
            var lat = float.Parse(uiLongitud.Value.Replace(".", ","));
        }
        catch (Exception ex)
        {
            ret = false;
        }
        try
        {
            var lon = float.Parse(uiLongitud.Value.Replace(".", ","));
        }
        catch (Exception ex)
        {
            ret = false;
        }

        try
        {
            var _fecha = DateTime.Parse(DateTime.Parse(uiFecha.Value).ToString("yyyy-MM-dd") + "T" + uiHora.Value + ":00");

        }
        catch (Exception ex)
        {
            ret = false;
        }

        if (!ret)
        {
            DivModal.InnerHtml = _modal.GetModal(2, "Revise los campos del formulario.");
        }

        return ret;
    }


    private async void SaveMeetAsync()
    {
        if (ValidaForm())
        {
            var url = Path.Combine(ConfigurationManager.AppSettings.Get("APIs"), "api/Meetups");
            Meetup _meet = new Meetup();

            _meet.MeetID = 0;
            _meet.MeetNombre = uiTitulo.Value;
            _meet.MeetFecha = DateTime.Parse(DateTime.Parse(uiFecha.Value).ToString("yyyy-MM-dd") + "T" + uiHora.Value + ":00");
            _meet.MeetDireccion = uiDireccion.Value;
            _meet.MeetLat = float.Parse(uiLatitud.Value.Replace(".", ","));
            _meet.MeetLon = float.Parse(uiLongitud.Value.Replace(".", ","));
            _meet.MeetDesc = uiDesc.Value;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-LNApi-Token", HttpContext.Current.Request.Cookies["LnT"].Value);


                var res = await client.PostAsJsonAsync<Meetup>(url, _meet);
                if (res.IsSuccessStatusCode)
                {

                    DivModal.InnerHtml = _modal.GetModal(1, "Registro grabado satisfactoriamente");
                }
                else
                {
                    DivModal.InnerHtml = _modal.GetModal(2, "Se produjo un error al actualizar el registro: " + res.RequestMessage);
                }
            }

        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack && Request.Params.Get("__EVENTTARGET") == "Grabar" && ConfigurationManager.AppSettings.Get("APIs") != null)
        {
            SaveMeetAsync();
        }
        else
        {
            DivModal.InnerHtml = _modal.GetModal(2, "Falta configurar los servicios web.");
        }

    }


}