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

public partial class DatosPlanta : System.Web.UI.Page
{
    Plantas objplantas = new Plantas();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.carga_tipos_planta();
            if (Convert.ToInt32(Request.QueryString["cod"]) > 0)
            {
                this.carga_datos(Convert.ToInt32(Request.QueryString["cod"]));
            }
        }
    }

    private void carga_datos(int cod_planta)
    {
        objplantas.carga_datos_planta(cod_planta);
        if (objplantas.nombre != "Error")
        {
            txt_nombre.Text = objplantas.nombre;
            txt_cantidad.Text = objplantas.cantidad.ToString();
            ddl_tipo.SelectedValue = objplantas.tipo.ToString();
            txt_codigo.Text = cod_planta.ToString();
        }
        else
        {
            //insertar en la tabla de errores
            int numero_error = objplantas.num_error;
            string mensaje_error = objplantas.mensaje;

            HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
            return;
        }
    }

    private void carga_tipos_planta()
    {
        DataSet ds = new DataSet();
        ds = objplantas.carga_tiposplanta();
        ddl_tipo.DataSource = ds.Tables[0];
        ddl_tipo.DataTextField = ds.Tables[0].Columns["nombre_tipo"].ColumnName.ToString();
        ddl_tipo.DataValueField = ds.Tables[0].Columns["cod_tipo_planta"].ColumnName.ToString();
        ddl_tipo.DataBind();
    }
    protected void b_guardar_Click(object sender, EventArgs e)
    {
        objplantas.codigo = Convert.ToInt32(txt_codigo.Text);
        objplantas.nombre = txt_nombre.Text;
        objplantas.tipo = Convert.ToInt32(ddl_tipo.SelectedItem.Value);
        objplantas.cantidad = Convert.ToInt32(txt_cantidad.Text);
        string accion = String.Empty;

        if (Convert.ToInt32(Request.QueryString["cod"]) > 0)
        {
            accion = "Modificar";
        }
        else
        {
            accion = "Insertar";            
        }
        if (objplantas.agregar_planta(accion))
        {
            Response.Redirect("ListaPlantas.aspx");
        }    
    }
}
