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
            if (!IsPostBack)
            {
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
                    "alert('Por favor selecciona un método de pago');", true);
                return;
            }

            Session["MetodoPago"] = metodoSeleccionado;
            Response.Redirect("~/Vista/Pago/ConfirmacionPago.aspx");
        }
    }
}