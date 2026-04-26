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
        private LocalL localL = new LocalL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["idPlazoleta"]))
                    Session["IdPlazoleta"] = Request.QueryString["idPlazoleta"];

                if (!string.IsNullOrEmpty(Request.QueryString["idCC"]))
                    Session["IdCC"] = Request.QueryString["idCC"];

                string idPlazoleta = Request.QueryString["idPlazoleta"] ?? Session["IdPlazoleta"]?.ToString();
                string idCC = Request.QueryString["idCC"] ?? Session["IdCC"]?.ToString();

                btnVolverLocal.NavigateUrl =
                    "~/Vista/Local/Local.aspx?idPlazoleta=" + idPlazoleta + "&idCC=" + idCC;

                if (!string.IsNullOrEmpty(Request.QueryString["idLocal"]))
                {
                    int idLocal = Convert.ToInt32(Request.QueryString["idLocal"]);
                    Session["IdLocal"] = idLocal;
                    CargarInformacionLocal(idLocal);
                }
                else if (Session["IdLocal"] != null)
                {
                    int idLocal = (int)Session["IdLocal"];
                    CargarInformacionLocal(idLocal);
                }

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
                int idProducto = Convert.ToInt32(e.CommandArgument);
                int idLocal = Session["IdLocal"] != null ? (int)Session["IdLocal"] : 0;

                TextBox txtCantidad = (TextBox)e.Item.FindControl("txtCantidad");

                int cantidad = 1;

                if (txtCantidad != null &&
                    int.TryParse(txtCantidad.Text, out int cant) &&
                    cant > 0)
                {
                    cantidad = cant;
                }

                Producto producto =
                    productoL.ObtenerProductos(idLocal)
                    .Find(p => p.Id == idProducto);

                if (producto != null)
                {
                    carritoL.AgregarProducto(producto, cantidad);
                }

                Response.Redirect(Request.RawUrl);
            }
        }

        private void CargarInformacionLocal(int idLocal)
        {
            Modelo.Local local = localL.ObtenerLocalPorId(idLocal);

            if (local == null)
            {
                Response.Write("LOCAL NULL");
            }

            if (local != null)
            {
                imgLocalInfo.ImageUrl = local.Imagen;
                lblNombreLocal.Text = local.Nombre;
                lblDescripcionLocal.Text = local.Descripcion;
                lblHorario.Text = local.HorarioLocal;
                lblTelefono.Text = local.Telefono;
                lblEmail.Text = local.Email;
                lblEstado.Text = local.Estado;
                lblCalificacion.Text = local.Calificacion.Puntaje.ToString("0.0");
            }
        }
    }
}