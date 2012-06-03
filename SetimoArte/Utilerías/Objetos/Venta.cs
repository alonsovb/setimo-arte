using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilerías.Objetos {
    /// <summary>
    /// Representa una venta
    /// Creada por Alonso Vega
    /// Estudiante de Ing. Computacion
    /// Telefono: 85540554
    /// Email: Lavb91@gmail.com
    /// </summary>
    public class Venta {
        private int _id;

        public int Id {
            get { return _id; }
            set { _id = value; }
        }
        private int _cliente;

        public int Cliente {
            get { return _cliente; }
            set { _cliente = value; }
        }
        private DateTime _fecha;

        public DateTime Fecha {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private int _costo;

        public int Costo {
            get { return _costo; }
            set { _costo = value; }
        }

        /// <summary>
        /// Devuelve una nueva venta
        /// </summary>
        public Venta() {
            this.Id = -1;
            this.Cliente = -1;
            this.Fecha = DateTime.Now;
            this.Costo = 0;
        }
    }
}
