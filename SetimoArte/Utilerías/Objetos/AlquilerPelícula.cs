using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilerías.Objetos {

    /// <summary>
    /// Representa el alquiler de una película
    /// Creada por Alonso Vega
    /// Estudiante de Ing. Computacion
    /// Telefono: 85540554
    /// Email: Lavb91@gmail.com
    /// </summary>
    public class AlquilerPelícula {
        private int _alquiler;

        public int Alquiler {
            get { return _alquiler; }
            set { _alquiler = value; }
        }
        private int _película;

        public int Película {
            get { return _película; }
            set { _película = value; }
        }
        private int _totalDVD;

        public int TotalDVD {
            get { return _totalDVD; }
            set { _totalDVD = value; }
        }
        private int _totalBlueRay;

        public int TotalBlueRay {
            get { return _totalBlueRay; }
            set { _totalBlueRay = value; }
        }
        private int _totalHD;

        public int TotalHD {
            get { return _totalHD; }
            set { _totalHD = value; }
        }

        /// <summary>
        /// Devuelve en nuevo alquiler de una película
        /// </summary>
        public AlquilerPelícula() {
            this.Alquiler = -1;
            this.Película = -1;
            this.TotalDVD = 0;
            this.TotalBlueRay = 0;
            this.TotalHD = 0;
        }
    }
}
