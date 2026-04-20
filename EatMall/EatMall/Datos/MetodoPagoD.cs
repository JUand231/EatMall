using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EatMall.Datos
{
    public class MetodoPagoD
    {
        public List<MetodoPago> ObtenerMetodos(int idLocal)
        {
            List<MetodoPago> lista = new List<MetodoPago>();
            SqlConnection con = ConexionDB.MtAbrirConexion();

            string query = "SELECT Id, NombreMetodo, Estado FROM MetodoPago WHERE Estado = 1 AND IdLocal = @idLocal";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@idLocal", idLocal);

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