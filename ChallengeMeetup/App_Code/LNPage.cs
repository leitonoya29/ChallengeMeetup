using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de LNPage
/// </summary>
public class LNPage : System.Web.UI.Page
{
    public LNPage()
    {


        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
       
            if (UserInfo.Instance.user == null || UserInfo.Instance.user.UserID == 0)
            {
                Response.Redirect("~/Login.aspx");
            }
    }
}