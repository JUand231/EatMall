using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EatMall.Modelo;

namespace EatMall.Datos
{
	public class RegistroD
	{
		public bool MtRegistrarCliente(Cliente oCliente)
		{
			bool resultado = false;

			try
			{
				using (SqlConnection cn = ConexionDB.MtAbrirConexion())
				{
					cn.Open();
					using (SqlCommand cmd = new SqlCommand("SpRegistrarUsuarioCliente", cn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@Nombre", oCliente.Nombre);
						cmd.Parameters.AddWithValue("@Apellido", oCliente.Apellido);
						cmd.Parameters.AddWithValue("@Documento", oCliente.Documento);
						cmd.Parameters.AddWithValue("@Email", oCliente.Email);
						cmd.Parameters.AddWithValue("@Telefono", oCliente.Telefono);
						cmd.Parameters.AddWithValue("@Contraseña", oCliente.Contraseña);
						cmd.Parameters.AddWithValue("@Estado", true);

						int filasAfectadas = cmd.ExecuteNonQuery();
						if (filasAfectadas > 0)
						{
							resultado = true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				resultado = false;
				throw new Exception("Error al registrar el cliente: " + ex.Message);
			}

			return resultado;
		}

		public bool MtVerificarEmailExistente(string email)
		{
			bool existe = false;
			using (SqlConnection cn = ConexionDB.MtAbrirConexion())
			{
				cn.Open();
				string consulta = "SELECT COUNT(*) FROM Usuario WHERE Email = @Email";
				using (SqlCommand cmd = new SqlCommand(consulta, cn))
				{
					cmd.Parameters.AddWithValue("@Email", email);
					int count = Convert.ToInt32(cmd.ExecuteScalar());
					existe = count > 0;
				}
				return existe;
			}
		}
	}
}