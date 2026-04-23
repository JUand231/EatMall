using EatMall.Logica;
using System;
using System.Web.UI;
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
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBusqueda.Text.Trim()))
            {
                // Redirige a la página de resultados pasando el término como querystring
                Response.Redirect("/Vista/Busqueda/Resultados.aspx?q=" + Server.UrlEncode(txtBusqueda.Text.Trim()));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "warning",
                    "Swal.fire({ icon: 'warning', title: 'Advertencia', text: 'Ingrese un término de búsqueda.' });", true);
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