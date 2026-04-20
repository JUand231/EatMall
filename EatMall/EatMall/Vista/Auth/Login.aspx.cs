using EatMall.Logica;
using EatMall.Modelo;
using System;

namespace EatMall.Vista.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Index.aspx", false);
            LoginL loginL = new LoginL();
            UsuarioLogin datos = new UsuarioLogin
            {
                Email = txtEmail.Text,
                Contraseña = txtPassword.Text
            };

            Cliente cliente = loginL.MtLoginC(datos);

            if (cliente != null)
            {
                Session["IdCliente"] = cliente.Id;
                Session["NombreCliente"] = cliente.Nombre;
                Response.Redirect("~/Vista/Tienda.aspx");
            }
            else
            {
                // Mostrar mensaje de error
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Correo o contraseña incorrectos');", true);
            }
        }
    }
}