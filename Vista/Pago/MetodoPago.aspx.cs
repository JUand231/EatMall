using EatMall.Logica;
<<<<<<< HEAD
using EatMall.Modelo;
=======
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
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
<<<<<<< HEAD
                int idLocal = Session["IdLocal"] != null ? (int)Session["IdLocal"] : 0;
                rptMetodos.DataSource = metodo.ObtenerMetodos(idLocal);
=======
                rptMetodos.DataSource = metodo.ObtenerMetodos();
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
                rptMetodos.DataBind();
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            string metodoSeleccionado = hfMetodoPago.Value;
=======
            string metodoSeleccionado = Request.Form["metodoPago"];
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0

            if (string.IsNullOrEmpty(metodoSeleccionado))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta",
                    "alert('Por favor selecciona un método de pago');", true);
                return;
            }

            Session["MetodoPago"] = metodoSeleccionado;
            Response.Redirect("~/Vista/Pago/ConfirmacionPago.aspx");
        }
<<<<<<< HEAD
=======

>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
    }
}