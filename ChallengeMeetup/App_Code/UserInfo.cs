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
                if (_instance == null | (_instance != null && _instance.user.PerID == 0))
                    _instance = new UserInfo();
                return _instance;
            }
        }
    }

    public UserInfo()
    {
        Criptografia _cripto = new Criptografia();
        user = null;
        HttpCookie myCookie = HttpContext.Current.Request.Cookies["LnT"];

        if (myCookie != null && myCookie.Value != null && myCookie.Value != "")
        {
            try
            {

                user = JsonConvert.DeserializeObject<Usuario>(_cripto.Decrypt(myCookie.Value));
            }
            catch (Exception ex)
            {
                user = null;
            }
        }

    }
}