using System;
using System.Collections.Generic;

namespace Meteoro.Corte.Entities.Entities
{
    public partial class TbEmpleado
    {
        public TbEmpleado()
        {
            TbCorte = new HashSet<TbCorte>();
        }

        public string Codigo { get; set; }
        public string DocId { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }
        public bool Estado { get; set; }
        public bool Periodo { get; set; }
        public int Area { get; set; }
        public string Empresa { get; set; }

        public virtual TbArea AreaNavigation { get; set; }
        public virtual TbEmpresa EmpresaNavigation { get; set; }
        public virtual ICollection<TbCorte> TbCorte { get; set; }
    }
}
