using EatMall.Datos;
using EatMall.Modelo;
<<<<<<< HEAD
=======
using System;
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
using System.Collections.Generic;

namespace EatMall.Logica
{
    public class ProductoL
    {
<<<<<<< HEAD
        public List<Producto> ObtenerProductos(int idLocal)
        {
            ProductoD datos = new ProductoD();
            return datos.ObtenerProductos(idLocal);
=======
        public List<Producto> ObtenerProductos()
        {
            ProductoD datos = new ProductoD();
            return datos.ObtenerProductos();
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
        }
    }
}