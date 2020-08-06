using System;
using System.Collections.Generic;

namespace Meteoro.Corte.Entities.Entities
{
    public partial class TbEmpresa
    {
        public TbEmpresa()
        {
            TbEmpleado = new HashSet<TbEmpleado>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TbEmpleado> TbEmpleado { get; set; }
    }
}
