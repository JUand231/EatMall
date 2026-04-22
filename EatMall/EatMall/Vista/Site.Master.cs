using EatMall.Logica;
using System;
using System.Web.UI.WebControls;

namespace EatMall.Vista
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private CarritoL carritoL = new CarritoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            ActualizarBadgeCarrito();
            if (Session["IdCliente"] != null)
            {
                pnlLogin.Visible = false;
                pnlPerfil.Visible = true;
                lblNombreUsuario.Text = Session["NombreCliente"].ToString();
            }
            else
            {
                pnlLogin.Visible = true;
                pnlPerfil.Visible = false;
            }
        }

        private void ActualizarBadgeCarrito()
        {
            lblCantidadCarrito.Text = carritoL.ObtenerCantidadTotal().ToString();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Index.aspx");
        }
    }
}