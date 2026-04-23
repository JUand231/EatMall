using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EatMall.Datos
{
    public class LocalD
    {
        public List<Local> MtListarLocales(int IdPlazoleta)
        {
            List<Local> listaL = new List<Local>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();
             

                string query = @"SELECT l.Id, l.Nombre, l.Descripcion, l.Telefono, 
                        l.Email, l.Imagen, l.Estado, p.Nombre AS NombrePlazoleta,
                        ISNULL((SELECT AVG(CAST(c.Puntaje AS FLOAT)) 
                                FROM dbo.Calificacion c 
                                WHERE c.IdLocal = l.Id), 0) AS Promedio
                 FROM dbo.Local l
                 INNER JOIN dbo.Plazoleta p ON l.IdPlazoleta = p.Id
                 WHERE l.IdPlazoleta = @IdPlazoleta";



                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdPlazoleta", IdPlazoleta);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaL.Add(new Local()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Email = dr["Email"].ToString(),
                                Imagen = dr["Imagen"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                Promedio = Convert.ToDouble(dr["Promedio"]),
                                Plazoleta = new Plazoleta()
                                {
                                    Nombre = dr["NombrePlazoleta"].ToString()
                                }
                            });
                        }
                    }
                }
            }
            return listaL;
        }
    }
}