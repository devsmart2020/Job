using System;
using System.Collections.Generic;

namespace Meteoro.Entities.Entities
{
    public partial class Tbladmin
    {
        public int Codigo { get; set; }
        public string VersionAnterior { get; set; }
        public string VersionActual { get; set; }
        public string NovedadUpdate { get; set; }
        public DateTime FechaUpdate { get; set; }
    }
}
