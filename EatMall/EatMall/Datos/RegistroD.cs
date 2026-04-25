using System;
using System.Data;
using System.Data.SqlClient;
using EatMall.Modelo; // Asegúrate de que apunte a tu clase Cliente

namespace EatMall.Datos
{
	public class RegistroD
	{
		public Cliente MtRegistrarCliente(Cliente oCliente)
		{
			Cliente clienteRetorno = null;

			try
			{
				// Usamos tu clase de conexión
				using (SqlConnection cn = ConexionDB.MtAbrirConexion())
				{
					using (SqlCommand cmd = new SqlCommand("SpRegistrarUsuarioCliente", cn))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						// Parámetros coincidiendo con tu procedimiento almacenado
						cmd.Parameters.AddWithValue("@Nombre", oCliente.Nombre);
						cmd.Parameters.AddWithValue("@Apellido", oCliente.Apellido);
						cmd.Parameters.AddWithValue("@Documento", oCliente.Documento);
						cmd.Parameters.AddWithValue("@Email", oCliente.Email);
						cmd.Parameters.AddWithValue("@Telefono", oCliente.Telefono);
						cmd.Parameters.AddWithValue("@Contraseña", oCliente.Contraseña);
						cmd.Parameters.AddWithValue("@Estado", oCliente.Estado);

						cn.Open();

						int filasAfectadas = cmd.ExecuteNonQuery();

						if (filasAfectadas > 0)
						{
							clienteRetorno = oCliente;
						}
					}
				}
			}
			catch (SqlException ex)
			{
				// MUY IMPORTANTE: Relanzamos el mensaje que viene desde el RAISERROR de SQL
				// Esto permite que el mensaje "El correo ya existe" llegue a la vista.
				throw new Exception(ex.Message);
			}
			catch (Exception ex)
			{
				throw new Exception("Error inesperado en la base de datos: " + ex.Message);
			}

			return clienteRetorno;
		}
	}
}