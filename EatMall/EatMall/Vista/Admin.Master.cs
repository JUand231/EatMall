using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EatMall.Modelo;

namespace EatMall.Vista
{
	public partial class Admin : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Usuario"] != null)
			{
				UsuarioLogin oUsuario = (UsuarioLogin)Session["Usuario"];

				// Roles del 1 al 4 son funcionarios
				if (oUsuario.Rol >= 1 && oUsuario.Rol <= 4)
				{
					string nombreRol = "";
					switch (oUsuario.Rol)
					{
						case 1: nombreRol = "Admin General"; break;
						case 2: nombreRol = "Admin CC"; break;
						case 3: nombreRol = "Admin Local"; break;
						case 4: nombreRol = "Cajero"; break;
					}
					lblUsuario.Text = $"{oUsuario.Nombre} ({nombreRol})";
				}
				else
				{
					// El Rol 5 (Cliente) no entra aquí
					Response.Redirect("~/Index.aspx");
				}
			}
			else
			{
				Response.Redirect("~/Vista/Auth/Login.aspx");
			}
		}

		protected void lbCerrar_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Session.Abandon();
			Response.Redirect("~/Vista/Auth/Login.aspx");
		}
	}
}