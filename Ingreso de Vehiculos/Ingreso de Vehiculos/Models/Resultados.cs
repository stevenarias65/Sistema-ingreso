using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ingreso_de_Vehiculos.Models
{
    public class eResultado
    {
        public String Mensaje { get; set; } = String.Empty;
        public Int32 TipoMensaje { get; set; } = 1; //1 = exito, 2 = Alerta, 3 = Error
        public Boolean Estado { get; set; } = true;
        public Object Valor { get; set; }
    }
}