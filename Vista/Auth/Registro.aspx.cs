using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EatMall.Datos;
using EatMall.Logica;
using EatMall.Modelo;

namespace EatMall.Vista.Auth
{
	public partial class Registro : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnRegistrar_Click(object sender, EventArgs e)
		{
			try
			{
				// 1. Validaciones básicas
				if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
				{
					ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Swal.fire('Atención', 'Completa los campos obligatorios', 'warning');", true);
					return;
				}

				// 2. Llenar objeto Cliente
				Cliente nuevoUsuario = new Cliente()
				{
					Documento = txtDocumento.Text,
					Nombre = txtNombre.Text,
					Apellido = txtApellido.Text,
					Email = txtEmail.Text,
					Telefono = txtTelefono.Text,
					Contraseña = txtPassword.Text,
					Estado = true // Sigue entrando activo por ahora
				};

				// 3. Llamar a la lógica
				RegistroL logica = new RegistroL();
				Cliente resultado = logica.MtRegistrarCliente(nuevoUsuario);

				if (resultado != null)
				{
					// Éxito: Alerta y luego redirigir
					string scriptExito = "Swal.fire({ title: '¡Éxito!', text: 'Usuario registrado correctamente', icon: 'success', confirmButtonColor: '#f58220' }).then((result) => { if (result.isConfirmed) { window.location.href = 'Login.aspx'; } });";
					ScriptManager.RegisterStartupScript(this, GetType(), "showalert", scriptExito, true);
				}
			}
			catch (Exception ex)
			{
				// AQUÍ es donde atrapas el mensaje de SQL "El correo ya existe"
				// Limpiamos el mensaje por si trae comillas simples que rompan el JS
				string mensajeLimpio = ex.Message.Replace("'", "");

				string scriptError = $"Swal.fire({{ title: 'Atención', text: '{mensajeLimpio}', icon: 'warning', confirmButtonColor: '#f58220' }});";
				ScriptManager.RegisterStartupScript(this, GetType(), "showalert", scriptError, true);
			}
		}



		protected void btnVolver_Click(object sender, EventArgs e)
		{

			// Redirige a tu página principal o al Login
			Response.Redirect("Login.aspx");

		}
	}
}