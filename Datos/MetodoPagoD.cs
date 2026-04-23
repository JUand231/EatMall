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
<<<<<<< HEAD
        public List<MetodoPago> ObtenerMetodos(int idLocal)
=======
        public List<MetodoPago> ObtenerMetodos()
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
        {
            List<MetodoPago> lista = new List<MetodoPago>();
            SqlConnection con = ConexionDB.MtAbrirConexion();

<<<<<<< HEAD
            string query = "SELECT Id, NombreMetodo, Estado FROM MetodoPago WHERE Estado = 1 AND IdLocal = @idLocal";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@idLocal", idLocal);
=======
            string query = "Select Id, NombreMetodo, Estado From MetodoPago Where Estado = 1";
            SqlCommand cmd = new SqlCommand(query, con);
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0

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