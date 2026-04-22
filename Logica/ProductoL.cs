using EatMall.Datos;
using EatMall.Modelo;
using System;
using System.Collections.Generic;

namespace EatMall.Logica
{
    public class ProductoL
    {
        public List<Producto> ObtenerProductos()
        {
            ProductoD datos = new ProductoD();
            return datos.ObtenerProductos();
        }
    }
}