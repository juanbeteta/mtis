// Template: Client Proxy T4 Template (RAMLClient.t4) version 7.0

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RAML.Api.Core;
using practica1.Seguridad.Models;

namespace practica1.Seguridad
{
    public partial class Seguridad
    {
        private readonly SeguridadClient proxy;

        internal Seguridad(SeguridadClient proxy)
        {
            this.proxy = proxy;
        }

    }

    public partial class SeguridadValidarUsuario
    {
        private readonly SeguridadClient proxy;

        internal SeguridadValidarUsuario(SeguridadClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Validar si el usuario pertenece a una sala pasando el DNI - /Seguridad/validarUsuario
		/// </summary>
		/// <param name="getseguridadvalidarusuarioquery">query properties</param>
        public virtual async Task<practica1.Seguridad.Models.SeguridadValidarUsuarioGetResponse> Get(practica1.Seguridad.Models.GetSeguridadValidarUsuarioQuery getseguridadvalidarusuarioquery)
        {

            var url = "/Seguridad/validarUsuario";
            if(getseguridadvalidarusuarioquery != null)
            {
                url += "?";
                if(getseguridadvalidarusuarioquery.DNI != null)
					url += "&DNI=" + Uri.EscapeDataString(getseguridadvalidarusuarioquery.DNI);
                if(getseguridadvalidarusuarioquery.Sala != null)
					url += "&Sala=" + Uri.EscapeDataString(getseguridadvalidarusuarioquery.Sala);
                if(getseguridadvalidarusuarioquery.RestKey != null)
					url += "&RestKey=" + Uri.EscapeDataString(getseguridadvalidarusuarioquery.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Get, url.StartsWith("/") ? url.Substring(1) : url);
	        var response = await proxy.Client.SendAsync(req);

            return new practica1.Seguridad.Models.SeguridadValidarUsuarioGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Validar si el usuario pertenece a una sala pasando el DNI - /Seguridad/validarUsuario
		/// </summary>
		/// <param name="request">practica1.Seguridad.Models.SeguridadValidarUsuarioGetRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<practica1.Seguridad.Models.SeguridadValidarUsuarioGetResponse> Get(practica1.Seguridad.Models.SeguridadValidarUsuarioGetRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/Seguridad/validarUsuario";
            if(request.Query != null)
            {
                url += "?";
                if(request.Query.DNI != null)
                    url += "&DNI=" + Uri.EscapeDataString(request.Query.DNI);
                if(request.Query.Sala != null)
                    url += "&Sala=" + Uri.EscapeDataString(request.Query.Sala);
                if(request.Query.RestKey != null)
                    url += "&RestKey=" + Uri.EscapeDataString(request.Query.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Get, url.StartsWith("/") ? url.Substring(1) : url);

            if(request.RawHeaders != null)
            {
                foreach(var header in request.RawHeaders)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, string.Join(",", header.Value));
                }
            }
	        var response = await proxy.Client.SendAsync(req);
            return new practica1.Seguridad.Models.SeguridadValidarUsuarioGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers,
	                                            Formatters = responseFormatters,
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };
        }

    }

    public partial class SeguridadObtenerNiveles
    {
        private readonly SeguridadClient proxy;

