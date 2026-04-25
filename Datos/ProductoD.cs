<<<<<<< HEAD
﻿using EatMall.Modelo;
using System.Collections.Generic;
using System.Data.SqlClient;
=======
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EatMall.Modelo;
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0

namespace EatMall.Datos
{
    public class ProductoD
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
        }
    }
}