using EatMall.Logica;
<<<<<<< HEAD
using EatMall.Modelo;
=======
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
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
<<<<<<< HEAD
                CargarDatosHome();

			}
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBusqueda.Text.Trim()))
            {
                // Redirige a la página de resultados pasando el término como querystring
                Response.Redirect("Vista/Busqueda/Resultados.aspx?q=" + Server.UrlEncode(txtBusqueda.Text.Trim()));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "warning",
                    "Swal.fire({ icon: 'warning', title: 'Advertencia', text: 'Ingrese un término de búsqueda.' });", true);
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
=======
            }
        }
    }
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
}