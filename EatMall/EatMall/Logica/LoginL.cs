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
		public UsuarioLogin MtLogin(UsuarioLogin oDatosSesion, string tipoUsuario)
		{
			LoginD oLoginD = new LoginD();
			return oLoginD.MtLogin(oDatosSesion, tipoUsuario);

		}
	}
}