using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Curso
    {
        public int ID_Curso { get; set; }
        public int AnioFecha { get; set; }
        public int AnioSecundaria { get; set; }
        public int Cupo { get; set; }
        public string Turno { get; set; }

        List<Alumno> Alumnos;
        List<Materia> Materias;

        public Curso(int anioFecha, int anioSecundaria, int cupo, string turno)
        {
            this.AnioFecha = anioFecha;
            this.AnioSecundaria = anioSecundaria;
            this.Cupo = cupo;
            this.Turno = turno;
        }

        public void SetAlumnos(List<Alumno> alumnos) => this.Alumnos = alumnos;
        public void SetMaterias(List<Materia> materias) => this.Materias = materias;


    }
}
