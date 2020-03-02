// Template: Controller Implementation (ApiControllerImplementation.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using practica2_mtis.Empleado.Models;
using practica2_mtis.Models;
using practica2_mtis.Seguridad.Models;

namespace practica2_mtis.Empleado
{
   
    public partial class EmpleadoController : IEmpleadoController
    {
        private db db;
        /// <summary>
        /// Crea nuevo empleado - /Empleado/nuevo
        /// </summary>
        /// <param name="empleado"></param>
        /// <param name="restkey"></param>
        /// <returns>MultipleEmpleadoNuevoPost</returns>
        public IHttpActionResult Post([FromBody] practica2_mtis.Empleado.Models.Empleado empleado,[FromUri] string restkey)
        {
            // TODO: implement Post - route: Empleado/nuevo
            var result = new MultipleEmpleadoNuevoPost()
            {
                Error = new Error()
            };
            result.Ipbool = false;

            db = new db();

            if (!db.ComprobarApiKey(restkey))
            {
                result.Ipbool = false;
                result.Error.Mensaje = "RestKey no coincide.";
                result.Error.Codigo = 401;
                return Ok(result);
            }

            try
            {
                db.CrearEmpleado(empleado.DNI, empleado.Nombre, empleado.Apellidos, empleado.Direccion, empleado.Poblacion, empleado.Telefono, empleado.Email, empleado.Fecha_nacimiento, empleado.NSS, empleado.IBAN);
                result.Ipbool = true;
            } catch (Exception ex)
            {
                result.Error.Mensaje = "Fallo en la consulta a la base de datos.";
                result.Error.Codigo = 400;
                result.Ipbool = false;
            }
			return Ok(result);
        }

/// <summary>
		/// Borrar empleado - /Empleado/borrar
		/// </summary>
		/// <param name="content"></param>
		/// <param name="restkey"></param>
		/// <param name="dni"></param>
		/// <returns>MultipleEmpleadoBorrarPost</returns>
        public IHttpActionResult PostBorrar([FromBody] string content,[FromUri] string restkey,[FromUri] string dni)
        {
            // TODO: implement PostBorrar - route: Empleado/borrar
            var result = new MultipleEmpleadoNuevoPost()
            {
                Error = new Error()
            };
            result.Ipbool = false;

            db = new db();

            if (!db.ComprobarApiKey(restkey))
            {
                result.Ipbool = false;
                result.Error.Mensaje = "Error: RestKey no coincide.";
                result.Error.Codigo = 401;
                return Ok(result);
            }

            try
            {
                db.BorrarEmpleado(dni);
                result.Ipbool = true;
            }
            catch (Exception ex)
            {
                result.Error.Codigo = 400;
                result.Error.Mensaje = "Error: Fallo en la consulta a la base de datos.";
                result.Ipbool = false;
            }
            return Ok(result);
        }

/// <summary>
		/// Modificar empleado - /Empleado/modificar
		/// </summary>
		/// <param name="empleado"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleEmpleadoModificarPut</returns>
        public IHttpActionResult Put([FromBody] practica2_mtis.Empleado.Models.Empleado empleado,[FromUri] string restkey)
        {
            // TODO: implement Put - route: Empleado/modificar
            // var result = new MultipleEmpleadoModificarPut();
            // return Ok(result);
            //return Ok();

            var result = new MultipleEmpleadoModificarPut()
            {
                Error = new Error()
            };
            result.Ipbool = false;

            db = new db();

            if (!db.ComprobarApiKey(restkey))
            {
                result.Ipbool = false;
                result.Error.Mensaje = "Error: RestKey no coincide.";
                result.Error.Codigo = 401;
                return Ok(result);
            }

            try
            {
                db.ModificarEmpleado(empleado.DNI, empleado.Nombre, empleado.Apellidos, empleado.Direccion, empleado.Poblacion, empleado.Telefono, empleado.Email, empleado.Fecha_nacimiento, empleado.NSS, empleado.IBAN);
                result.Ipbool = true;
            }
            catch (Exception ex)
            {
                result.Error.Mensaje = "Error: Fallo en la consulta a la base de datos.";
                result.Error.Codigo = 400;
                result.Ipbool = false;
            }
            return Ok(result);
        }

/// <summary>
		/// Consultar empleado - /Empleado/consultar
		/// </summary>
		/// <param name="restkey"></param>
		/// <param name="dni"></param>
		/// <returns>MultipleEmpleadoConsultarGet</returns>
        public IHttpActionResult Get([FromUri] string restkey,[FromUri] string dni)
        {
            // TODO: implement Get - route: Empleado/consultar
            // var result = new MultipleEmpleadoConsultarGet();
            var result = new MultipleEmpleadoConsultarGet()
            {
                Error = new Error()
            };
          
            db = new db();

            if (!db.ComprobarApiKey(restkey))
            {
                result.Error.Mensaje = "Error: RestKey no coincide.";
                result.Error.Codigo = 401;
                return Ok(result);
            }

            try {
                Empleado.Models.Empleado empleado = db.ConsultarEmpleado(dni);

                if (empleado != null)
                    result.Empleado = empleado;
                else
                {
                    result.Error.Codigo = 404;
                    result.Error.Mensaje = "No existe DNI.";
                }
               
            } catch (Exception ex) {
                result.Error.Codigo = 400;
                result.Error.Mensaje = "Error: Fallo en la consulta a la base de datos.";
            }

            return Ok(result);
        }

    }
}
