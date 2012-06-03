using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Utilerías;
using Utilerías.Objetos;

namespace BLL {
    /// <summary>
    /// Acceso para registrar datos
    /// Creada por Kenneth Sancho
    /// Estudiante de Ing. Computacion
    /// Telefono: 87557833
    /// Email: kennethsancho@gmail.com
    /// </summary>
    public class Registros {
        /// <summary>
        /// Instancias para acceder a los métodos en la lógica de datos
        /// </summary>
        DAL.Registros Registro = new DAL.Registros();
        DAL.Consultas Consulta = new DAL.Consultas();

        /// <summary>
        /// Método en la lógica de negocio para registrar los socios
        /// </summary>
        /// <param name="DatosC"></param>
        public void RegistrarSocio(Cliente DatosC) {
            try { this.Registro.RegistrarSocios(DatosC); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para registrar la película, y asignar el género al que se asocia una película
        /// </summary>
        /// <param name="DatosG"></param>
        /// <param name="DatosP"></param>
        public void RegistrarGéneroPelícula(Géneros DatosG, Película DatosP) {
            try {
                int id_genero;
                DataTable genero;
                genero = Consulta.ConsultarGénerosNombre(DatosG);

                if(genero.Rows.Count != 0)
                    id_genero = Convert.ToInt32(genero.Rows[0]["id_generos"].ToString());
                else
                    id_genero = this.Registro.RegistrarGéneros(DatosG);

                DatosP.Género = id_genero;
                this.Registro.RegistrarPelículas(DatosP);
            } 
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para registrar los géneros de las películas
        /// </summary>
        /// <param name="DatosG"></param>
        public void RegistrarGénero(Géneros DatosG) {
            try
            {
                DataTable genero;
                genero = Consulta.ConsultarGénerosNombre(DatosG);

                if (genero.Rows.Count == 0)
                    this.Registro.RegistrarGéneros(DatosG);
            }
            catch (Exception ex) { throw new Exception(ex.Message); } 
        }

        /// <summary>
        /// Método para registrar los alquileres y las películas que se asignan a este.
        /// </summary>
        /// <param name="DatosA"></param>
        /// <param name="pelisAlquiladas"></param>
        public void RegistrarAlquiler(Alquiler DatosA, DataTable pelisAlquiladas)
        {
            try { this.Registro.RegistrarAlquileres(DatosA, pelisAlquiladas); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para registrar las ventas y las películas que se asignan a esta.
        /// </summary>
        /// <param name="DatosV"></param>
        /// <param name="pelisVendidas"></param>
        public void RegistrarVenta(Venta DatosV, DataTable pelisVendidas)
        {
            try { this.Registro.RegistrarVentas(DatosV, pelisVendidas); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
