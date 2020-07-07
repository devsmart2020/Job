using System;
using System.Collections.Generic;

namespace Meteoro.Entities.Entities
{
    public partial class Tblempresa
    {
        public Tblempresa()
        {
            Tblcosecha = new HashSet<Tblcosecha>();
            Tblempleado = new HashSet<Tblempleado>();
        }

        public int Codigo { get; set; }
        public string CodEmpresa { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tblcosecha> Tblcosecha { get; set; }
        public virtual ICollection<Tblempleado> Tblempleado { get; set; }
    }
}
