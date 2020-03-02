// Template: Controller Interface (ApiControllerInterface.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using practica2_mtis.Empleado.Models;


namespace practica2_mtis.Empleado
{
    public interface IEmpleadoController
    {

        IHttpActionResult Post([FromBody] practica2_mtis.Empleado.Models.Empleado empleado,[FromUri] string restkey);
        IHttpActionResult PostBorrar([FromBody] string content,[FromUri] string restkey,[FromUri] string dni);
        IHttpActionResult Put([FromBody] practica2_mtis.Empleado.Models.Empleado empleado,[FromUri] string restkey);
        IHttpActionResult Get([FromUri] string restkey,[FromUri] string dni);
    }
}