        internal SeguridadObtenerNiveles(SeguridadClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Obtiene todos los niveles que un usuario puede tener - /Seguridad/obtenerNiveles
		/// </summary>
		/// <param name="getseguridadobtenernivelesquery">query properties</param>
        public virtual async Task<practica1.Seguridad.Models.SeguridadObtenerNivelesGetResponse> Get(practica1.Seguridad.Models.GetSeguridadObtenerNivelesQuery getseguridadobtenernivelesquery)
        {

            var url = "/Seguridad/obtenerNiveles";
            if(getseguridadobtenernivelesquery != null)
            {
                url += "?";
                if(getseguridadobtenernivelesquery.DNI != null)
					url += "&DNI=" + Uri.EscapeDataString(getseguridadobtenernivelesquery.DNI);
                if(getseguridadobtenernivelesquery.RestKey != null)
					url += "&RestKey=" + Uri.EscapeDataString(getseguridadobtenernivelesquery.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Get, url.StartsWith("/") ? url.Substring(1) : url);
	        var response = await proxy.Client.SendAsync(req);

            return new practica1.Seguridad.Models.SeguridadObtenerNivelesGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Obtiene todos los niveles que un usuario puede tener - /Seguridad/obtenerNiveles
		/// </summary>
		/// <param name="request">practica1.Seguridad.Models.SeguridadObtenerNivelesGetRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<practica1.Seguridad.Models.SeguridadObtenerNivelesGetResponse> Get(practica1.Seguridad.Models.SeguridadObtenerNivelesGetRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/Seguridad/obtenerNiveles";
            if(request.Query != null)
            {
                url += "?";
                if(request.Query.DNI != null)
                    url += "&DNI=" + Uri.EscapeDataString(request.Query.DNI);
                if(request.Query.RestKey != null)
                    url += "&RestKey=" + Uri.EscapeDataString(request.Query.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Get, url.StartsWith("/") ? url.Substring(1) : url);

            if(request.RawHeaders != null)
            {
                foreach(var header in request.RawHeaders)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, string.Join(",", header.Value));
                }
            }
	        var response = await proxy.Client.SendAsync(req);
            return new practica1.Seguridad.Models.SeguridadObtenerNivelesGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers,
	                                            Formatters = responseFormatters,
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };
        }

    }

    public partial class SeguridadAsignarPermisos
    {
        private readonly SeguridadClient proxy;

        internal SeguridadAsignarPermisos(SeguridadClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Asigna permisos de una sala a un usuario - /Seguridad/asignarPermisos
		/// </summary>
		/// <param name="content"></param>
		/// <param name="postseguridadasignarpermisosquery">query properties</param>
        public virtual async Task<practica1.Seguridad.Models.SeguridadAsignarPermisosPostResponse> Post(string content, practica1.Seguridad.Models.PostSeguridadAsignarPermisosQuery postseguridadasignarpermisosquery)
        {

            var url = "/Seguridad/asignarPermisos";
            if(postseguridadasignarpermisosquery != null)
            {
                url += "?";
                if(postseguridadasignarpermisosquery.DNI != null)
					url += "&DNI=" + Uri.EscapeDataString(postseguridadasignarpermisosquery.DNI);
                if(postseguridadasignarpermisosquery.Sala != null)
					url += "&Sala=" + Uri.EscapeDataString(postseguridadasignarpermisosquery.Sala);
                if(postseguridadasignarpermisosquery.RestKey != null)
					url += "&RestKey=" + Uri.EscapeDataString(postseguridadasignarpermisosquery.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Post, url.StartsWith("/") ? url.Substring(1) : url);
            req.Content = new StringContent(content);
	        var response = await proxy.Client.SendAsync(req);

            return new practica1.Seguridad.Models.SeguridadAsignarPermisosPostResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Asigna permisos de una sala a un usuario - /Seguridad/asignarPermisos
		/// </summary>
		/// <param name="request">practica1.Seguridad.Models.SeguridadAsignarPermisosPostRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<practica1.Seguridad.Models.SeguridadAsignarPermisosPostResponse> Post(practica1.Seguridad.Models.SeguridadAsignarPermisosPostRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/Seguridad/asignarPermisos";
            if(request.Query != null)
            {
                url += "?";
                if(request.Query.DNI != null)
                    url += "&DNI=" + Uri.EscapeDataString(request.Query.DNI);
                if(request.Query.Sala != null)
                    url += "&Sala=" + Uri.EscapeDataString(request.Query.Sala);
                if(request.Query.RestKey != null)
                    url += "&RestKey=" + Uri.EscapeDataString(request.Query.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Post, url.StartsWith("/") ? url.Substring(1) : url);

            if(request.RawHeaders != null)
            {
                foreach(var header in request.RawHeaders)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, string.Join(",", header.Value));
                }
            }
            req.Content = request.Content;
	        var response = await proxy.Client.SendAsync(req);
            return new practica1.Seguridad.Models.SeguridadAsignarPermisosPostResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers,
	                                            Formatters = responseFormatters,
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };
        }

    }

