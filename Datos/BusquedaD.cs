using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EatMall.Datos
{
    public class BusquedaD
    {
        public List<Producto> MtBuscarProductos(string busqueda)
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();
                string consulta = @"SELECT Producto.*, CategoriaProducto.Nombre AS Categoria, 
                                    Local.Nombre AS NombreLocal
                                    FROM Producto
                                    INNER JOIN CategoriaProducto ON Producto.IdCategoria = CategoriaProducto.Id
                                    INNER JOIN Local ON Producto.IdLocal = Local.Id
                                    WHERE Producto.Nombre LIKE '%' + @Busqueda + '%'
                                    AND Producto.Estado = 1";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Busqueda", busqueda);

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
        public List<Local> MtBuscarLocales(string busqueda)
        {
            List<Local> lista = new List<Local>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();
                string consulta = @"SELECT 
                                  l.Id,
                                  l.Nombre as Local,
                                  l.Descripcion,
                                  l.Estado,
                                  l.Imagen,
                                  p.Nombre AS Plazoleta,
                                  cc.Nombre AS CentroComercial
                                  FROM Local l
                                  INNER JOIN Plazoleta p ON l.IdPlazoleta = p.Id
                                  INNER JOIN CentroComercial cc ON p.IdCentroComercial = cc.Id
                                  WHERE l.Nombre LIKE '%' + @Busqueda + '%'
                                  AND l.Estado = 'Abierto'";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Busqueda", busqueda);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Local()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Local"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Imagen = dr["Imagen"].ToString(),
                                Plazoleta = new Plazoleta()
                                {
                                    Nombre = dr["Plazoleta"].ToString()
                                },
                                CentroComercial = new CentroComercial()
                                {
                                    Nombre = dr["CentroComercial"].ToString()
                                }

                            });
                        }
                    }
                }
            }
            return lista;
        }
        public List<CentroComercial> MtBuscarCentroComercialPorCiudad(string busqueda)
        {
            List<CentroComercial> lista = new List<CentroComercial>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();
                string consulta = @"SELECT 
                    cc.Id,
                    cc.Nombre,
                    cc.Descripcion,
                    cc.Imagen,
                    cc.Ubicacion,
                    c.NombreCiudad
                    FROM CentroComercial cc
                    INNER JOIN Ciudad c ON cc.IdCiudad = c.Id
                    WHERE c.NombreCiudad LIKE '%' + @Busqueda + '%'"; ;

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Busqueda", busqueda);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new CentroComercial()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Imagen = dr["Imagen"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),   
                                Ciudad = new Ciudad()
                                {
                                    NombreCiudad = dr["NombreCiudad"].ToString() 
                                }
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}