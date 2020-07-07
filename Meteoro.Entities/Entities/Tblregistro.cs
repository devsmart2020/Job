using System;
using System.Collections.Generic;

namespace Meteoro.Entities.Entities
{
    public partial class Tblregistro
    {
        public int Consecutivo { get; set; }
        public string Empleado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaDesconexion { get; set; }
    }
}
