using EatMall.Datos;
using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EatMall.Logica
{
    public class CategoriaProductoL
    {
        CategoriaProductoD categoriaD = new CategoriaProductoD();
        public List<CategoriaProducto> ObtenerCategoriasPorLocal(int idLocal)
        {
            return categoriaD.ObtenerCategoriasPorLocal(idLocal);
        }
    }
}