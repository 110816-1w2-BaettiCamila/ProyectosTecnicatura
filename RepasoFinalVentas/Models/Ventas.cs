using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepasoFinalVentas.Models
{
    public class Ventas
    {
        private int id;
        private String NombreCliente;
        private int idFormaPago;
        private int idPlanesCuotas;
        private float importe;

        public int pId
        {
            set { id = value; }
            get { return id; }
        }
        public String pNombreCliente
        {
            set { NombreCliente= value; }
            get { return NombreCliente; }
        }
        public int pIdFormaPago
        {
            set { idFormaPago = value; }
            get { return idFormaPago; }
        }
        public int pIdPlanesCuotas
        {
            set { idPlanesCuotas = value; }
            get { return idPlanesCuotas; }
        }
        public float pImporte
        {
            set { value = importe; }
            get { return importe; }
        }

    }
}