using EatMall.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EatMall.Modelo;

namespace EatMall.Logica
{
    public class LoginL
    {
        public Cliente MtLoginC(UsuarioLogin oDatos)
        {
            LoginD oLoginD = new LoginD();
            Cliente oDatosUser = oLoginD.MtLoginC(oDatos);
            return oDatosUser;
        }
    
        
    }
}