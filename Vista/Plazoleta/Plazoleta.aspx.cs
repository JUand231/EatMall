using EatMall.Logica;
using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace EatMall.Vista
{
    public partial class Plazoletas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idCC = 0;

                if (Request.QueryString["id"] != null)
                {
                    idCC = Convert.ToInt32(Request.QueryString["id"]);
                }

                PlazoletaL logica = new PlazoletaL();
                List<Plazoleta> lista = logica.MtListarPlazoletas(idCC);
                rptPlazoletas.DataSource = lista;
                rptPlazoletas.DataBind();

                if (lista.Count == 0)
                {
                    lblMensaje.Text = "No hay plazoletas disponibles para este centro comercial.";
                }
            }
        }
        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string idPlazoleta = btn.CommandArgument;
            Response.Redirect("~/Vista/Local/Local.aspx?idPlazoleta=" + idPlazoleta);
        }
    }
}