    public partial class SeguridadEliminarPermisos
    {
        private readonly SeguridadClient proxy;

        internal SeguridadEliminarPermisos(SeguridadClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Elimina permisos de una sala a un usuario - /Seguridad/eliminarPermisos
		/// </summary>
		/// <param name="content"></param>
		/// <param name="postseguridadeliminarpermisosquery">query properties</param>
        public virtual async Task<practica1.Seguridad.Models.SeguridadEliminarPermisosPostResponse> Post(string content, practica1.Seguridad.Models.PostSeguridadEliminarPermisosQuery postseguridadeliminarpermisosquery)
        {

            var url = "/Seguridad/eliminarPermisos";
            if(postseguridadeliminarpermisosquery != null)
            {
                url += "?";
                if(postseguridadeliminarpermisosquery.DNI != null)
					url += "&DNI=" + Uri.EscapeDataString(postseguridadeliminarpermisosquery.DNI);
                if(postseguridadeliminarpermisosquery.Sala != null)
					url += "&Sala=" + Uri.EscapeDataString(postseguridadeliminarpermisosquery.Sala);
                if(postseguridadeliminarpermisosquery.RestKey != null)
					url += "&RestKey=" + Uri.EscapeDataString(postseguridadeliminarpermisosquery.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Post, url.StartsWith("/") ? url.Substring(1) : url);
            req.Content = new StringContent(content);
	        var response = await proxy.Client.SendAsync(req);

            return new practica1.Seguridad.Models.SeguridadEliminarPermisosPostResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Elimina permisos de una sala a un usuario - /Seguridad/eliminarPermisos
		/// </summary>
		/// <param name="request">practica1.Seguridad.Models.SeguridadEliminarPermisosPostRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<practica1.Seguridad.Models.SeguridadEliminarPermisosPostResponse> Post(practica1.Seguridad.Models.SeguridadEliminarPermisosPostRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/Seguridad/eliminarPermisos";
            if(request.Query != null)
            {
                url += "?";
                if(request.Query.DNI != null)
                    url += "&DNI=" + Uri.EscapeDataString(request.Query.DNI);
                if(request.Query.Sala != null)
                    url += "&Sala=" + Uri.EscapeDataString(request.Query.Sala);
                if(request.Query.RestKey != null)
                    url += "&RestKey=" + Uri.EscapeDataString(request.Query.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Post, url.StartsWith("/") ? url.Substring(1) : url);

            if(request.RawHeaders != null)
            {
                foreach(var header in request.RawHeaders)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, string.Join(",", header.Value));
                }
            }
            req.Content = request.Content;
	        var response = await proxy.Client.SendAsync(req);
            return new practica1.Seguridad.Models.SeguridadEliminarPermisosPostResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers,
	                                            Formatters = responseFormatters,
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };
        }

    }

    /// <summary>
    /// Main class for grouping root resources. Nested resources are defined as properties. The constructor can optionally receive an URL and HttpClient instance to override the default ones.
    /// </summary>
    public partial class SeguridadClient
    {

		public SchemaValidationSettings SchemaValidation { get; private set; } 

        protected readonly HttpClient client;
        public const string BaseUri = "http://api.mtis.org/";

        internal HttpClient Client { get { return client; } }




        public SeguridadClient(string endpointUrl)
        {
            SchemaValidation = new SchemaValidationSettings
			{
				Enabled = true,
				RaiseExceptions = true
			};

			if(string.IsNullOrWhiteSpace(endpointUrl))
                throw new ArgumentException("You must specify the endpoint URL", "endpointUrl");

			if (endpointUrl.Contains("{"))
			{
				var regex = new Regex(@"\{([^\}]+)\}");
				var matches = regex.Matches(endpointUrl);
				var parameters = new List<string>();
				foreach (Match match in matches)
				{
					parameters.Add(match.Groups[1].Value);
				}
				throw new InvalidOperationException("Please replace parameter/s " + string.Join(", ", parameters) + " in the URL before passing it to the constructor ");
			}

            if (!endpointUrl.EndsWith("/"))
                endpointUrl += "/";

            client = new HttpClient {BaseAddress = new Uri(endpointUrl)};
        }

