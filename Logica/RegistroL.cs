using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EatMall.Modelo;
using EatMall.Datos;

namespace EatMall.Logica
{
    public class RegistroL
    {
        public Cliente MtRegistrarCliente(Cliente oCliente)
        {
            RegistroD oRegistroD = new RegistroD();
            bool resultado = oRegistroD.MtRegistrarCliente(oCliente);
            if (resultado)
            {
                return oCliente;
            }
            else
            {
                return null;
            }
		}
	}
}