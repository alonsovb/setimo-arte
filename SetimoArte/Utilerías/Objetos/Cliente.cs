using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilerías.Objetos {
    /// <summary>
    /// Clase que representa a un cliente
    /// Creada por Alonso Vega
    /// Estudiante de Ing. Computacion
    /// Telefono: 85540554
    /// Email: Lavb91@gmail.com
    /// </summary>
    public class Cliente {
        private int _numeroSocio;

        public int NumeroSocio {
            get { return _numeroSocio; }
            set { _numeroSocio = value; }
        }

        private string _nombre;

        public string Nombre {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _apellidos;

        public string Apellidos {
            get { return _apellidos; }
            set { _apellidos = value; }
        }
        private byte[] _fotografía;

        public byte[] Fotografía {
            get { return _fotografía; }
            set { _fotografía = value; }
        }

        private int _teléfono;

        public int Teléfono {
            get { return _teléfono; }
            set { _teléfono = value; }
        }
        private string _email;

        public string Email {
            get { return _email; }
            set { _email = value; }
        }
        private string _dirección;

        public string Dirección {
            get { return _dirección; }
            set { _dirección = value; }
        }
        private DateTime _afiliación;

        public DateTime Afiliación {
            get { return _afiliación; }
            set { _afiliación = value; }
        }
        private int _estado;

        public int Estado {
            get { return _estado; }
            set { _estado = value; }
        }

        /// <summary>
        /// Devuelve un cliente nuevo.
        /// </summary>
        public Cliente() {
            this.NumeroSocio = -1;
            this.Nombre = String.Empty;
            this.Apellidos = String.Empty;
            this.Fotografía = null;
            this.Teléfono = -1;
            this.Email = String.Empty;
            this.Dirección = String.Empty;
            this.Afiliación = DateTime.Now;
            this.Estado = 0;
        }

    }
}
