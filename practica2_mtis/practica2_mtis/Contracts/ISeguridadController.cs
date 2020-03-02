// Template: Controller Interface (ApiControllerInterface.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using practica2_mtis.Seguridad.Models;


namespace practica2_mtis.Seguridad
{
    public interface ISeguridadController
    {

        IHttpActionResult Get([FromUri] string dni,[FromUri] string sala,[FromUri] string restkey);
        IHttpActionResult GetObtenerNiveles([FromUri] string dni,[FromUri] string restkey);
        IHttpActionResult Post([FromBody] string content,[FromUri] string dni,[FromUri] string sala,[FromUri] string restkey);
        IHttpActionResult PostEliminarPermisos([FromBody] string content,[FromUri] string dni,[FromUri] string sala,[FromUri] string restkey);
    }
}
