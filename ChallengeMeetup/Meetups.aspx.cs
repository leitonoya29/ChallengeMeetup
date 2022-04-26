using Comu;
using ModelsClass.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Meetups : LNPage
{

    private ModalMessage _modal = new ModalMessage();
    private string DibujaCard(Meetup _meet, string strClima, float temp)
    {
        int cantCervezas = 0;
        bool registrado = false;
        bool perCheckin = false;

        if (_meet.LPer.Contains(UserInfo.Instance.user.PerID))
        {
            registrado = true;

            perCheckin = (_meet.LPerConfirm.Contains(UserInfo.Instance.user.PerID) ? true : false);
        }


        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<div class='col-sm-6 col-lg-3 " + (registrado ? "Registrado" : "SinRegistrar") + "'>");
        sb.AppendLine("<div class='card bg-light mb-3' style='max-width: 29rem;'>");
        sb.AppendLine("<div class='card-header bg-ln'><h4><span class='fa fa-calendar mr-2'></span>" + _meet.MeetNombre + "</h4></div>");
        sb.AppendLine("<div class='card-body'>");
        sb.AppendLine("<div class='container'>");
        sb.AppendLine("<div class='row'>");
        sb.AppendLine("<div><p><span class='fa fa-calendar mr-2' style='width:30px;'></span>" + _meet.MeetFecha.ToString("dd/MM/yyyy") + " " + _meet.MeetFecha.ToString("HH:mm") + " HS </p></div>");
        sb.AppendLine("</div>");
        sb.AppendLine("<div class='row'>");
        sb.AppendLine("<div><p><span class='fa fa-map-marker mr-2' style='width:30px;'></span>" + _meet.MeetDireccion + "</p></div>");
        sb.AppendLine("</div>");


        if (UserInfo.Instance.user.AdminUser)
        {

            sb.AppendLine("<div class='row'>");
            sb.AppendLine("<div><p><span class='fa fa-users mr-2' style='width:30px;'></span>" + _meet.LPer.Count + "</p></div>");
            sb.AppendLine("</div>");

            sb.AppendLine("<div class='row'>");

            if (temp < 20)
            {
                cantCervezas = (int)Math.Ceiling((_meet.LPer.Count * 0.75) / 6);
            }
            else if (temp < 24)
            {
                cantCervezas = (int)Math.Ceiling((double)_meet.LPer.Count / 6);
            }
            else
            {
                cantCervezas = (int)Math.Ceiling((double)(_meet.LPer.Count * 3) / 6);
            }

            sb.AppendLine("<div><p><span class='fa fa-beer mr-2' style='width:30px;'></span> Se " + (cantCervezas > 1 ? " necesitan " : " necesita ") + cantCervezas + (cantCervezas > 1 ? " cajas" : " caja") + " de cervezas.</p></div>");
            sb.AppendLine("</div>");
        }
        sb.AppendLine(strClima);


        sb.AppendLine("<div class='row'>");
        sb.AppendLine("<div class='col-12'><p><strong>Detalle:</strong></p></div>");
        sb.AppendLine("<div class='col-12'><p> " + _meet.MeetDesc + "</p></div>");
        sb.AppendLine("</div>");

        sb.AppendLine("<div class='row'>");

        if (registrado)
        {
            sb.AppendLine("<div class='col-6'><p><span style='color:green;font-weight: bold; font-size: larger;'> <i class='fa fa-check'></i> Registrado </span></p> </div>");
            if (_meet.MeetFecha < DateTime.Now)
            {
                if (!perCheckin)
                {
                    sb.AppendLine("<div id='divCheckIn_" + _meet.MeetID + "' name='divCheckIn_" + _meet.MeetID + "' runat='server'  class='col-6'><input type='button' id='btnCheckIn_" + _meet.MeetID + "' name='btnCheckIn_" + _meet.MeetID + "' value='Check In' onclick='javascript:CheckIn(" + _meet.MeetID + ");' class='btn btn-success btnCheckIn' style='font-size: larger;' /> </div>");
                }
                else
                {
                    sb.AppendLine("<div class='col-6'><p><span style='color:green;font-weight: bold; font-size: larger;'> <i class='fa fa-check'></i> Check IN </span></p> </div>");

                }
            }
        }
        else
        {
            sb.AppendLine("<div id='divRegis_" + _meet.MeetID + "' name='divRegis_" + _meet.MeetID + "' runat='server' class='col-6'><input type='button' id='btnRegis_" + _meet.MeetID + "' name='btnRegis_" + _meet.MeetID + "' value='Resgistrarme' onclick='javascript:Registrar(" + _meet.MeetID + ");' class='btn btn-primary btnRegistrar' style='font-size: larger;' /> </div>");
        }
        sb.AppendLine("</div>");

        sb.AppendLine("</div>");
        sb.AppendLine("</div>");
        sb.AppendLine("</div>");
        sb.AppendLine("</div>");

        return sb.ToString();
    }


    private async Task RegistraPersona()
    {
        var PerID = UserInfo.Instance.user.PerID;
        var MeetID = 0;
        var url = Path.Combine(ConfigurationManager.AppSettings.Get("APIs"), "api/Register");

        try
        {
            MeetID = int.Parse(uiHMeet.Value);
        }
        catch (Exception ex)
        {

        }

        if (PerID > 0 && MeetID > 0)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-LNApi-Token", HttpContext.Current.Request.Cookies["LnT"].Value);
                var data = new Dictionary<string, int>();
                data.Add("PerID", PerID);
                data.Add("MeetID", MeetID);

                var res = await client.PostAsJsonAsync<Dictionary<string, int>>(url, data);
                if (res.IsSuccessStatusCode)
                {
                    GetMeetups();
                    DivModal.InnerHtml = _modal.GetModal(1, "Se registro satisfactoriamente");
                }
                else
                {
                    DivModal.InnerHtml = _modal.GetModal(2, "Se produjo un error al consultar los registros: " + res.RequestMessage);

                }
            }
        }
        else
        {
            DivModal.InnerHtml = _modal.GetModal(2, "Se produjo un error al leer los datos del evento:");
        }

    }

    private async Task CheckInPersona()
    {
        var PerID = UserInfo.Instance.user.PerID;
        var MeetID = 0;
        var url = Path.Combine(ConfigurationManager.AppSettings.Get("APIs"), "api/CheckIn");

        try
        {
            MeetID = int.Parse(uiHMeet.Value);
        }
        catch (Exception ex)
        {

        }

        if (PerID > 0 && MeetID > 0)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-LNApi-Token", HttpContext.Current.Request.Cookies["LnT"].Value);
                var data = new Dictionary<string, int>();
                data.Add("PerID", PerID);
                data.Add("MeetID", MeetID);      

                var res = await client.PostAsJsonAsync<Dictionary<string, int>>(url, data);
                if (res.IsSuccessStatusCode)
                {
                    GetMeetups();
                    DivModal.InnerHtml = _modal.GetModal(1, "Check IN realizado satisfactoriamente");

                }
                else
                {
                    DivModal.InnerHtml = _modal.GetModal(2, "Se produjo un error al consultar los registros: " + res.RequestMessage);
                }
            }
        }
        else
        {
            DivModal.InnerHtml = _modal.GetModal(2, "Se produjo un error al leer los datos del evento:");
        }

    }

    private async void GetMeetups()
    {

        Criptografia _cripto = new Criptografia();

        string pathServicio = Path.Combine(ConfigurationManager.AppSettings.Get("APIs"), "api/Meetups");

        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(pathServicio),
                Headers = {
                        { "X-LNApi-Token", HttpContext.Current.Request.Cookies["LnT"].Value },
                       },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                List<Meetup> _lMeet = JsonConvert.DeserializeObject<List<Meetup>>(body);
                StringBuilder sb = new StringBuilder();

                foreach (Meetup _elem in _lMeet)
                {
                    //string pathClima = (Path.Combine(ConfigurationManager.AppSettings.Get("APIs"), "api/Weather?lat=" + _elem.MeetLat + "&lon=" + _elem.MeetLon + "&fecha=" + _elem.MeetFecha.ToString("yyyy-MM-dd"))).Replace(",", ".");
                    string strClima = "";
                    float temp = 20;

                    //try
                    //{
                    //    var clientClima = new HttpClient();
                    //    var requestClima = new HttpRequestMessage
                    //    {
                    //        Method = HttpMethod.Get,
                    //        RequestUri = new Uri(pathClima),
                    //        Headers = {
                    //                           { "X-LNApi-Token", HttpContext.Current.Request.Cookies["LnT"].Value  },
                    //                   },
                    //    };
                    //    using (var responseClima = await client.SendAsync(requestClima))
                    //    {
                    //        responseClima.EnsureSuccessStatusCode();
                    //        var bodyClima = await responseClima.Content.ReadAsStringAsync();

                    //        var _lClima = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(bodyClima);
                    //        foreach (Dictionary<string, object> elem in _lClima)
                    //        {
                    //            temp = float.Parse(elem["max_temp"].ToString().Replace(".", ","));
                    //            strClima += "<div class='row'>";
                    //            strClima += "<div class='col-12'><p ><p><strong>Clima</strong></p></div>";
                    //            strClima += "<div class='col-4'><p ><img width='80' height='80' src='https://www.weatherbit.io/static/img/icons/" + elem["icon"] + ".png' /></div>";
                    //            strClima += "<div class='col-8'><p> T° max: " + elem["max_temp"] + "</p><p> T° min: " + elem["min_temp"] + "</p><p>T° prom: " + elem["temp"] + "</p>  </div>"; strClima += "</div>";
                    //            break;
                    //        }

                    //    }
                    //}
                    //catch (Exception ex)
                    //{


                    //}

                    if (strClima == "")
                    {
                        strClima += "<div class='row'>";
                        strClima += "<div class='col-12'><p ><p><strong>Clima no disponible.</strong></p></div></div>";

                    }

                    sb.AppendLine(DibujaCard(_elem, strClima, temp));
                }

                divPrueba.InnerHtml = sb.ToString();

            }
        }
        catch (Exception ex)
        {
            DivModal.InnerHtml = _modal.GetModal(2, "Se produjo un error al consultar los registros: " + ex.Message);
        }
    }

    protected async void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpCookie myCookie = HttpContext.Current.Request.Cookies["LnT"];

            divError.InnerHtml = myCookie.Values.Get("token") + "<br />";
            divError.InnerHtml += myCookie.Values.Get("expire") + "<br />";
            divError.InnerHtml += (myCookie.Expires - DateTime.Now).Minutes + "<br />";

            btnNuevo.Visible = false;
            ((HtmlGenericControl)Page.Master.FindControl("spTitle")).InnerText = "Santander Challenge : : Meetups";

            if (UserInfo.Instance.user.AdminUser)
            {
                btnNuevo.Visible = true;
            }

            GetMeetups();
            
            ModalLoad.Style["display"] = "none";
        }
        else
        {
            switch (Request.Params.Get("__EVENTTARGET"))
            {

                case "Registrar":
                    await RegistraPersona();
                    ModalLoad.Style["display"] = "none";
                    break;
                case "CheckIn":
                    await CheckInPersona();
                    ModalLoad.Style["display"] = "none";
                    break;
                default:

                    break;
            }



        }
    }
}