        public SeguridadClient(HttpClient httpClient)
        {
            if(httpClient.BaseAddress == null)
                throw new InvalidOperationException("You must set the BaseAddress property of the HttpClient instance");

            client = httpClient;

			SchemaValidation = new SchemaValidationSettings
			{
				Enabled = true,
				RaiseExceptions = true
			};
        }

        

        public virtual Seguridad Seguridad
        {
            get { return new Seguridad(this); }
        }
                

        public virtual SeguridadValidarUsuario SeguridadValidarUsuario
        {
            get { return new SeguridadValidarUsuario(this); }
        }
                

        public virtual SeguridadObtenerNiveles SeguridadObtenerNiveles
        {
            get { return new SeguridadObtenerNiveles(this); }
        }
                

        public virtual SeguridadAsignarPermisos SeguridadAsignarPermisos
        {
            get { return new SeguridadAsignarPermisos(this); }
        }
                

        public virtual SeguridadEliminarPermisos SeguridadEliminarPermisos
        {
            get { return new SeguridadEliminarPermisos(this); }
        }
                


		public void AddDefaultRequestHeader(string name, string value)
		{
			client.DefaultRequestHeaders.Add(name, value);
		}

		public void AddDefaultRequestHeader(string name, IEnumerable<string> values)
		{
			client.DefaultRequestHeaders.Add(name, values);
		}

        // root methods



    }

} // end namespace









namespace practica1.Seguridad.Models
{
    public partial class  Error 
    {

        public int Codigo { get; set; }


