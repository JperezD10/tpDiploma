using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using SEGURIDAD;
using DAL;

namespace BLL
{
    public class ProfesorBLL
    {
        ProfesorDAL mapper;
        BitacoraBLL servicioBitacora;
        Encriptacion encriptacion;
        Usuario_Sesion session_User = Usuario_Sesion.Instance;
        public ProfesorBLL()
        {
            mapper = new ProfesorDAL();
            servicioBitacora = new BitacoraBLL();
            encriptacion = new Encriptacion();
        }
        public void AgregarProfesor(Profesor profe)
        {
            int lastID = mapper.AgregarProfesor(profe);
            MateriaDAL MateriaMapper = new MateriaDAL();
            MateriaMapper.AsignarProfesorAMateria(profe.GetMaterias(), lastID);
            Bitacora b = new Bitacora
            {
                Accion = "Profesor agregado",
                Criticidad = "Media",
                Descripcion = encriptacion.encriptar($"El profesor {profe.Nombre} ha sido asignado ingresado en el sistema con {profe.GetMaterias().Count} materias"),
                Usuario = encriptacion.encriptar(session_User.Username)
            };
            servicioBitacora.crearBitacora(b);
        }
    }
}
