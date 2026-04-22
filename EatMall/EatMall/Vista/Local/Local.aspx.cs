using EatMall.Logica;
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
                // BOTÓN VOLVER → PLAZOLETA
                string idPlazoleta = Request.QueryString["idPlazoleta"];

                btnVolverPlazoleta.NavigateUrl =
                    "~/Vista/Plazoleta/Plazoleta.aspx?id=" + idPlazoleta;

                CargarLocales();
            }
        }

        private void CargarLocales()
        {
            int idPlazoleta = 0;

            int.TryParse(Request.QueryString["idPlazoleta"], out idPlazoleta);

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