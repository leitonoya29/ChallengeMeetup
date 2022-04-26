using Comu;
using ModelsClass.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de UserInfo
/// </summary>
public class UserInfo
{


    private static UserInfo _instance { get; set; }
    private static readonly object _locked = new object();

    public Usuario user { get; set; }
    public static UserInfo Instance
    {
        get
        {
            lock (_locked)
            {
                if (_instance==null | (_instance != null && _instance.user.PerID == 0))
                    _instance = new UserInfo();
                return _instance;
            }
        }
    }

    public UserInfo()
	{
        user = new Usuario();

        HttpCookie myCookie = HttpContext.Current.Request.Cookies["LnT"];

        if (myCookie != null && myCookie.Value != "")
        {
            try
            {
                var t = myCookie.Value;
                if (t != null)
                {
                    Criptografia _cripto = new Criptografia();
                    user = JsonConvert.DeserializeObject<Usuario>(_cripto.Decrypt(t));
                }
            }
            catch (Exception ex)
            {
                user = null;
            }
        }

    }
}