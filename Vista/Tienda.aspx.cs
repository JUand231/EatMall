using EatMall.Logica;
using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EatMall.Vista
{
    public partial class Tienda : System.Web.UI.Page
    {
        private ProductoL productoL = new ProductoL();
        private CarritoL carritoL = new CarritoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IdCliente"] == null)
                    Response.Redirect("~/Vista/Auth/Login.aspx");

                carritoL.LimpiarSiNoHuboMovimiento();
                CargarProductos();
                CargarCarrito();
            }
        }

        private void CargarProductos()
        {
            rptProductos.DataSource = productoL.ObtenerProductos();
            rptProductos.DataBind();
        }

        private void CargarCarrito()
        {
            rptCarrito.DataSource = carritoL.ObtenerCarrito();
            rptCarrito.DataBind();
            lblTotal.Text = carritoL.ObtenerTotal().ToString("N2");
        }

        protected void rptProductos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AgregarCarrito")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                // Leer cantidad del TextBox dentro del item
                TextBox txtCantidad = (TextBox)e.Item.FindControl("txtCantidad");
                int cantidad = 1;
                if (txtCantidad != null && int.TryParse(txtCantidad.Text, out int cant) && cant > 0)
                    cantidad = cant;

                Producto producto = productoL.ObtenerProductos().Find(p => p.Id == id);
                if (producto != null)
                carritoL.AgregarProducto(producto, cantidad);

                Response.Redirect(Request.Url.AbsolutePath);
            }
        }

        protected void rptCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                carritoL.EliminarProducto(id);
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }
        protected void btnIrConfirmar_Click(object sender, EventArgs e)
        {
            if (carritoL.ObtenerCarrito().Count == 0)
            {
                // No hacer nada si el carrito está vacío
                return;
            }
            Session["CarritoModificado"] = true;
            Response.Redirect("~/Vista/ConfirmarPedido.aspx");
        }
    }
}