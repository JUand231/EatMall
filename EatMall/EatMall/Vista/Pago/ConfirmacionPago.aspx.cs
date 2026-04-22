using EatMall.Logica;
using EatMall.Modelo;
using System;

namespace EatMall.Vista.Pago
{
    public partial class ConfirmacionPago : System.Web.UI.Page
    {
        TransaccionL logica = new TransaccionL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MetodoPago"] == null)
                {
                    Response.Redirect("~/Vista/Pago/MetodoPago.aspx");
                    return;
                }

                int idMetodo = Convert.ToInt32(Session["MetodoPago"]);
                int idLocal = Session["IdLocal"] != null ? (int)Session["IdLocal"] : 0;

                MetodoPagoL metodoL = new MetodoPagoL();
                var metodos = metodoL.ObtenerMetodos(idLocal);
                var metodoSeleccionado = metodos.Find(m => m.Id == idMetodo);

                if (metodoSeleccionado != null)
                {
                    lblMetodo.Text = metodoSeleccionado.NombreMetodo;
                    Session["NombreMetodoPago"] = metodoSeleccionado.NombreMetodo;
                }
                else
                    Response.Redirect("~/Vista/Pago/MetodoPago.aspx");

                lblTotal.Text = Session["Total"] != null ? "$" + Session["Total"].ToString() : "$0";
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Transaccion oTransaccion = new Transaccion()
            {
                IdMetodoPago = Convert.ToInt32(Session["MetodoPago"]),
                Monto = 50000,
                Estado = "Aprobado",
                FechaTransaccion = DateTime.Now
            };

            int idPedido = 1;
            int idTransaccion = logica.ProcesarPago(oTransaccion, idPedido);
            Session["IdTransaccion"] = idTransaccion;
            Response.Redirect("~/Vista/Pago/Recibo.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Pago/MetodoPago.aspx");
        }
    }
}