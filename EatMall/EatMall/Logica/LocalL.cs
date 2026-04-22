using EatMall.Datos;
using EatMall.Modelo;
using System.Collections.Generic;

namespace EatMall.Logica
{
    public class LocalL
    {
        public List<Local> MtListarLocales(int IdPlazoleta)
        {
            LocalD oDatosL = new LocalD();
            return oDatosL.MtListarLocales(IdPlazoleta);
        }
    }
}