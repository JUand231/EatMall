using EatMall.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EatMall.Vista.Busqueda
{
    public partial class Resultados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string termino = Request.QueryString["q"];

                if (!string.IsNullOrEmpty(termino))
                {
                    BusquedaL oBusquedaL = new BusquedaL();

                    rptLocales.DataSource = oBusquedaL.MtBuscarLocales(termino);
                    rptLocales.DataBind();

                    rptProductos.DataSource = oBusquedaL.MtBuscarProductos(termino);
                    rptProductos.DataBind();

                    rptCentros.DataSource = oBusquedaL.MtBuscarCentroComercialPorCiudad(termino);
                    rptCentros.DataBind();
                }
            }
        }
    }
}