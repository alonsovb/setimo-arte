using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilerías.Objetos {
    /// <summary>
    /// Clase que representa el plazo de alquiler.
    /// Creada por Alonso Vega
    /// Estudiante de Ing. Computacion
    /// Telefono: 85540554
    /// Email: Lavb91@gmail.com
    /// </summary>
    public class Plazos {
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

        private int _días;

        public int Días {
            get { return _días; }
            set { _días = value; }
        }

        /// <summary>
        /// Devuelve un nuevo plazo
        /// </summary>
        public Plazos() {
            this.Id = -1;
            this.Tipo = String.Empty;
            this.Días = 0;
        }
        
    }
}
