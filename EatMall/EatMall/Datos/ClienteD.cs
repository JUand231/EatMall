using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace EatMall.Datos
{
    public class ClienteD
    {
        public Cliente ObtenerClientePorId(int id)
        {
            Cliente oCliente = null;
            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Nombre, Apellido, Documento, Email, Telefono FROM Usuario WHERE Id = @Id", cn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oCliente = new Cliente()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Documento = dr["Documento"].ToString(),
                                Email = dr["Email"].ToString(),
                                Telefono = dr["Telefono"].ToString()
                            };
                        }
                    }
                }
            }
            return oCliente;
        }

        public bool ActualizarCliente(Cliente oCliente)
        {
            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = string.IsNullOrEmpty(oCliente.Contraseña)
                    ? "UPDATE Usuario SET Nombre=@Nombre, Apellido=@Apellido, Telefono=@Telefono WHERE Id=@Id"
                    : "UPDATE Usuario SET Nombre=@Nombre, Apellido=@Apellido, Telefono=@Telefono, Contraseña=@Contraseña WHERE Id=@Id";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", oCliente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", oCliente.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", oCliente.Telefono);
                    cmd.Parameters.AddWithValue("@Id", oCliente.Id);

                    if (!string.IsNullOrEmpty(oCliente.Contraseña))
                        cmd.Parameters.AddWithValue("@Contraseña", oCliente.Contraseña);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public List<Pedido> ObtenerPedidosPorCliente(int idCliente)
        {
            List<Pedido> lista = new List<Pedido>();
            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT Id, CodigoPedido, FechaPedido, Estado, Total, TipoEntrega FROM Pedido WHERE IdCliente = @IdCliente ORDER BY FechaPedido DESC", cn))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Pedido()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                CodigoPedido = dr["CodigoPedido"].ToString(),
                                FechaPedido = Convert.ToDateTime(dr["FechaPedido"]),
                                Estado = dr["Estado"].ToString(),
                                Total = Convert.ToDecimal(dr["Total"]),
                                TipoEntrega = dr["TipoEntrega"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}