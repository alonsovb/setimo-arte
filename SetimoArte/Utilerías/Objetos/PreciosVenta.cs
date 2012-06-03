using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilerías.Objetos {
    /// <summary>
    /// Representa el precio de venta
    /// Creada por Alonso Vega
    /// Estudiante de Ing. Computacion
    /// Telefono: 85540554
    /// Email: Lavb91@gmail.com
    /// </summary>
    public class PreciosVenta {
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
        private int _precio;

        public int Precio {
            get { return _precio; }
            set { _precio = value; }
        }

        public PreciosVenta() {
            this.Id = -1;
            this.Tipo = String.Empty;
            this.Precio = 0;
        }
    }
}
