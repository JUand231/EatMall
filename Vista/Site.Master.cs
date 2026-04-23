<<<<<<< HEAD
﻿using EatMall.Logica;
using System;
using System.Web.UI.WebControls;

namespace EatMall.Vista
=======
﻿using System;
using EatMall.Logica;

namespace EatMall
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private CarritoL carritoL = new CarritoL();

        protected void Page_Load(object sender, EventArgs e)
        {
            ActualizarBadgeCarrito();
<<<<<<< HEAD
            if (Session["IdCliente"] != null)
            {
                pnlLogin.Visible = false;
                pnlPerfil.Visible = true;
                lblNombreUsuario.Text = Session["NombreCliente"].ToString();
            }
            else
            {
                pnlLogin.Visible = true;
                pnlPerfil.Visible = false;
            }
=======
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
        }

        private void ActualizarBadgeCarrito()
        {
            lblCantidadCarrito.Text = carritoL.ObtenerCantidadTotal().ToString();
        }
<<<<<<< HEAD

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Index.aspx");
        }
=======
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
    }
}