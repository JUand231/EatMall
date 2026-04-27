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
			if (!IsPostBack)
			{
				if (Session["Usuario"] != null)
				{
					UsuarioLogin oUsuario = (UsuarioLogin)Session["Usuario"];

					// Agregamos un log para depurar (puedes verlo en la consola de salida)
					System.Diagnostics.Debug.WriteLine("Rol detectado: " + oUsuario.IdRol);

					// Verificamos que sea un funcionario (1 al 4)
					if (oUsuario.IdRol >= 1 && oUsuario.IdRol <= 4)
					{
						string nombreRol = "";
						switch (oUsuario.IdRol)
						{
							case 1: nombreRol = "Admin General"; break;
							case 2: nombreRol = "Admin CC"; break;
							case 3: nombreRol = "Admin Local"; break;
							case 4: nombreRol = "Cajero"; break;
						}
						// Asegúrate de que lblUsuario existe en tu Admin.Master
						lblUsuario.Text = $"{oUsuario.Nombre} ({nombreRol})";
					}
					else
					{
						// Si es Rol 5 (Cliente), lo sacamos de la zona administrativa
						Response.Redirect("~/Index.aspx");
					}
				}
				else
				{
					// Si no hay sesión, al login
					Response.Redirect("~/Vista/Auth/Login.aspx");
				}
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