using EatMall.Logica;
using EatMall.Modelo;
using System;
using System.Collections.Generic;
//using System.Web.UI.WebControls;


namespace EatMall.Vista.Pedido
{
    public partial class ConfirmarPedido : System.Web.UI.Page
    {
        private CarritoL carritoL = new CarritoL();
        private PedidoL pedidoL = new PedidoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdCliente"] == null)
                Response.Redirect("~/Vista/Auth/Login.aspx");

            if (!IsPostBack)
            {
                List<Carrito> carrito = carritoL.ObtenerCarrito();

                if (carrito.Count == 0)
                    Response.Redirect("~/Index.aspx");

                //lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                //rptResumen.DataSource = carrito;
                //rptResumen.DataBind();
                //lblTotal.Text = carritoL.ObtenerTotal().ToString("N2");

                // Cargar horarios disponibles (8:00 AM a 8:00 PM)
                //ddlHoraEntrega.Items.Clear();
                //for (int i = 8; i <= 20; i++)
                //{
                //    string hora = i.ToString("00") + ":00";
                //    ddlHoraEntrega.Items.Add(new ListItem(hora, hora));
                //}
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32(Session["IdCliente"]);
            List<Carrito> carrito = carritoL.ObtenerCarrito();

            // 1. Obtener la hora seleccionada del DropDown
            //string horaSeleccionada = ddlHoraEntrega.SelectedValue;

            // 2. Guardamos el total para la siguiente pantalla
            decimal total = carritoL.ObtenerTotal();
            Session["Total"] = total.ToString("N2");

            // 3. Creamos el registro del pedido en la base de datos
            //Modelo.Pedido pedido = pedidoL.ConfirmarPedido(carrito, idCliente, horaSeleccionada);

            // 4. Guardamos datos del pedido para usarlos en el pago y el recibo
            //Session["CodigoPedido"] = pedido.CodigoPedido;
            //Session["IdPedido"] = pedido.Id; // Muy importante para la transacción

           
            // El carrito se mantiene vivo hasta que el pago se apruebe.
            Response.Redirect("~/Vista/Pago/MetodosPago.aspx");
        }
        

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // No elimina el carrito, solo vuelve a la tienda
            Response.Redirect("~/Vista/Local/Tienda.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Local/Tienda.aspx");
        }
    }
}