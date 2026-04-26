using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EatMall.Modelo;

namespace EatMall.Datos
{
	public class MenuD
	{
		public List<Menu> ObtenerMenuPorRol(string rol)
		{
			List<Menu> menus = new List<Menu>();
			using (SqlConnection cn = ConexionDB.MtAbrirConexion())
			{
				cn.Open();
				string consulta = @"
                WITH MenuRecursivo AS (
                SELECT m.Id, m.Nombre, m.IdPadre, m.Ruta, mr.Orden
                FROM Menu m
                INNER JOIN MenuRol mr ON m.Id = mr.IdMenu
                INNER JOIN Rol r ON mr.IdRol = r.Id
                WHERE r.Rol = @Rol

                UNION ALL

                SELECT hijo.Id, hijo.Nombre, hijo.IdPadre, hijo.Ruta, hijo.Id AS Orden
                FROM Menu hijo
                INNER JOIN MenuRecursivo mr ON hijo.IdPadre = mr.Id
                )
                SELECT DISTINCT Id, Nombre, IdPadre, Ruta, Orden
                FROM MenuRecursivo
                ORDER BY IdPadre, Orden";

				using (SqlCommand cmd = new SqlCommand(consulta, cn))
				{
					cmd.Parameters.AddWithValue("@Rol", rol);

					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							menus.Add(new Menu
							{
								Id = Convert.ToInt32(dr["Id"]),
								Nombre = dr["Nombre"].ToString(),
								IdPadre = dr["IdPadre"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["IdPadre"]),
								Ruta = dr["Ruta"].ToString(),
								Orden = Convert.ToInt32(dr["Orden"])
							});
						}
					}
				}
			}
			return menus;
		}
	}
}
    