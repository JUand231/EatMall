
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using EatMall.Logica;
using EatMall.Modelo;

namespace EatMall.Datos
{
	public class LoginD
	{
		public UsuarioLogin MtLogin(UsuarioLogin oDatosSesion, string tipoUsuario)
		{
			UsuarioLogin oUsuario = null;
			using (SqlConnection cn = ConexionDB.MtAbrirConexion())
			{
				cn.Open();
				// Traemos IdRol de la tabla intermedia y Ruta de la tabla Menu
				string consulta = @"
				SELECT U.Id, U.Nombre, U.Email, RU.IdRol, M.Ruta AS RutaInicio 
				FROM Usuario U
				INNER JOIN RolUsuario RU ON RU.IdUsuario = U.Id
				INNER JOIN Rol R         ON R.Id = RU.IdRol
				INNER JOIN MenuRol MR    ON MR.IdRol = R.Id
				INNER JOIN Menu M        ON M.Id = MR.IdMenu 
				WHERE U.Email = @Email AND U.Contraseña = @Clave";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
				{
					cmd.Parameters.AddWithValue("@Email", oDatosSesion.Email);
					cmd.Parameters.AddWithValue("@Clave", oDatosSesion.Contraseña);

					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						if (dr.Read())
						{
							oUsuario = new UsuarioLogin()
							{
								Id = Convert.ToInt32(dr["Id"]),
								Nombre = dr["Nombre"].ToString(),
								Rol = Convert.ToInt32(dr["IdRol"]),
								TipoUsuario = tipoUsuario,
								UrlInicio = dr["RutaInicio"].ToString()
							};
						}
					}
				}
			}
			return oUsuario;
		}

		public List<MetodoPago> ObtenerMetodos()
		{
			List<MetodoPago> lista = new List<MetodoPago>();
			SqlConnection con = ConexionDB.MtAbrirConexion();

			string query = "SELECT Id, NombreMetodo, Estado FROM MetodoPago WHERE Estado = 1";
			SqlCommand cmd = new SqlCommand(query, con);

			con.Open();
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				lista.Add(new MetodoPago
				{
					Id = (int)reader["Id"],
					NombreMetodo = reader["NombreMetodo"].ToString(),
					Estado = (bool)reader["Estado"]
				});
			}
			con.Close();
			return lista;
		}
	}
}