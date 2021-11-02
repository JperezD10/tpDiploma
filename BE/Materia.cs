using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Materia
    {
        public int ID_Materia { get; set; }
        public int Anio { get; set; }
        public string Descripcion { get; set; }
        public string Dia { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }

        public Materia(int anio, string descripcion, string dia, int horainicio, int horaFin = 0)
        {
            this.Anio = anio;
            this.Descripcion = descripcion;
            this.Dia = dia;
            this.HoraInicio = horainicio;
            this.HoraFin = horaFin == 0 ? horainicio + 2 : horaFin; 
        }
    }
}
