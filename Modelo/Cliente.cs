using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EatMall.Modelo
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
<<<<<<< HEAD
        public bool Estado { get; set; }
=======
        public string Estado { get; set; }
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
    }
}