        public string Mensaje { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Ipbool, Error
    /// </summary>
    public partial class  MultipleSeguridadValidarUsuarioGet : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleSeguridadValidarUsuarioGet()
        {
            names.Add((HttpStatusCode)200, "Ipbool");
            types.Add((HttpStatusCode)200, typeof(bool?));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Peticion correcta 
        /// </summary>

        public bool? Ipbool { get; set; }


        /// <summary>
        /// Ha habido un error en la petición 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Ipstring, Error
    /// </summary>
    public partial class  MultipleSeguridadObtenerNivelesGet : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleSeguridadObtenerNivelesGet()
        {
            names.Add((HttpStatusCode)200, "Ipstring");
            types.Add((HttpStatusCode)200, typeof(IList<string>));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Peticion correcta 
        /// </summary>

        public IList<string> Ipstring { get; set; }


        /// <summary>
        /// Ha habido un error en la peticion 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Ipbool, Error
    /// </summary>
    public partial class  MultipleSeguridadAsignarPermisosPost : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleSeguridadAsignarPermisosPost()
        {
            names.Add((HttpStatusCode)200, "Ipbool");
            types.Add((HttpStatusCode)200, typeof(bool?));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Peticion correcta 
        /// </summary>

        public bool? Ipbool { get; set; }


        /// <summary>
        /// Ha habido un error en la peticion 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Ipbool, Error
    /// </summary>
    public partial class  MultipleSeguridadEliminarPermisosPost : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleSeguridadEliminarPermisosPost()
        {
            names.Add((HttpStatusCode)200, "Ipbool");
            types.Add((HttpStatusCode)200, typeof(bool?));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Peticion correcta 
        /// </summary>

        public bool? Ipbool { get; set; }


        /// <summary>
        /// Ha habido un error en la peticion 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    public partial class  GetSeguridadValidarUsuarioQuery 
    {

        public string DNI { get; set; }


        public string Sala { get; set; }


        public string RestKey { get; set; }


    } // end class

    public partial class  GetSeguridadObtenerNivelesQuery 
    {

        public string DNI { get; set; }


        public string RestKey { get; set; }


    } // end class

    public partial class  PostSeguridadAsignarPermisosQuery 
    {

        public string DNI { get; set; }


        public string Sala { get; set; }


        public string RestKey { get; set; }


    } // end class

    public partial class  PostSeguridadEliminarPermisosQuery 
    {

        public string DNI { get; set; }


        public string Sala { get; set; }


        public string RestKey { get; set; }


    } // end class

    /// <summary>
    /// Request object for method Get of class SeguridadValidarUsuario
    /// </summary>
    public partial class SeguridadValidarUsuarioGetRequest : ApiRequest
    {
        public SeguridadValidarUsuarioGetRequest(GetSeguridadValidarUsuarioQuery Query = null)
        {
            this.Query = Query;
        }


        /// <summary>
        /// Request query string properties
        /// </summary>
        public GetSeguridadValidarUsuarioQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Get of class SeguridadObtenerNiveles
    /// </summary>
    public partial class SeguridadObtenerNivelesGetRequest : ApiRequest
    {
        public SeguridadObtenerNivelesGetRequest(GetSeguridadObtenerNivelesQuery Query = null)
        {
            this.Query = Query;
        }


        /// <summary>
        /// Request query string properties
        /// </summary>
        public GetSeguridadObtenerNivelesQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Post of class SeguridadAsignarPermisos
    /// </summary>
    public partial class SeguridadAsignarPermisosPostRequest : ApiRequest
    {
        public SeguridadAsignarPermisosPostRequest(HttpContent Content = null, MediaTypeFormatter Formatter = null, PostSeguridadAsignarPermisosQuery Query = null)
        {
            this.Content = Content;
            this.Formatter = Formatter;
            this.Query = Query;
        }


        /// <summary>
        /// Request content
        /// </summary>
        public HttpContent Content { get; set; }

        /// <summary>
        /// Request formatter
        /// </summary>
        public MediaTypeFormatter Formatter { get; set; }

        /// <summary>
        /// Request query string properties
        /// </summary>
        public PostSeguridadAsignarPermisosQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Post of class SeguridadEliminarPermisos
    /// </summary>
    public partial class SeguridadEliminarPermisosPostRequest : ApiRequest
    {
        public SeguridadEliminarPermisosPostRequest(HttpContent Content = null, MediaTypeFormatter Formatter = null, PostSeguridadEliminarPermisosQuery Query = null)
        {
            this.Content = Content;
            this.Formatter = Formatter;
            this.Query = Query;
        }


        /// <summary>
        /// Request content
        /// </summary>
        public HttpContent Content { get; set; }

        /// <summary>
        /// Request formatter
        /// </summary>
        public MediaTypeFormatter Formatter { get; set; }

        /// <summary>
        /// Request query string properties
        /// </summary>
        public PostSeguridadEliminarPermisosQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Response object for method Get of class SeguridadValidarUsuario
    /// </summary>

    public partial class SeguridadValidarUsuarioGetResponse : ApiResponse
    {

	    private MultipleSeguridadValidarUsuarioGet typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleSeguridadValidarUsuarioGet Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleSeguridadValidarUsuarioGet();

                IEnumerable<string> values = new List<string>();
                if (RawContent != null && RawContent.Headers != null)
                    RawContent.Headers.TryGetValues("Content-Type", out values);

                if (values.Any(hv => hv.ToLowerInvariant().Contains("xml")) &&
                    !values.Any(hv => hv.ToLowerInvariant().Contains("json")))
                {
                    var task = RawContent.ReadAsStreamAsync();

                    var xmlStream = task.GetAwaiter().GetResult();
                    var content = new XmlSerializer(typedContent.GetTypeByStatusCode(StatusCode)).Deserialize(xmlStream);
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }
                else
                {
		            var task = Formatters != null && Formatters.Any() 
                                ? RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode), Formatters).ConfigureAwait(false)
                                : RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode)).ConfigureAwait(false);
		        
		            var content = task.GetAwaiter().GetResult();
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }

		        return typedContent;
	        }
    	}  
		
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return MultipleSeguridadValidarUsuarioGet.GetSchema(statusCode);
        }      

    } // end class

    /// <summary>
    /// Response object for method Get of class SeguridadObtenerNiveles
    /// </summary>

    public partial class SeguridadObtenerNivelesGetResponse : ApiResponse
    {

	    private MultipleSeguridadObtenerNivelesGet typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleSeguridadObtenerNivelesGet Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleSeguridadObtenerNivelesGet();

                IEnumerable<string> values = new List<string>();
                if (RawContent != null && RawContent.Headers != null)
                    RawContent.Headers.TryGetValues("Content-Type", out values);

                if (values.Any(hv => hv.ToLowerInvariant().Contains("xml")) &&
                    !values.Any(hv => hv.ToLowerInvariant().Contains("json")))
                {
                    var task = RawContent.ReadAsStreamAsync();

                    var xmlStream = task.GetAwaiter().GetResult();
                    var content = new XmlSerializer(typedContent.GetTypeByStatusCode(StatusCode)).Deserialize(xmlStream);
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }
                else
                {
		            var task = Formatters != null && Formatters.Any() 
                                ? RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode), Formatters).ConfigureAwait(false)
                                : RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode)).ConfigureAwait(false);
		        
