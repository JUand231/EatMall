using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EatMall.Datos
{
    public class ProductoD
    {
        public List<Producto> ObtenerProductos(int idLocal)
        {
            List<Producto> lista = new List<Producto>();
            string consulta = "SELECT P.Id, P.Nombre, P.Descripcion, P.Imagen, P.Precio, P.Estado, L.Id as IdLocal FROM Producto P join Local L on L.id = P.IdLocal";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(consulta, connection);
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
                            Estado = reader.GetBoolean(5) ? "Activo" : "Inactivo"
                            Local = new Local()
                            {
                                Id = (int)reader.GetInt32(4)
                            }


                        });
                    }
                }
            }
            return lista;
        }
    }
}