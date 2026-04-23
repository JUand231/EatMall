using EatMall.Logica;
using EatMall.Modelo;
using System;
using System.Web.UI.WebControls;

namespace EatMall.Vista.Local
{
    public partial class Tienda : System.Web.UI.Page
    {
        private ProductoL productoL = new ProductoL();
        private CarritoL carritoL = new CarritoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idPlazoleta = Request.QueryString["idPlazoleta"];

                btnVolverLocal.NavigateUrl =
                    "~/Vista/Local/Local.aspx?idPlazoleta=" + idPlazoleta;

                if (!string.IsNullOrEmpty(Request.QueryString["idLocal"]))
                    Session["IdLocal"] = Convert.ToInt32(Request.QueryString["idLocal"]);

                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            int idLocal = Session["IdLocal"] != null ? (int)Session["IdLocal"] : 0;
            rptProductos.DataSource = productoL.ObtenerProductos(idLocal);
            rptProductos.DataBind();
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

                Response.Redirect(Request.Url.AbsolutePath + "?" + Request.QueryString);
            }
        }
    }
}