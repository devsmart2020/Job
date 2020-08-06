using System;
using System.Collections.Generic;

namespace Meteoro.Corte.Entities.Entities
{
    public partial class TbAdmin
    {
        public int Id { get; set; }
        public string VersionAnt { get; set; }
        public string VersionAct { get; set; }
        public string Novedad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
