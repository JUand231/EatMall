using EatMall.Logica;
using EatMall.Modelo;
using System;
using System.Collections.Generic;

namespace EatMall.Vista.Pedido
{
    public partial class ConfirmarPedido : System.Web.UI.Page
    {
        private CarritoL carritoL = new CarritoL();
        private PedidoL pedidoL = new PedidoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
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
            int idCliente = Convert.ToInt32(Session["Usuario"]);
            List<Carrito> carrito = carritoL.ObtenerCarrito();

            // 1. Guardamos el total para la siguiente pantalla
            decimal total = carritoL.ObtenerTotal();
            Session["Total"] = total.ToString("N2");

            // 2. Creamos el registro del pedido en la base de datos
            Modelo.Pedido pedido = pedidoL.ConfirmarPedido(carrito, idCliente);

            // 3. Guardamos datos del pedido para usarlos en el pago y el recibo
            Session["CodigoPedido"] = pedido.CodigoPedido;
            Session["IdPedido"] = pedido.Id; // Muy importante para la transacción

            // --- ELIMINAMOS LAS LÍNEAS QUE VACÍAN EL CARRITO AQUÍ ---
            // El carrito se mantiene vivo hasta que el pago se apruebe.

            Response.Redirect("~/Vista/Pago/MetodosPago.aspx");
        }
        

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // No elimina el carrito, solo vuelve a la tienda
            Response.Redirect("~/Vista/Local/Tienda.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Local/Tienda.aspx");
        }
    }
}