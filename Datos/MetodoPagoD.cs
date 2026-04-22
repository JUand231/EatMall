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
        public List<MetodoPago> ObtenerMetodos()
        {
            List<MetodoPago> lista = new List<MetodoPago>();
            SqlConnection con = ConexionDB.MtAbrirConexion();

            string query = "Select Id, NombreMetodo, Estado From MetodoPago Where Estado = 1";
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