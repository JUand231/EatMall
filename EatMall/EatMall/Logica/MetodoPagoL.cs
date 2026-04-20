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
        private LoginD datos = new LoginD();

        public List<MetodoPago> ObtenerMetodos()
        {
            return datos.ObtenerMetodos();
        }

    }
}