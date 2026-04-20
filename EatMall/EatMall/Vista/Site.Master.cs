using System;
using EatMall.Logica;

namespace EatMall
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private CarritoL carritoL = new CarritoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            ActualizarBadgeCarrito();
        }

        private void ActualizarBadgeCarrito()
        {
            lblCantidadCarrito.Text = carritoL.ObtenerCantidadTotal().ToString();
        }
    }
}