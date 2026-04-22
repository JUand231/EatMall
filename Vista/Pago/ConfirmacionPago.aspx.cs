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
                string metodo = Session["MetodoPago"]?.ToString();

                switch (metodo)
                {
                    case "1":
                        lblMetodo.Text = "Nequi";
                        imgMetodo.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Nequi_logo.svg/1200px-Nequi_logo.svg.png";
                        break;
                    case "2":
                        lblMetodo.Text = "Daviplata";
                        imgMetodo.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4e/Daviplata_logo.svg/1200px-Daviplata_logo.svg.png";
                        break;
                    case "3":
                        lblMetodo.Text = "PSE";
                        imgMetodo.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6b/PSE_logo.svg/1200px-PSE_logo.svg.png";
                        break;
                    default:
                        Response.Redirect("~/Vista/Pago/MetodoPago.aspx");
                        break;
                }

                // Por ahora ponemos un total de prueba
                // Cuando tengas el carrito esto vendrá de Session["Total"]
                lblTotal.Text = "$50.000";
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

            // Por ahora usamos IdPedido de prueba
            // Cuando tengas el carrito esto vendrá de Session["IdPedido"]
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