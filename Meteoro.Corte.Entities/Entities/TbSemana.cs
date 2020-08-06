using System;
using System.Collections.Generic;

namespace Meteoro.Corte.Entities.Entities
{
    public partial class TbSemana
    {
        public int Id { get; set; }
        public int Semana { get; set; }
        public int Año { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
