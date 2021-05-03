using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoBAETTI.Models
{
    public class Vuelo
    {
        private int idVuelo;
        [Required]
        private String observaciones;
        [Required]
        private int idDestino;
        [Required]
        private int idTipoCarga;
        [Required]
        private DateTime fecha;
        [Required]
        private int tipo;

        public int pIdVuelo {
            set { idVuelo = value; }
            get { return idVuelo; }

        }
        public int pidDestino
        {
            set { idDestino = value; }
            get { return idDestino; }

        }
        public int pidTipoCarga
        {
            set { idTipoCarga = value; }
            get { return idTipoCarga; }

        }
        public int ptipo
        {
            set { tipo = value; }
            get { return tipo; }

        }
        public String pobservaciones
        {
            set { observaciones = value; }
            get { return observaciones; }

        }
        public DateTime pfecha
        {
            set { fecha = value; }
            get { return fecha; }

        }
    }
}