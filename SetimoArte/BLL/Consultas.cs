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
    /// Acceso para consultar datos
    /// Creada por Kenneth Sancho
    /// Estudiante de Ing. Computacion
    /// Telefono: 87557833
    /// Email: kennethsancho@gmail.com
    /// </summary>

    public class Consultas {

        DAL.Consultas consulta = new DAL.Consultas();

        /// <summary>
        /// Método para la consulta de los géneros de películas
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultarGénero() {
            try { return this.consulta.ConsultarGéneros();} 
           catch (Exception ex) {throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para la consulta de las películas
        /// </summary>
        /// <param name="DatosP"></param>
        /// <returns></returns>
        public DataTable ConsultarPelícula(Película DatosP)
        {
            try { return this.consulta.ConsultarPelículas(DatosP); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para la consulta de los socios en el sistema
        /// </summary>
        /// <param name="DatosC"></param>
        /// <returns></returns>
        public DataTable ConsultarSocio(Cliente DatosC)
        {
            try { return this.consulta.ConsultarSocios(DatosC); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar los alquileres qu se dieron en fechas determinadas
        /// </summary>
        /// <param name="DatosA"></param>
        /// <param name="codSocio"></param>
        /// <returns></returns>
        public DataTable ConsultarAlquilerFecha(Alquiler DatosA, int codSocio)
        {
            try { return this.consulta.ConsultarAlquileresFechas(DatosA, codSocio); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar las ventas que se hicieron en cierta fecha
        /// </summary>
        /// <param name="fechaIni"></param>
        /// <param name="FechaFin"></param>
        /// <param name="CodSocio"></param>
        /// <returns></returns>
        public DataTable ConsultarVentaFecha(DateTime fechaIni, DateTime FechaFin, int CodSocio )
        {
            try { return this.consulta.ConsultarVentasFechas(fechaIni,FechaFin,CodSocio); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar los plazos de los alquileres
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultarPlazo()
        {
            try { return this.consulta.ConsultarPlazos(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar los precios de alquiler
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultarPrecioAlquiler()
        {
            try { return this.consulta.ConsultarPreciosAlquileres(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar los precios de las ventas
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultarPrecioVenta()
        {
            try { return this.consulta.ConsultarPreciosVentas(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar la disponibilidad de las películas elegidas
        /// </summary>
        /// <param name="NPelícula"></param>
        /// <param name="TPelícula"></param>
        /// <returns></returns>
        public DataTable ConsultarDisponible(string NPelícula, string TPelícula)
        {
            try { return this.consulta.ConsultarDisponibles(NPelícula,TPelícula); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar los alquileres que ya pasó la fecha de entrega
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultarAlquileresPendientes() {
            try { return this.consulta.ConsultarAlquileresPendientes(); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar los alquileres que aún estan activos
        /// /// </summary>
        /// <returns></returns>
        public DataTable ConsultarAlquileresActivos () {
            try { return this.consulta.ConsultarAlquileresActivos(); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar los alquileres según el id del alquiler
        /// </summary>
        /// <param name="alquiler"></param>
        /// <returns></returns>
        public DataTable ConsultarAlquileresId(Alquiler alquiler) {
            try { return this.consulta.ConsultarAlquileresId(alquiler); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para consultar las películas que estan asociadas a un alquiler
        /// </summary>
        /// <param name="alquiler"></param>
        /// <returns></returns>
        public DataTable ConsultarAlquileresPelículas(Alquiler alquiler) {
            try { return this.consulta.ConsultarAlquileresPelículas(alquiler); } catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
