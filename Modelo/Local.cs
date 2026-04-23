using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EatMall.Modelo
{
    public class Local
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Imagen { get; set; }
        public string Estado { get; set; }
        public Plazoleta Plazoleta { get; set; }
<<<<<<< HEAD
        public CentroComercial CentroComercial { get; set; }
=======
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
    }
}