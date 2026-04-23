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
<<<<<<< HEAD
                    Response.Redirect("~/Vista/Pago/MetodoPago.aspx");
=======
                    Response.Redirect("~/Vista/Pago/MetodosPago.aspx");
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
                    return;
                }

                lblIdTransaccion.Text = "#" + Session["IdTransaccion"].ToString();
                lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                lblEstado.Text = "Aprobado";
<<<<<<< HEAD
                lblTotal.Text = "$" + (Session["Total"] != null ? Session["Total"].ToString() : "0");
                lblMetodo.Text = Session["NombreMetodoPago"] != null ? Session["NombreMetodoPago"].ToString() : "";
=======
                lblTotal.Text = "$50.000";

                string metodo = Session["MetodoPago"]?.ToString();
                switch (metodo)
                {
                    case "1": lblMetodo.Text = "Nequi"; break;
                    case "2": lblMetodo.Text = "Daviplata"; break;
                    case "3": lblMetodo.Text = "PSE"; break;
                }
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Index.aspx");
        }
    }
}