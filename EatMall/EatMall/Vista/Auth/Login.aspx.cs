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
            LoginL loginL = new LoginL();
            UsuarioLogin datos = new UsuarioLogin
            {
                Email = txtEmail.Text,
                Contraseña = txtPassword.Text
            };

            Cliente cliente = loginL.MtLoginC(datos);

            if (cliente != null)
            {
                // 1. Guardar datos en sesión
                Session["IdCliente"] = cliente.Id;
                Session["NombreCliente"] = cliente.Nombre;

                
                string returnUrl = Request.QueryString["~/Vista/Pago/MetodoPago"];

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    
                    Response.Redirect(returnUrl);
                }
                else
                {
                    // Si no hay ReturnUrl, lo mandamos a la página por defecto (ConfirmarPedido o Index)
                    Response.Redirect("~/Vista/Pedido/ConfirmarPedido.aspx");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('Correo o contraseña incorrectos');", true);
            }
        }
    }
}