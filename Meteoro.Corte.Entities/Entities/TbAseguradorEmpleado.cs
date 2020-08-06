using System;
using System.Collections.Generic;

namespace Meteoro.Corte.Entities.Entities
{
    public partial class TbAseguradorEmpleado
    {
        public int Id { get; set; }
        public string Asegurador { get; set; }
        public string Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public int Revisiones { get; set; }
        public bool Sync { get; set; }
    }
}
