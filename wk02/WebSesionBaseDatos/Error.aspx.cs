using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_msg.Text = "Se ha producido un error en el sistema. Por favor contacte al administrador del sitio. Número de Error: " + Request.QueryString["error"].ToString() + " " + Request.QueryString["men"].ToString();
    }
}
