using EatMall.Logica;
using EatMall.Modelo;
using System;
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
                if (!string.IsNullOrEmpty(Request.QueryString["idLocal"]))
                    Session["IdLocal"] = Convert.ToInt32(Request.QueryString["idLocal"]);

                carritoL.LimpiarSiNoHuboMovimiento();
                CargarProductos();
                CargarCarrito();
            }
        }

        private void CargarProductos()
        {
            int idLocal = Session["IdLocal"] != null ? (int)Session["IdLocal"] : 0;
            rptProductos.DataSource = productoL.ObtenerProductos(idLocal);
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
                int idLocal = Session["IdLocal"] != null ? (int)Session["IdLocal"] : 0;

                TextBox txtCantidad = (TextBox)e.Item.FindControl("txtCantidad");
                int cantidad = 1;
                if (txtCantidad != null && int.TryParse(txtCantidad.Text, out int cant) && cant > 0)
                    cantidad = cant;

                Producto producto = productoL.ObtenerProductos(idLocal).Find(p => p.Id == id);
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
                return;

            if (Session["IdCliente"] == null)
            {
                Response.Redirect("~/Vista/Auth/Login.aspx");
                return;
            }

            Session["CarritoModificado"] = true;
            Response.Redirect("~/Vista/ConfirmarPedido.aspx");
        }
    }
}
