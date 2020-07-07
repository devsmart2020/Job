using System;
using System.Collections.Generic;

namespace Meteoro.Entities.Entities
{
    public partial class Tblaseguradorempleado
    {
        public int Codigo { get; set; }
        public string Asegurador { get; set; }
        public string Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public int Revisiones { get; set; }
        public bool Sync { get; set; }
    }
}
