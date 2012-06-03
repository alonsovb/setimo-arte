using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilerías.Objetos {
    /// <summary>
    /// Representa un alquiler
    /// Creada por Alonso Vega
    /// Estudiante de Ing. Computacion
    /// Telefono: 85540554
    /// Email: Lavb91@gmail.com
    /// </summary>
    public class Alquiler {
        private int _id;

        public int Id {
            get { return _id; }
            set { _id = value; }
        }
        private int _socio;

        public int Socio {
            get { return _socio; }
            set { _socio = value; }
        }
        private DateTime _fecha;

        public DateTime Fecha {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private DateTime _entrega;

        public DateTime Entrega {
            get { return _entrega; }
            set { _entrega = value; }
        }
        private int _costo;

        public int Costo {
            get { return _costo; }
            set { _costo = value; }
        }
        private int _plazo;

        public int Plazo {
            get { return _plazo; }
            set { _plazo = value; }
        }
        private bool _devuelto;

        public bool Devuelto {
            get { return _devuelto; }
            set { _devuelto = value; }
        }

        /// <summary>
        /// Devuelve un nuevo alquiler
        /// </summary>
        public Alquiler() {
            this.Id = -1;
            this.Socio = -1;
            this.Fecha = DateTime.Now;
            this.Plazo = 0;
            this.Entrega = DateTime.Now;
            this.Costo = 0;
            this.Devuelto = false;
        }
    }
}
