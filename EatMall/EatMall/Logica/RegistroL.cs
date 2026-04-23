using System;
using EatMall.Datos;
using EatMall.Modelo;

namespace EatMall.Logica
{
	public class RegistroL
	{
		// Instancia de la capa de datos
		private RegistroD oRegistroD = new RegistroD();

		public Cliente MtRegistrarCliente(Cliente oCliente)
		{
			try
			{
				// Aquí podrías validar datos antes de enviarlos
				if (string.IsNullOrEmpty(oCliente.Email))
				{
					throw new Exception("El correo electrónico es obligatorio.");
				}

				// Llamamos a la capa de datos
				return oRegistroD.MtRegistrarCliente(oCliente);
			}
			catch (Exception ex)
			{
				// Volvemos a lanzar la excepción para que el Registro.aspx.cs la atrape
				throw ex;
			}
		}
	}
}