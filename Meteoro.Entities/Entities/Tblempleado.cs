using System;
using System.Collections.Generic;

namespace Meteoro.Entities.Entities
{
    public partial class Tblempleado
    {
        public Tblempleado()
        {
            Tblcosecha = new HashSet<Tblcosecha>();
        }

        public string Codigo { get; set; }
        public string DocId { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }
        public bool Estado { get; set; }
        public bool Periodo { get; set; }
        public int Area { get; set; }
        public string Empresa { get; set; }
 

        public virtual Tblarea AreaNavigation { get; set; }
        public virtual Tblempresa EmpresaNavigation { get; set; }
        public virtual ICollection<Tblcosecha> Tblcosecha { get; set; }
    }
}
