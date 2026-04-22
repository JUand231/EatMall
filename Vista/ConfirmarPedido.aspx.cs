using EatMall.Logica;
using EatMall.Modelo;
using System;
using System.Collections.Generic;

namespace EatMall.Vista
{
    public partial class ConfirmarPedido : System.Web.UI.Page
    {
        private CarritoL carritoL = new CarritoL();
        private PedidoL pedidoL = new PedidoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdCliente"] == null)
                Response.Redirect("~/Vista/Auth/Login.aspx");

            if (!IsPostBack)
            {
                List<Carrito> carrito = carritoL.ObtenerCarrito();

                if (carrito.Count == 0)
                    Response.Redirect("~/Index.aspx");

                lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                rptResumen.DataSource = carrito;
                rptResumen.DataBind();
                lblTotal.Text = carritoL.ObtenerTotal().ToString("N2");
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Pago/MetodoPago.aspx", false);
            int idCliente = Convert.ToInt32(Session["IdCliente"]);
            List<Carrito> carrito = carritoL.ObtenerCarrito();

            
            Pedido pedido = pedidoL.ConfirmarPedido(carrito, idCliente);

            // Limpiar carrito después de confirmar
            Session["Carrito"] = new List<Carrito>();
            Session["CarritoModificado"] = false;

            lblMensaje.Text = "✅ Pedido confirmado con éxito. Código: " + pedido.CodigoPedido;
            lblMensaje.CssClass = "mt-3 d-block alert alert-success";

            btnConfirmar.Enabled = false;
            btnCancelar.Enabled = false;
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // No elimina el carrito, solo vuelve a la tienda
            Response.Redirect("~/Vista/Tienda.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Tienda.aspx");
        }
    }
}