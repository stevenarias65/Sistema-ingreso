using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ingreso_de_Vehiculos.Models.Clases
{
    public class VisitanteMostrar
    {
        public int id_visitante { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public Nullable<System.DateTime> fecha_ingreso { get; set; }
        public string placa { get; set; }
        public string departamento { get; set; }

    }
}