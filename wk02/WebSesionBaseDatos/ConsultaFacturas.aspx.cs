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

public partial class ConsultaFacturas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["fechainicial"] = txt_fecha_inicial.Text;
        ViewState["fechafinal"] = txt_fecha_final.Text;
        if (Page.IsPostBack)
        {
            txt_fecha_final.Text = ViewState["fechafinal"].ToString();
            txt_fecha_inicial.Text = ViewState["fechainicial"].ToString();
        }
        else
        {
            txt_fecha_final.Text = DateTime.Now.ToShortDateString();
            txt_fecha_inicial.Text = DateTime.Now.ToShortDateString();
        }
    }
    protected void b_consultar_Click(object sender, EventArgs e)
    {
        this.generar_consulta();
    }

    private void generar_consulta()
    {
        Facturas objfactura = new Facturas();
        string fechainicial = txt_fecha_inicial.Text;
        string fechafinal = txt_fecha_final.Text;
        string[] fecha1 = fechainicial.Split('/');
        string[] fecha2 = fechafinal.Split('/');

        fechainicial = fecha1[2].ToString() + "/" + fecha1[1].ToString() + "/" + fecha1[0].ToString();
        fechafinal = fecha2[2].ToString() + "/" + fecha2[1].ToString() + "/" + fecha2[0].ToString();

        System.Threading.Thread.Sleep(1400);

        gv_lista.AutoGenerateColumns = false;
        gv_lista.DataSource = objfactura.carga_facturas(fechainicial, fechafinal);
        gv_lista.DataBind();


    }
}
