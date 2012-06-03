using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Utilerías.Objetos;
using BLL;

namespace WebSite {
    /// <summary>
    /// Summary description for SocioFotografía
    /// </summary>
    public class SocioFotografía : IHttpHandler {

        public void ProcessRequest(HttpContext ctx) {
            string id = ctx.Request.QueryString["id"];
            BLL.Consultas consulta = new Consultas();
            Utilerías.Objetos.Cliente c = new Utilerías.Objetos.Cliente();
            int idSocio;
            if (int.TryParse(id, out idSocio)) {
                c.NumeroSocio = idSocio;
                DataTable cliente = consulta.ConsultarSocio(c);
                byte[] pict = cliente.Rows[0].Field<byte[]>("fotografia");

                ctx.Response.ContentType = "image/bmp";
                ctx.Response.OutputStream.Write(pict, 0, pict.Length);

            }
        }

        public bool IsReusable {
            get {
                return true;
            }
        }
    }
}