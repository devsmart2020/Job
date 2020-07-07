using System;
using System.Collections.Generic;

namespace Meteoro.Entities.Entities
{
    public partial class Tblmodalidad
    {
        public Tblmodalidad()
        {
            Tblcosecha = new HashSet<Tblcosecha>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tblcosecha> Tblcosecha { get; set; }
    }
}
