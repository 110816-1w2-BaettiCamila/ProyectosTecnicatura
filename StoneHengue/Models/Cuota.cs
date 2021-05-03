using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoneHengue.Models
{
    public class Cuota
    {
        private int idCuota;
        private int nro;
        private DateTime fechaPago;
        private float monto;
        private bool estado;
        private int idAlumno;

        public int pIdCuota
        {
            set { idCuota = value; }
            get { return idCuota; }
        }

        public int pNro
        {
            set { nro = value; }
            get { return nro; }
        }
        public DateTime pFechaPago
        {
            set { fechaPago = value; }
            get { return fechaPago; }
        }
        public float pMonto
        {
            set { monto = value; }
            get { return monto; }
        }
        public bool pEstado
        {
            set { estado = value; }
            get { return estado; }
        }
        public int pidAlumno
        {
            set { idAlumno = value; }
            get { return idAlumno; }
        }
    }
}
