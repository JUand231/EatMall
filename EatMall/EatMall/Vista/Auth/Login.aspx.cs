using System;
using System.Web.UI;
using EatMall.Logica;
using EatMall.Modelo;

namespace EatMall.Vista.Auth
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void btnIngresar_Click(object sender, EventArgs e)
		{
			// 1. El switch ahora solo define si buscamos personal administrativo o clientes
			{
				// 1. Validaciones de texto
				if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
				{
					lblMensaje.Text = "Faltan datos";
					lblMensaje.ForeColor = System.Drawing.Color.Red;
					return;
				}

				// 2. Definir qué modo eligió el usuario en el Switch
				// chkTipo.Checked == true  -> Quiere entrar como Administrador/Funcionario
				// chkTipo.Checked == false -> Quiere entrar como Cliente
				bool modoFuncionarioSolicitado = chkTipo.Checked;
				string tipoEtiqueta = modoFuncionarioSolicitado ? "Administrador" : "Cliente";

				UsuarioLogin oDatos = new UsuarioLogin()
				{
					Email = txtEmail.Text.Trim(),
					Contraseña = txtPassword.Text.Trim()
				};

				LoginL oLogin = new LoginL();
				UsuarioLogin oUser = oLogin.MtLogin(oDatos, tipoEtiqueta);

				if (oUser != null)
				{
					// --- INICIO DE VALIDACIÓN DE PERMISOS ---

					// CASO A: El usuario marcó "Funcionario" pero su rol en BD es 5 (Cliente)
					if (modoFuncionarioSolicitado && oUser.Rol == 5)
					{
						lblMensaje.Text = "No tienes permisos de administrador.";
						lblMensaje.ForeColor = System.Drawing.Color.OrangeRed;
						return; // Bloqueamos el ingreso
					}

					// CASO B: Es un Admin/Funcionario (Rol 1-4) pero apagó el check (Modo Cliente)
					if (!modoFuncionarioSolicitado && oUser.Rol >= 1 && oUser.Rol <= 4)
					{
						// Forzamos la redirección al Index de clientes aunque sea admin
						Session["Usuario"] = oUser;
						Response.Redirect("~/Index.aspx");
						return;
					}

					// CASO C: Todo coincide (Admin entra como Admin, o Cliente como Cliente)
					Session["Usuario"] = oUser;

					if (!string.IsNullOrEmpty(oUser.UrlInicio))
					{
						Response.Redirect(oUser.UrlInicio);
					}
					else
					{
						Response.Redirect("~/Index.aspx");
					}
				}
				else
				{
					lblMensaje.Text = "Usuario o contraseña incorrectos";
					lblMensaje.ForeColor = System.Drawing.Color.Red;
				}
			}
		}

		protected void btnVolver_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Index.aspx");
		}
	}
}