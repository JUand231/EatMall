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
            int idCliente = Convert.ToInt32(Session["IdCliente"]);
            List<Carrito> carrito = carritoL.ObtenerCarrito();

            // Guardar el total en Session antes de redirigir
            decimal total = carritoL.ObtenerTotal();
            Session["Total"] = total.ToString("N2");

            Pedido pedido = pedidoL.ConfirmarPedido(carrito, idCliente);
            Session["CodigoPedido"] = pedido.CodigoPedido;

            Session["Carrito"] = new List<Carrito>();
            Session["CarritoModificado"] = false;

            Response.Redirect("~/Vista/Pago/MetodoPago.aspx");
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