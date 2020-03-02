// Template: Controller Interface (ApiControllerInterface.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using practica2_mtis.Utilidades.Models;


namespace practica2_mtis.Utilidades
{
    public interface IUtilidadesController
    {

        IHttpActionResult Get([FromUri] string dni,[FromUri] string restkey);
        IHttpActionResult GetValidarNAFSS([FromUri] string dni,[FromUri] string restkey);
        IHttpActionResult GetValidarIBAN([FromUri] string dni,[FromUri] string restkey);
    }
}
