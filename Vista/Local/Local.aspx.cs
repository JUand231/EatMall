<<<<<<< HEAD
﻿ using EatMall.Logica;
=======
﻿using EatMall.Logica;
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace EatMall.Vista.Pago
{
    public partial class Local : Page
    {
        LocalL localL = new LocalL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLocales();
            }
        }

        private void CargarLocales()
        {
            int idPlazoleta = Convert.ToInt32(Request.QueryString["idPlazoleta"]);

            List<Modelo.Local> lista = localL.MtListarLocales(idPlazoleta);

            if (lista.Count == 0)
            {
                lblMensaje.Text = "No hay locales disponibles en esta plazoleta.";
                lblMensaje.Visible = true;
            }

            rptLocales.DataSource = lista;
            rptLocales.DataBind();
        }
    }
}