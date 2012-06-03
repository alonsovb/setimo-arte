using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilerías.Objetos {

    /// <summary>
    /// Representa el precio de alquiler
    /// Creada por Alonso Vega
    /// Estudiante de Ing. Computacion
    /// Telefono: 85540554
    /// Email: Lavb91@gmail.com
    /// </summary>
    public class PreciosAlquiler {
        private int _id;

        public int Id {
            get { return _id; }
            set { _id = value; }
        }
        private string _tipo;

        public string Tipo {
            get { return _tipo; }
            set { _tipo = value; }
        }
        private int _precioDVD;

        public int PrecioDVD {
            get { return _precioDVD; }
            set { _precioDVD = value; }
        }
        private int _precioBlueRay;

        public int PrecioBlueRay {
            get { return _precioBlueRay; }
            set { _precioBlueRay = value; }
        }
        private int _precioHD;

        public int PrecioHD {
            get { return _precioHD; }
            set { _precioHD = value; }
        }

        /// <summary>
        /// Devuelve un nuevo precio de alquiler
        /// </summary>
        public PreciosAlquiler() {
            this.Id = -1;
            this.Tipo = String.Empty;
            this.PrecioDVD = 0;
            this.PrecioBlueRay = 0;
            this.PrecioHD = 0;
        }

    }
}
