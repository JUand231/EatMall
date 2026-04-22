
using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EatMall.Datos
{
    public class LoginD
    {
        public Cliente MtLoginC(UsuarioLogin oDatosC)
        {
            Cliente oCliente = null;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SpLoginCliente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", oDatosC.Email);
                    cmd.Parameters.AddWithValue("@Contraseña", oDatosC.Contraseña);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oCliente = new Cliente()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Documento = dr["Documento"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Email = dr["Email"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Contraseña = dr["Contraseña"].ToString(),
                                Estado = dr["Estado"].ToString(),


                            };

                        }
                    }
                }
            }
            return oCliente;
        }
        public List<MetodoPago> ObtenerMetodos()
        {
            List<MetodoPago> lista = new List<MetodoPago>();
            SqlConnection con = ConexionDB.MtAbrirConexion();

            string query = "SELECT Id, NombreMetodo, Estado FROM MetodoPago WHERE Estado = 1";
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