using EatMall.Logica;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EatMall.Modelo; // Importante para reconocer la clase Cliente

namespace EatMall.Vista
{
	public partial class Site : System.Web.UI.MasterPage
	{
		private CarritoL carritoL = new CarritoL();

		protected void Page_Load(object sender, EventArgs e)
		{
			// 1. Actualizar siempre el carrito al cargar
			ActualizarBadgeCarrito();

			// 2. Usar la variable de sesión unificada "Usuario"
			if (Session["Usuario"] != null)
			{
				// Recuperamos el objeto completo
				UsuarioLogin oUsuario = (UsuarioLogin)Session["Usuario"];

				// Configuramos la visibilidad de los paneles
				pnlLogin.Visible = false;
				pnlRegistro.Visible = false; // Asegúrate de ocultar también el registro
				pnlPerfil.Visible = true;

				// Mostramos el nombre del objeto Cliente
				lblNombreUsuario.Text = oUsuario.Nombre;
			}
			else
			{
				pnlLogin.Visible = true;
				pnlRegistro.Visible = true;
				pnlPerfil.Visible = false;
			}
		}

		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			string busqueda = txtBusqueda.Text.Trim();
			if (!string.IsNullOrEmpty(busqueda))
			{
				Response.Redirect("/Vista/Busqueda/Resultados.aspx?q=" + Server.UrlEncode(busqueda));
			}
			else
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "warning",
					"Swal.fire({ icon: 'warning', title: '¿Qué buscas?', text: 'Ingresa el nombre de un restaurante o centro comercial.' });", true);
			}
		}

		private void ActualizarBadgeCarrito()
		{
			// Prevenir errores si el carrito devuelve null
			int cantidad = carritoL.ObtenerCantidadTotal();
			lblCantidadCarrito.Text = cantidad.ToString();
		}

		protected void btnCerrarSesion_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Session.Abandon(); // Es mejor añadir Abandon para limpiar cookies de sesión
			Response.Redirect("/Index.aspx");
		}
	}
}