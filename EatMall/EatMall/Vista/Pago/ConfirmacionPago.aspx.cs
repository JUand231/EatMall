using EatMall.Logica;
using EatMall.Modelo;
using System;

namespace EatMall.Vista.Pago
{
    public partial class ConfirmacionPago : System.Web.UI.Page
    {
        TransaccionL logica = new TransaccionL();
        CarritoL carritoL = new CarritoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IdCliente"] == null)
                {
                    Response.Redirect("~/Vista/Auth/Login.aspx");
                    return;
                }

                // 1. Obtener el total del carrito
                decimal total = carritoL.ObtenerTotal();

                // 2. Si el carrito reporta 0, intentar recuperar de la Session (por si acaso)
                if (total <= 0 && Session["Total"] != null)
                {
                    total = Convert.ToDecimal(Session["Total"]);
                }

                // 3. Validar si realmente no hay nada que pagar
                if (total <= 0)
                {
                    
                    lblTotal.Text = "Error: El carrito reporta 0";
                    return;
                }

                
                CargarResumenPago(total);
            }
        }

        private void CargarResumenPago(decimal total)
        {
            try
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
                var seleccionado = metodos.Find(m => m.Id == idMetodo);

                if (seleccionado != null)
                {
                    lblMetodo.Text = seleccionado.NombreMetodo;

                    
                    lblTotal.Text = total.ToString("C");

                    Session["Total"] = total;
                }
                else
                {
                    Response.Redirect("~/Vista/Pago/MetodoPago.aspx");
                }
            }
            catch (Exception ex)
            {
                
                Response.Redirect("~/Vista/Pago/MetodoPago.aspx");
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            // OBTENEMOS EL TOTAL ANTES DE VACIAR NADA
            decimal montoAPagar = carritoL.ObtenerTotal();
            if (montoAPagar <= 0 && Session["Total"] != null)
                montoAPagar = Convert.ToDecimal(Session["Total"]);

            Transaccion oTransaccion = new Transaccion()
            {
                IdMetodoPago = Convert.ToInt32(Session["MetodoPago"]),
                Monto = montoAPagar,
                Estado = "Aprobado",
                FechaTransaccion = DateTime.Now
            };

            // ID del pedido que deberías tener en Session
            int idPedido = Session["IdPedido"] != null ? Convert.ToInt32(Session["IdPedido"]) : 1;

            int idTransaccion = logica.ProcesarPago(oTransaccion, idPedido);

            if (idTransaccion > 0)
            {
                // SOLO AQUÍ SE VACÍA EL CARRITO
                carritoL.VaciarCarritoDespuesDePedido();

                Session["IdTransaccion"] = idTransaccion;
                Response.Redirect("~/Vista/Pago/Recibo.aspx");
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Redirige de vuelta al método de pago o al carrito si el usuario desiste
            Response.Redirect("~/Vista/Pago/MetodoPago.aspx");
        }
    }
}