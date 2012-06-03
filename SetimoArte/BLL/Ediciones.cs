using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using Utilerías.Objetos;

namespace BLL {
    /// <summary>
    /// Acceso para la edición de los datos
    /// Creada por Kenneth Sancho
    /// Estudiante de Ing. Computacion
    /// Telefono: 87557833
    /// Email: kennethsancho@gmail.com
    /// </summary>
   public class Ediciones {
       /// <summary>
       /// Instancia para acceder a los métodos de la capa de datos
       /// </summary>
        DAL.Ediciones insEdicionesDAL = new DAL.Ediciones();

       /// <summary>
       /// método para editar los plazos de los alquileres.
       /// </summary>
       /// <param name="ind"></param>
       /// <param name="dobTrip"></param>
       /// <param name="mult"></param>
        public void EditarPlazo(int ind, int dobTrip, int mult)
        {
            try { this.insEdicionesDAL.EditarPlazos(ind,dobTrip,mult); } 
           catch (Exception ex) {throw new Exception(ex.Message); }
        }

       /// <summary>
       /// Método para editar los precios de las ventas según sea socio o particular
       /// </summary>
       /// <param name="pSocio"></param>
       /// <param name="pParticular"></param>
        public void EditarPrecioVenta(int pSocio, int pParticular)
        {
            try { this.insEdicionesDAL.EditarPreciosVentas(pSocio, pParticular); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

       /// <summary>
       /// Metodo para editar los precios de los alquileres
       /// </summary>
       /// <param name="precios"></param>
        public void EditarPrecioAlquiler(DataTable precios)
        {
            try { this.insEdicionesDAL.EditarPreciosAlquileres(precios); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

       /// <summary>
       /// Método para cancelar los alquileres editando su dato
       /// </summary>
       /// <param name="alquiler"></param>
        public void DevolverAlquiler(Alquiler alquiler) {
            try { this.insEdicionesDAL.DevolverAlquiler(alquiler); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
