using System;
using System.Collections.Generic;

namespace Meteoro.Entities.Entities
{
    public partial class Tblsemana
    {
        public int Consecutiv { get; set; }
        public int Semana { get; set; }
        public int Año { get; set; }
        public DateTime Fechaini { get; set; }
        public DateTime Fechafin { get; set; }
    }
}
