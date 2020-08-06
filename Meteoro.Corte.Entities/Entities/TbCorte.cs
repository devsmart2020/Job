using System;
using System.Collections.Generic;

namespace Meteoro.Corte.Entities.Entities
{
    public partial class TbCorte
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Año { get; set; }
        public int? Semana { get; set; }
        public string Empleado { get; set; }
        public string Asegurador { get; set; }
        public int? Categoria { get; set; }
        public bool? Deshoje { get; set; }
        public bool? DañoMecanico { get; set; }
        public bool? NumTallo { get; set; }
        public bool? Ftallo { get; set; }
        public bool? Cauchos { get; set; }
        public bool? Longitud { get; set; }
        public bool? Base { get; set; }
        public bool? Alineado { get; set; }
        public bool? Follaje { get; set; }
        public bool? Fitosanidad { get; set; }
        public bool? Presentacion { get; set; }
        public bool? Apertura { get; set; }
        public bool? Ramall { get; set; }
        public bool? Mezcla { get; set; }
        public bool? Sync { get; set; }

        public virtual TbCategoria CategoriaNavigation { get; set; }
        public virtual TbEmpleado EmpleadoNavigation { get; set; }
    }
}
