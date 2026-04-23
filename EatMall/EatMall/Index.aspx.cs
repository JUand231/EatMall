using EatMall.Logica;
using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EatMall
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CentroComercialL logica = new CentroComercialL();
                rptCentrosComerciales.DataSource = logica.MtListarCentrosComercial();
                rptCentrosComerciales.DataBind();
                CargarDatosHome();

			}
        }
        

		private void CargarDatosHome()
		{
			try
			{
				CentroComercialL logica = new CentroComercialL();
				var listaCC = logica.MtListarCentrosComercial();

				// Llenamos ambos controles con la lista completa inicialmente
				rptCarousel.DataSource = listaCC;
				rptCarousel.DataBind();

				rptCentrosComerciales.DataSource = listaCC;
				rptCentrosComerciales.DataBind();
			}
			catch (Exception ex)
			{
				Response.Write("Error al cargar datos: " + ex.Message);
			}
		}
	}
}