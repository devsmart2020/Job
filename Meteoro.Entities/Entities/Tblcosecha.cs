using System;
using System.Collections.Generic;

namespace Meteoro.Entities.Entities
{ 
    public partial class Tblcosecha
    {
        public int Id { get; set; }
        public string Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public int Semana { get; set; }
        public int Año { get; set; }
        public string Asegurador { get; set; }
        public int Modalidad { get; set; }
        public int Cortos { get; set; }
        public int Largos { get; set; }
        public int HBajeras { get; set; }
        public int Conteo { get; set; }
        public bool Empaque { get; set; }
        public bool Tocon { get; set; }
        public bool Hojas { get; set; }
        public bool Cubiertos { get; set; }
        public bool Poda { get; set; }
        public bool Maximo { get; set; }
        public bool Podado { get; set; }
        public int Revision { get; set; }
        public string Empresa { get; set; }

        public virtual Tblempleado EmpleadoNavigation { get; set; }
        public virtual Tblempresa EmpresaNavigation { get; set; }
        public virtual Tblmodalidad ModalidadNavigation { get; set; }
    }
}