		            var content = task.GetAwaiter().GetResult();
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }

		        return typedContent;
	        }
    	}  
		
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return MultipleSeguridadObtenerNivelesGet.GetSchema(statusCode);
        }      

    } // end class

    /// <summary>
    /// Response object for method Post of class SeguridadAsignarPermisos
    /// </summary>

    public partial class SeguridadAsignarPermisosPostResponse : ApiResponse
    {

	    private MultipleSeguridadAsignarPermisosPost typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleSeguridadAsignarPermisosPost Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleSeguridadAsignarPermisosPost();

                IEnumerable<string> values = new List<string>();
                if (RawContent != null && RawContent.Headers != null)
                    RawContent.Headers.TryGetValues("Content-Type", out values);

                if (values.Any(hv => hv.ToLowerInvariant().Contains("xml")) &&
                    !values.Any(hv => hv.ToLowerInvariant().Contains("json")))
                {
                    var task = RawContent.ReadAsStreamAsync();

                    var xmlStream = task.GetAwaiter().GetResult();
                    var content = new XmlSerializer(typedContent.GetTypeByStatusCode(StatusCode)).Deserialize(xmlStream);
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }
                else
                {
		            var task = Formatters != null && Formatters.Any() 
                                ? RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode), Formatters).ConfigureAwait(false)
                                : RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode)).ConfigureAwait(false);
		        
		            var content = task.GetAwaiter().GetResult();
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }

		        return typedContent;
	        }
    	}  
		
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return MultipleSeguridadAsignarPermisosPost.GetSchema(statusCode);
        }      

    } // end class

    /// <summary>
    /// Response object for method Post of class SeguridadEliminarPermisos
    /// </summary>

    public partial class SeguridadEliminarPermisosPostResponse : ApiResponse
    {

	    private MultipleSeguridadEliminarPermisosPost typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleSeguridadEliminarPermisosPost Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleSeguridadEliminarPermisosPost();

                IEnumerable<string> values = new List<string>();
                if (RawContent != null && RawContent.Headers != null)
                    RawContent.Headers.TryGetValues("Content-Type", out values);

                if (values.Any(hv => hv.ToLowerInvariant().Contains("xml")) &&
                    !values.Any(hv => hv.ToLowerInvariant().Contains("json")))
                {
                    var task = RawContent.ReadAsStreamAsync();

                    var xmlStream = task.GetAwaiter().GetResult();
                    var content = new XmlSerializer(typedContent.GetTypeByStatusCode(StatusCode)).Deserialize(xmlStream);
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }
                else
                {
		            var task = Formatters != null && Formatters.Any() 
                                ? RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode), Formatters).ConfigureAwait(false)
                                : RawContent.ReadAsAsync(typedContent.GetTypeByStatusCode(StatusCode)).ConfigureAwait(false);
		        
		            var content = task.GetAwaiter().GetResult();
                    typedContent.SetPropertyByStatusCode(StatusCode, content);
                }

		        return typedContent;
	        }
    	}  
		
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return MultipleSeguridadEliminarPermisosPost.GetSchema(statusCode);
        }      

    } // end class


} // end Models namespace
