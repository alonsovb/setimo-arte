using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilerías.Objetos {
    /// <summary>
    /// Clase para representar una película;
    /// Creada por Alonso Vega
    /// Estudiante de Ing. Computacion
    /// Telefono: 85540554
    /// Email: Lavb91@gmail.com
    /// </summary>
    public class Película {
        private int _id;

        public int Id {
            get { return _id; }
            set { _id = value; }
        }

        private string _nombre;

        public string Nombre {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private int _género;

        public int Género {
            get { return _género; }
            set { _género = value; }
        }
        private int _invDVD;

        public int InvDVD {
            get { return _invDVD; }
            set { _invDVD = value; }
        }
        private int _invBlueRay;

        public int InvBlueRay {
            get { return _invBlueRay; }
            set { _invBlueRay = value; }
        }
        private int _invHD;

        public int InvHD {
            get { return _invHD; }
            set { _invHD = value; }
        }

        /// <summary>
        /// Devuelve una nueva película.
        /// </summary>
        public Película() {
            this.Id = -1;
            this.Nombre = String.Empty;
            this.Género = -1;
            this.InvDVD = 0;
            this.InvBlueRay = 0;
            this.InvHD = 0;
        }
    }
}
