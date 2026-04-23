using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EatMall.Modelo
{
    public class CentroComercial
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UbicacionUrl { get; set; }
        public string Imagen { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public int IdCiudad { get; set; }
        public int idAdminCC { get; set; }
        public string Ubicacion { get; set; }
<<<<<<< HEAD
        public string Direccion { get; set; }
=======
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
        public Ciudad Ciudad { get; set; }
    }
}