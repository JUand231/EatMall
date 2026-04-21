using EatMall.Modelo;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EatMall.Datos
{
    public class ProductoD
    {
        public List<Producto> ObtenerProductos(int idLocal)
        {
            List<Producto> lista = new List<Producto>();
            string consulta = @"SELECT P.Id, P.Nombre, P.Descripcion, P.Imagen, P.Precio, P.Estado, L.Id AS IdLocal
                                FROM Producto P
                                JOIN Local L ON L.Id = P.IdLocal
                                WHERE P.IdLocal = @idLocal";

            using (SqlConnection connection = ConexionDB.MtAbrirConexion())
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@idLocal", idLocal);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Producto
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            Imagen = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Precio = reader.GetDecimal(4),
                            Estado = reader.GetBoolean(5) ? "Activo" : "Inactivo",
                            Local = new Local { Id = reader.GetInt32(6) }
                        });
                    }
                }
            }
            return lista;
        }
    }
}