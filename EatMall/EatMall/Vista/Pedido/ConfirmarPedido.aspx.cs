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
			UsuarioLogin oUser = (UsuarioLogin)Session["Usuario"];

			if (oUser == null)
			{
				Response.Redirect("~/Vista/Auth/Login.aspx");
				return;
			}

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
			if (Session["Usuario"] == null)
			{
				Response.Redirect("~/Vista/Auth/Login.aspx");
				return;
			}

			// EXTRAER EL ID CORRECTAMENTE
			// Usamos el objeto UsuarioLogin que guardamos en el Login
			UsuarioLogin oUser = (UsuarioLogin)Session["Usuario"];
			int idCliente = oUser.Id;

			List<Carrito> carrito = carritoL.ObtenerCarrito();

			// ... resto de tu lógica de pedido ...
			decimal total = carritoL.ObtenerTotal();
			Session["Total"] = total.ToString("N2");

			Modelo.Pedido pedido = pedidoL.ConfirmarPedido(carrito, idCliente);

			Session["CodigoPedido"] = pedido.CodigoPedido;
			Session["IdPedido"] = pedido.Id;

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