﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
       public int IDUsuario {get;set;}
       public string Nombre {get;set;}
       public string Apellido {get;set;}
       public string DNI {get;set;}
       public string Username {get;set;}
       public string Contraseña {get;set;}
       public string Email {get;set;}
       public DateTime FechaNacimiento {get;set;}
       public string IntentosIngreso {get;set;}
       public string Estado {get;set;}
       public string Direccion { get; set; }
    }
}
