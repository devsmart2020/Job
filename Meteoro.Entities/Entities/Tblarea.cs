using System;
using System.Collections.Generic;

namespace Meteoro.Entities.Entities
{
    public partial class Tblarea
    {
        public Tblarea()
        {
            Tblempleado = new HashSet<Tblempleado>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tblempleado> Tblempleado { get; set; }
    }
}
