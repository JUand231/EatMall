using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EatMall.Modelo
{
	public class UsuarioLogin
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Contraseña { get; set; }

		// CAMBIO CLAVE: Renombramos 'Rol' a 'IdRol' para que coincida con tu SQL
		public int IdRol { get; set; }

		public string Nombre { get; set; }

		// Esta propiedad es útil si decides pasarla desde la vista
		public int IdRolSolicitado { get; set; }

		public string UrlInicio { get; set; }

		// Opcional: Para guardar el nombre del rol (Admin, Cajero, etc.)
		public string NombreRol { get; set; }
	}
}