using EatMall.Logica;
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
            }
        }
    }
}