using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EatMall.Modelo;

namespace EatMall.Datos
{
    public class ProductoD
    {
        public List<Producto> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();
            string consulta = "SELECT P.Id, P.Nombre, P.Descripcion, P.Imagen, P.Precio, P.Estado, L.Id as IdLocal FROM Producto P join Local L on L.id = P.IdLocal";

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto
                            {
                                Id = dr.GetInt32(0),
                                Nombre = dr.GetString(1),
                                Descripcion = dr.IsDBNull(2) ? "" : dr.GetString(2),
                                Imagen = dr.IsDBNull(3) ? "" : dr.GetString(3),
                                Precio = dr.GetDecimal(4),
                                Estado = dr.GetBoolean(5) ? "Activo" : "Inactivo",
                                Local = new Local()
                                {
                                    Id = (int)dr.GetInt32(4)
                                }


                            });
                        }
                    }
                }
                return lista;
            }
        }
    }
}