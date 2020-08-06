using System;
using System.Collections.Generic;

namespace Meteoro.Corte.Entities.Entities
{
    public partial class TbCategoria
    {
        public TbCategoria()
        {
            TbCorte = new HashSet<TbCorte>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TbCorte> TbCorte { get; set; }
    }
}
