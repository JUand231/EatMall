using EatMall.Datos;
using EatMall.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EatMall.Logica
{
    public class MetodoPagoL
    {
<<<<<<< HEAD
        public List<MetodoPago> ObtenerMetodos(int idLocal)
        {
            MetodoPagoD datos = new MetodoPagoD();
            return datos.ObtenerMetodos(idLocal);
        }
=======
        private LoginD datos = new LoginD();

        public List<MetodoPago> ObtenerMetodos()
        {
            return datos.ObtenerMetodos();
        }

>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
    }
}