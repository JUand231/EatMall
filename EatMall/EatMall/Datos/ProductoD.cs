using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EatMall.Datos
{
    public class ProductoD
    {
        public List<Producto> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();
            string consulta = @"SELECT Producto.*, CategoriaProducto.Nombre AS Categoria, 
                                Local.Nombre AS NombreLocal
                                FROM Producto
                                INNER JOIN CategoriaProducto ON Producto.IdCategoria = CategoriaProducto.Id
                                INNER JOIN Local ON Producto.IdLocal = Local.Id
                                WHERE Producto.Estado = 1";

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
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
                                
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}