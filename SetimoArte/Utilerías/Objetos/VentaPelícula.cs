using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilerías.Objetos {
    /// <summary>
    /// Representa la venta de una película
    /// Creada por Alonso Vega
    /// Estudiante de Ing. Computacion
    /// Telefono: 85540554
    /// Email: Lavb91@gmail.com
    /// </summary>
    public class VentaPelícula {
        private int _venta;

        public int Venta {
            get { return _venta; }
            set { _venta = value; }
        }
        private int _película;

        public int Película {
            get { return _película; }
            set { _película = value; }
        }

        /// <summary>
        /// Devuelve una nueva venta de película
        /// </summary>
        public VentaPelícula() {
            this.Venta = -1;
            this.Película = -1;
        }
    }
}
