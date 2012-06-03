using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilerías.Objetos {
    /// <summary>
    /// Clase para representar un género/categoría.
    /// Creada por Alonso Vega
    /// Estudiante de Ing. Computacion
    /// Telefono: 85540554
    /// Email: Lavb91@gmail.com
    /// </summary>
    public class Géneros {
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

        /// <summary>
        /// Devuelve un nuevo género.
        /// </summary>
        public Géneros() {
            this.Id = -1;
            this.Nombre = String.Empty;
        }

    }
}
