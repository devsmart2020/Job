using System;
using System.Collections.Generic;

namespace Meteoro.Corte.Entities.Entities
{
    public partial class TbArea
    {
        public TbArea()
        {
            TbEmpleado = new HashSet<TbEmpleado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TbEmpleado> TbEmpleado { get; set; }
    }
}
