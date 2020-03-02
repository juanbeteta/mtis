// Template: Controller Implementation (ApiControllerImplementation.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using practica2_mtis.Empleado.Models;
using practica2_mtis.Models;
using practica2_mtis.Seguridad.Models;

namespace practica2_mtis.Seguridad
{
    public partial class SeguridadController : ISeguridadController
    {
        private db db;

        /// <summary>
        /// Validar si el usuario pertenece a una sala pasando el DNI - /Seguridad/validarUsuario
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="sala"></param>
        /// <param name="restkey"></param>
        /// <returns>MultipleSeguridadValidarUsuarioGet</returns>
        public IHttpActionResult Get([FromUri] string dni, [FromUri] string sala, [FromUri] string restkey)
        {
            // TODO: implement Get - route: Seguridad/validarUsuario
            // var result = new MultipleSeguridadValidarUsuarioGet();
            var result = new MultipleSeguridadValidarUsuarioGet()
            {
                Error = new Error()
            };

            db = new db();
            result.Ipbool = false;

            if (!db.ComprobarApiKey(restkey))
            {
                result.Error.Mensaje = "RestKey no coincide.";
                result.Error.Codigo = 401;
                return Ok(result);
            }

            try
            {
                bool existe = db.ValidarSalaUsuario(dni, sala);
                if(existe)
                    result.Ipbool = true;
                else
                {
                    result.Error.Codigo = 404;
                    result.Error.Mensaje = "Validacion fallida.";
                }
            }
            catch (Exception ex)
            {
                result.Error.Codigo = 400;
                result.Error.Mensaje = "Fallo en la consulta a la base de datos.";
            }

            return Ok(result);
        }

/// <summary>
		/// Obtiene todos los niveles que un usuario puede tener - /Seguridad/obtenerNiveles
		/// </summary>
		/// <param name="dni"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleSeguridadObtenerNivelesGet</returns>
        public IHttpActionResult GetObtenerNiveles([FromUri] string dni,[FromUri] string restkey)
        {
            // TODO: implement GetObtenerNiveles - route: Seguridad/obtenerNiveles
            
            var result = new MultipleSeguridadObtenerNivelesGet()
            {
                Error = new Error()
            };

            db = new db();

            if (!db.ComprobarApiKey(restkey))
            {
                result.Error.Mensaje = "RestKey no coincide.";
                result.Error.Codigo = 401;
                return Ok(result);
            }

            try
            {
                List<string> lista = db.ListaNiveles(dni);
                result.Ipstring = lista;
            }
            catch (Exception ex)
            {
                result.Error.Codigo = 400;
                result.Error.Mensaje = "Fallo en la consulta a la base de datos.";
            }

            return Ok(result);
        }

        /// <summary>
        /// Elimina permisos de una sala a un usuario - /Seguridad/asignarPermisos
        /// </summary>
        /// <param name="content"></param>
        /// <param name="dni"></param>
        /// <param name="sala"></param>
        /// <param name="restkey"></param>
        /// <returns>MultipleSeguridadAsignarPermisosPost</returns>
        public IHttpActionResult PostEliminarPermisos([FromBody] string content, [FromUri] string dni, [FromUri] string sala, [FromUri] string restkey)
        {
            var result = new MultipleSeguridadEliminarPermisosPost()
            {
                Error = new Error()
            };

            db = new db();
            result.Ipbool = false;

            if (!db.ComprobarApiKey(restkey))
            {
                result.Error.Mensaje = "RestKey no coincide.";
                result.Error.Codigo = 401;
                return Ok(result);
            }

            try
            {
                db.BorraUsuarioSala(dni, sala);
                result.Ipbool = true;
            }
            catch (Exception ex)
            {
                result.Error.Codigo = 400;
                result.Error.Mensaje = "Fallo en la consulta a la base de datos.";
            }

            return Ok(result);
        }

        /// <summary>
        /// Asigna permisos de una sala a un usuario - /Seguridad/asignarPermisos
        /// </summary>
        /// <param name="content"></param>
        /// <param name="dni"></param>
        /// <param name="sala"></param>
        /// <param name="restkey"></param>
        /// <returns>MultipleSeguridadAsignarPermisosPost</returns>
        public IHttpActionResult Post([FromBody] string content,[FromUri] string dni,[FromUri] string sala,[FromUri] string restkey)
        {
            // TODO: implement Post - route: Seguridad/asignarPermisos
            
            var result = new MultipleSeguridadAsignarPermisosPost()
            {
                Error = new Error()
            };

            db = new db();

            if (!db.ComprobarApiKey(restkey))
            {
                result.Error.Mensaje = "RestKey no coincide.";
                result.Error.Codigo = 401;
                result.Ipbool = false;
                return Ok(result);
            }

            try
            {
                db.AsignarUsuario(dni, sala);
                result.Ipbool = true;
            }
            catch (Exception ex)
            {
                result.Error.Codigo = 400;
                result.Error.Mensaje = "Fallo en la consulta a la base de datos.";
                result.Ipbool = false;
            }

            return Ok(result);
        }

    }
}
