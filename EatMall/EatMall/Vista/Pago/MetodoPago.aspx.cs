using EatMall.Logica;
using EatMall.Modelo;
using System;

namespace EatMall.Vista.Pago
{
    public partial class MetodosPago : System.Web.UI.Page
    {
        MetodoPagoL metodo = new MetodoPagoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            // MAL: Si esto está aquí suelto, se ejecuta siempre y puede resetear datos
            // Session["Carrito"] = new List<Carrito>(); 

            if (!IsPostBack)
            {
                // BIEN: Aquí solo se carga la lista de métodos
                int idLocal = Session["IdLocal"] != null ? (int)Session["IdLocal"] : 0;
                rptMetodos.DataSource = metodo.ObtenerMetodos(idLocal);
                rptMetodos.DataBind();
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            string metodoSeleccionado = hfMetodoPago.Value;

            if (string.IsNullOrEmpty(metodoSeleccionado))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta",
                    "alert('No se detectó ningún método seleccionado');", true);
                return;
            }

            // DIAGNÓSTICO: Ver si el carrito existe justo antes de irnos
            var carrito = (System.Collections.Generic.List<EatMall.Modelo.Carrito>)Session["Carrito"];
            if (carrito == null || carrito.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta",
                   "alert('¡Alerta! El carrito ya estaba vacío antes de salir de esta página');", true);
                return;
            }

            Session["MetodoPago"] = metodoSeleccionado;
            Response.Redirect("~/Vista/Pago/ConfirmacionPago.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}