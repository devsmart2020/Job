using System;

namespace Meteoro.Corte.Entities.Helpers
{
    public class AseguradorEmpleadoListado
    {       
        public string Asegurador { get; set; }
        public string Colaborador { get; set; }
        public DateTime Fecha { get; set; }
        public int Revisiones { get; set; }
        public int Area { get; set; }
    }
}
