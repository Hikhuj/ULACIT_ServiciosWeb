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

public partial class Rol : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.carga_usuarios();
            this.carga_roles();
        }
        string nomb_usu = Membership.GetUser().UserName;
        if (!Roles.IsUserInRole(nomb_usu, "Administracion"))
        {
            if (!Roles.IsUserInRole(nomb_usu, "Mantenimiento"))
            {
                int numero_error = 1;
                string mensaje_error = "Usuario incorrecto. Por favor utilice una cuenta válida";

                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
            }
        }
    }

    private void carga_usuarios()
    {
        lst_usuarios.DataSource = Membership.GetAllUsers();
        lst_usuarios.DataBind();
        Roles.IsUserInRole(Membership.GetUser().UserName, "Consulta");
    }

    private void carga_roles()
    {
        string[] lista_roles = Roles.GetAllRoles();
        chkl_roles.DataSource = lista_roles;
        chkl_roles.DataBind();

    }
    private void carga_roles_usuarios(string usuario)
    {
        this.carga_roles();

        string rol1 = String.Empty;
        string rol2 = String.Empty;
        string[] lista_roles = Roles.GetRolesForUser(usuario);

        for (int i = 0; i <= lista_roles.Length -1; i++)
        {
            rol1 = lista_roles[i].ToString();
            for (int j = 0; j <= chkl_roles.Items.Count - 1; j++)
            {
                rol2 = chkl_roles.Items[j].Text;
                if (rol1.Equals(rol2))
                {
                    chkl_roles.Items[j].Selected = true;
                }                
            }   
        }
    }

    private void guardar_roles(string usuario)
    {
        string[] lista_roles = Roles.GetRolesForUser(usuario);
        string nombre_rol = String.Empty;

        if (lista_roles.Length > 0) //COntador de los roles
        {
            Roles.RemoveUserFromRoles(usuario, lista_roles);
            for (int i = 0; i <= chkl_roles.Items.Count - 1; i++)
            {
                if (chkl_roles.Items[i].Selected)
                {
                    nombre_rol = chkl_roles.Items[i].Text;
                    Roles.AddUserToRole(usuario, nombre_rol);
                }
            }
        }
        else
        {
            int numero_error = 2;
            string mensaje_error = "El usuario actual no tiene ningún rol, porfavor diríjase al portal de Seguridad para agregarle uno";

            HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
        }
    }

    protected void lst_usuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1400);
        this.carga_roles_usuarios(lst_usuarios.SelectedItem.Text);
    }

    protected void b_actualizar_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1400);
        this.guardar_roles(lst_usuarios.SelectedItem.Text);
        UpdatePanel2.Update();
    }
}
