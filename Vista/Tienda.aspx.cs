using EatMall.Logica;
using EatMall.Modelo;
using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;
using System.Web;
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
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
<<<<<<< HEAD
                if (!string.IsNullOrEmpty(Request.QueryString["idLocal"]))
                    Session["IdLocal"] = Convert.ToInt32(Request.QueryString["idLocal"]);
=======
                if (Session["IdCliente"] == null)
                    Response.Redirect("~/Vista/Auth/Login.aspx");
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0

                carritoL.LimpiarSiNoHuboMovimiento();
                CargarProductos();
                CargarCarrito();
            }
        }

        private void CargarProductos()
        {
<<<<<<< HEAD
            int idLocal = Session["IdLocal"] != null ? (int)Session["IdLocal"] : 0;
            rptProductos.DataSource = productoL.ObtenerProductos(idLocal);
=======
            rptProductos.DataSource = productoL.ObtenerProductos();
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
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
<<<<<<< HEAD
                int idLocal = Session["IdLocal"] != null ? (int)Session["IdLocal"] : 0;

=======

                // Leer cantidad del TextBox dentro del item
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
                TextBox txtCantidad = (TextBox)e.Item.FindControl("txtCantidad");
                int cantidad = 1;
                if (txtCantidad != null && int.TryParse(txtCantidad.Text, out int cant) && cant > 0)
                    cantidad = cant;

<<<<<<< HEAD
                Producto producto = productoL.ObtenerProductos(idLocal).Find(p => p.Id == id);
                if (producto != null)
                    carritoL.AgregarProducto(producto, cantidad);
=======
                Producto producto = productoL.ObtenerProductos().Find(p => p.Id == id);
                if (producto != null)
                carritoL.AgregarProducto(producto, cantidad);
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0

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
<<<<<<< HEAD

        protected void btnIrConfirmar_Click(object sender, EventArgs e)
        {
            if (carritoL.ObtenerCarrito().Count == 0)
                return;

            if (Session["IdCliente"] == null)
            {
                Response.Redirect("~/Vista/Auth/Login.aspx");
                return;
            }

=======
        protected void btnIrConfirmar_Click(object sender, EventArgs e)
        {
            if (carritoL.ObtenerCarrito().Count == 0)
            {
                // No hacer nada si el carrito está vacío
                return;
            }
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
            Session["CarritoModificado"] = true;
            Response.Redirect("~/Vista/ConfirmarPedido.aspx");
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
