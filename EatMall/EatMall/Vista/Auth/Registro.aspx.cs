using System;
using System.Web.UI;// Asegúrate de que coincida con tu proyecto
using EatMall.Logica;
using EatMall.Modelo;    // Asegúrate de que coincida con tu proyecto

namespace EatMall.Vista.Auth
{
	public partial class Registro : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// Lógica de carga de página si es necesaria
		}

		protected void btnRegistrar_Click(object sender, EventArgs e)
		{
			try
			{
				// 1. Validación básica de campos vacíos
				if (string.IsNullOrWhiteSpace(txtDocumento.Text) ||
					string.IsNullOrWhiteSpace(txtNombre.Text) ||
					string.IsNullOrWhiteSpace(txtEmail.Text) ||
					string.IsNullOrWhiteSpace(txtPassword.Text))
				{
					string scriptCampos = "Swal.fire({ title: 'Atención', text: 'Por favor, completa todos los campos obligatorios.', icon: 'warning', confirmButtonColor: '#f58220' });";
					ScriptManager.RegisterStartupScript(this, GetType(), "showalert", scriptCampos, true);
					return;
				}

				// 2. Llenar el objeto Cliente con los datos del formulario
				Cliente nuevoUsuario = new Cliente()
				{
					Documento = txtDocumento.Text,
					Nombre = txtNombre.Text,
					Apellido = txtApellido.Text,
					Email = txtEmail.Text,
					Telefono = txtTelefono.Text,
					Contraseña = txtPassword.Text,
					Estado = true // Entra activo por defecto según tu requerimiento actual
				};

				// 3. Llamar a la lógica de negocio
				RegistroL logica = new RegistroL();
				Cliente resultado = logica.MtRegistrarCliente(nuevoUsuario);

				if (resultado != null)
				{
					// 4. Registro exitoso: Mostrar SweetAlert y luego redirigir al Login
					// Usamos .then() en JS para que la redirección ocurra solo después de cerrar la alerta
					string scriptExito = @"Swal.fire({ 
                        title: '¡Éxito!', 
                        text: 'Te has registrado correctamente en EatMall.', 
                        icon: 'success', 
                        confirmButtonColor: '#f58220' 
                    }).then((result) => { 
                        if (result.isConfirmed) { 
                            window.location.href = 'Login.aspx'; 
                        } 
                    });";

					ScriptManager.RegisterStartupScript(this, GetType(), "showalert", scriptExito, true);
				}
			}
			catch (Exception ex)
			{
				// 5. CAPTURA DE ERRORES (Aquí llega el mensaje de 'Email ya existe' desde SQL)
				// Limpiamos el mensaje de saltos de línea o comillas que rompan el JS
				string mensajeError = ex.Message.Replace("'", "").Replace("\n", " ");

				string scriptError = $"Swal.fire({{ title: 'Atención', text: '{mensajeError}', icon: 'warning', confirmButtonColor: '#f58220' }});";

				ScriptManager.RegisterStartupScript(this, GetType(), "showalert", scriptError, true);
			}
		}

		protected void btnVolver_Click(object sender, EventArgs e)
		{
			// Redirigir a la página principal o de bienvenida
			Response.Redirect("../../Index.aspx");
		}
	}
}