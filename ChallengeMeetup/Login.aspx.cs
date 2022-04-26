using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Web;
using Comu;
using ModelsClass.Model;

public partial class Login : System.Web.UI.Page
{
    private bool _userOk;
    private async Task GetUsuario()
    {
       
        Criptografia _cripto = new Criptografia();
       
        string usuario = uiUserName.Value;
        string password = uiUserPassword.Value;
        string pathServicio = Path.Combine(ConfigurationManager.AppSettings.Get("APIs"), "api/Login?usuario=" + usuario + "&password=" + password);

        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(pathServicio),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Dictionary<string, object> u = JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
                string t = u["token"].ToString();
                Usuario usr = JsonConvert.DeserializeObject<Usuario>(_cripto.Decrypt(t));

                if (usr.AuthUser)
                {
                    var lnCookie = new HttpCookie("LnT");
                    lnCookie.Value = t;                 
                    lnCookie.Domain = "localhost";
                    HttpContext.Current.Response.Cookies.Add(lnCookie);
                    Response.Redirect("Meetups.aspx");
                    _userOk = true;
                }
                else
                {
                    _userOk = false;
                    ModalError.Style["display"] = "block";
                    divmensaje.InnerHtml = "Error de credenciales, el usuario o contraseña es invalido.";
                }

            }
        }
        catch (Exception ex)
        {
            _userOk = false;
            ModalError.Style["display"] = "block";
            divmensaje.InnerHtml = "Error de credenciales, el usuario o contraseña es invalido.";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           if (HttpContext.Current.Response.Cookies["LnT"] != null && HttpContext.Current.Response.Cookies["LnT"].Expires > DateTime.Now)
            {
                Response.Redirect("Meetups.aspx");

            }
        }
    }

    protected async void btnLogin_Click(object sender, EventArgs e) 
    {

       await GetUsuario();
       
    }
}