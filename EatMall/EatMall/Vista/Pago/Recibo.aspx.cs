using System;

namespace EatMall.Vista.Pago
{
    public partial class Recibo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IdTransaccion"] == null)
                {
                    Response.Redirect("~/Vista/Pago/MetodoPago.aspx");
                    return;
                }

                lblIdTransaccion.Text = "#" + Session["IdTransaccion"].ToString();
                lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                lblEstado.Text = "Aprobado";
                lblTotal.Text = "$" + (Session["Total"] != null ? Session["Total"].ToString() : "0");
                lblMetodo.Text = Session["NombreMetodoPago"] != null ? Session["NombreMetodoPago"].ToString() : "";
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Index.aspx");
        }
    }
}