using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EatMall.Datos
{
    public class ProductoD
    {
        public List<Producto> ObtenerProductos(int idLocal)
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("SpListarProductosPorLocal", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdLocal", idLocal);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Imagen = dr["Imagen"].ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                Local = new Local()
                                {
                                    Id = Convert.ToInt32(dr["IdLocal"])
                                }
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}