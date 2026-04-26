using EatMall.Logica;
using EatMall.Modelo;
using System;
using System.Web.UI.WebControls;

namespace EatMall.Vista.Pedido
{
    public partial class Carritos : System.Web.UI.Page
    {
        CarritoL carritoL = new CarritoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarCarrito();
        }

        private void CargarCarrito()
        {
            var items = carritoL.ObtenerCarrito();

            if (items.Count == 0)
            {
                pnlVacio.Visible = true;
                rptCarrito.Visible = false;
                btnConfirmar.Visible = false;
                lblTotal.Text = "0.00";
                lblSubtotal.Text = "0.00";
            }
            else
            {
                pnlVacio.Visible = false;
                rptCarrito.DataSource = items;
                rptCarrito.DataBind();
                lblTotal.Text = string.Format("{0:N2}", carritoL.ObtenerTotal());
                lblSubtotal.Text = string.Format("{0:N2}", carritoL.ObtenerTotal());
            }
        }

        protected void rptCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                carritoL.EliminarProducto(Convert.ToInt32(e.CommandArgument));
                CargarCarrito();
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Session["IdCliente"] == null)
            {
                
                string urlRetorno = Request.Url.PathAndQuery;
                Response.Redirect("~/Vista/Auth/Login.aspx?ReturnUrl=~/Vista/Pago/MetodoPago.aspx");
                return;
            }
            Session["Total"] = carritoL.ObtenerTotal();
            Response.Redirect("~/Vista/Pago/MetodosPago.aspx");
        }
    }
}