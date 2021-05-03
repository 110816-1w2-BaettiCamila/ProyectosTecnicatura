using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneHengue.Models
{
    public class Alumno
    {
        private int legajo;
        private string nombre;
        private string apellido;
        private bool hermanos;
        private bool estado;

        public int pLegajo
        {
            set { legajo = value; }
            get { return legajo; }
        }
        public string pNombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
        public string pApellido
        {
            set { apellido = value; }
            get { return apellido; }
        }
        public bool pHermanos
        {
            set { hermanos = value; }
            get { return hermanos; }
        }
        public bool pEstado
        {
            set { estado = value; }
            get { return estado; }
        }

    }
}