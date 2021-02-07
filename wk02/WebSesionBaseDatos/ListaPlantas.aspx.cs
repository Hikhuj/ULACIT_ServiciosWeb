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
using BLL;

public partial class ListaPlantas : System.Web.UI.Page
{
    Plantas objplantas = new Plantas();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.carga_lista();
        }
    }

    private void carga_lista()
    {
        gv_lista.DataSource = objplantas.carga_lista_plantas().Tables[0];
        gv_lista.DataBind();
    }

    protected void gv_lista_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // se busca la referencia a linkbutton de eliminar
            LinkButton db = (LinkButton)e.Row.Cells[4].Controls[0];
            string nombre = e.Row.Cells[1].Text;
            db.OnClientClick = string.Format("return confirm('¿Desea eliminar la planta seleccionada: {0}?');", nombre);
        }
    }

    protected void gv_lista_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_lista.PageIndex = e.NewPageIndex;
        this.carga_lista();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("DatosPlanta.aspx?cod=0");
    }

    protected void gv_lista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Eliminar")
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            int codigo = Convert.ToInt32(gv_lista.DataKeys[fila].Value);
            if (objplantas.eliminar_planta(codigo))
            {
                this.carga_lista();
            }
        }
    }
}
