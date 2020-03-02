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
using practica1.Empleado.Models;

namespace practica1.Empleado
{
    public partial class Empleado
    {
        private readonly EmpleadoClient proxy;

        internal Empleado(EmpleadoClient proxy)
        {
            this.proxy = proxy;
        }

    }

    public partial class EmpleadoNuevo
    {
        private readonly EmpleadoClient proxy;

        internal EmpleadoNuevo(EmpleadoClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Crea nuevo empleado - /Empleado/nuevo
		/// </summary>
		/// <param name="empleado"></param>
		/// <param name="postempleadonuevoquery">query properties</param>
        public virtual async Task<practica1.Empleado.Models.EmpleadoNuevoPostResponse> Post(practica1.Empleado.Models.Empleado empleado, practica1.Empleado.Models.PostEmpleadoNuevoQuery postempleadonuevoquery)
        {

            var url = "/Empleado/nuevo";
            if(postempleadonuevoquery != null)
            {
                url += "?";
                if(postempleadonuevoquery.RestKey != null)
					url += "&RestKey=" + Uri.EscapeDataString(postempleadonuevoquery.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Post, url.StartsWith("/") ? url.Substring(1) : url);
            req.Content = new ObjectContent(typeof(practica1.Empleado.Models.Empleado), empleado, new JsonMediaTypeFormatter());                           
	        var response = await proxy.Client.SendAsync(req);

            return new practica1.Empleado.Models.EmpleadoNuevoPostResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Crea nuevo empleado - /Empleado/nuevo
		/// </summary>
		/// <param name="request">practica1.Empleado.Models.EmpleadoNuevoPostRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<practica1.Empleado.Models.EmpleadoNuevoPostResponse> Post(practica1.Empleado.Models.EmpleadoNuevoPostRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/Empleado/nuevo";
            if(request.Query != null)
            {
                url += "?";
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
            if(request.Formatter == null)
                request.Formatter = new JsonMediaTypeFormatter();

			req.Content = new ObjectContent(typeof(Empleado), request.Content, request.Formatter);
	        var response = await proxy.Client.SendAsync(req);
            return new practica1.Empleado.Models.EmpleadoNuevoPostResponse  
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

    public partial class EmpleadoBorrar
    {
        private readonly EmpleadoClient proxy;

        internal EmpleadoBorrar(EmpleadoClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Borrar empleado - /Empleado/borrar
		/// </summary>
		/// <param name="content"></param>
		/// <param name="postempleadoborrarquery">query properties</param>
        public virtual async Task<practica1.Empleado.Models.EmpleadoBorrarPostResponse> Post(string content, practica1.Empleado.Models.PostEmpleadoBorrarQuery postempleadoborrarquery)
        {

            var url = "/Empleado/borrar";
            if(postempleadoborrarquery != null)
            {
                url += "?";
                if(postempleadoborrarquery.RestKey != null)
					url += "&RestKey=" + Uri.EscapeDataString(postempleadoborrarquery.RestKey);
                if(postempleadoborrarquery.DNI != null)
					url += "&DNI=" + Uri.EscapeDataString(postempleadoborrarquery.DNI);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Post, url.StartsWith("/") ? url.Substring(1) : url);
            req.Content = new StringContent(content);
	        var response = await proxy.Client.SendAsync(req);

            return new practica1.Empleado.Models.EmpleadoBorrarPostResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Borrar empleado - /Empleado/borrar
		/// </summary>
		/// <param name="request">practica1.Empleado.Models.EmpleadoBorrarPostRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<practica1.Empleado.Models.EmpleadoBorrarPostResponse> Post(practica1.Empleado.Models.EmpleadoBorrarPostRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/Empleado/borrar";
            if(request.Query != null)
            {
                url += "?";
                if(request.Query.RestKey != null)
                    url += "&RestKey=" + Uri.EscapeDataString(request.Query.RestKey);
                if(request.Query.DNI != null)
                    url += "&DNI=" + Uri.EscapeDataString(request.Query.DNI);
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
            return new practica1.Empleado.Models.EmpleadoBorrarPostResponse  
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

    public partial class EmpleadoModificar
    {
        private readonly EmpleadoClient proxy;

        internal EmpleadoModificar(EmpleadoClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Modificar empleado - /Empleado/modificar
		/// </summary>
		/// <param name="empleado"></param>
		/// <param name="putempleadomodificarquery">query properties</param>
        public virtual async Task<practica1.Empleado.Models.EmpleadoModificarPutResponse> Put(practica1.Empleado.Models.Empleado empleado, practica1.Empleado.Models.PutEmpleadoModificarQuery putempleadomodificarquery)
        {

            var url = "/Empleado/modificar";
            if(putempleadomodificarquery != null)
            {
                url += "?";
                if(putempleadomodificarquery.RestKey != null)
					url += "&RestKey=" + Uri.EscapeDataString(putempleadomodificarquery.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Put, url.StartsWith("/") ? url.Substring(1) : url);
            req.Content = new ObjectContent(typeof(practica1.Empleado.Models.Empleado), empleado, new JsonMediaTypeFormatter());                           
	        var response = await proxy.Client.SendAsync(req);

            return new practica1.Empleado.Models.EmpleadoModificarPutResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Modificar empleado - /Empleado/modificar
		/// </summary>
		/// <param name="request">practica1.Empleado.Models.EmpleadoModificarPutRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<practica1.Empleado.Models.EmpleadoModificarPutResponse> Put(practica1.Empleado.Models.EmpleadoModificarPutRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/Empleado/modificar";
            if(request.Query != null)
            {
                url += "?";
                if(request.Query.RestKey != null)
                    url += "&RestKey=" + Uri.EscapeDataString(request.Query.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Put, url.StartsWith("/") ? url.Substring(1) : url);

            if(request.RawHeaders != null)
            {
                foreach(var header in request.RawHeaders)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, string.Join(",", header.Value));
                }
            }
            if(request.Formatter == null)
                request.Formatter = new JsonMediaTypeFormatter();

			req.Content = new ObjectContent(typeof(Empleado), request.Content, request.Formatter);
	        var response = await proxy.Client.SendAsync(req);
            return new practica1.Empleado.Models.EmpleadoModificarPutResponse  
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

    public partial class EmpleadoConsultar
    {
        private readonly EmpleadoClient proxy;

        internal EmpleadoConsultar(EmpleadoClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Consultar empleado - /Empleado/consultar
		/// </summary>
		/// <param name="getempleadoconsultarquery">query properties</param>
        public virtual async Task<practica1.Empleado.Models.EmpleadoConsultarGetResponse> Get(practica1.Empleado.Models.GetEmpleadoConsultarQuery getempleadoconsultarquery)
        {

            var url = "/Empleado/consultar";
            if(getempleadoconsultarquery != null)
            {
                url += "?";
                if(getempleadoconsultarquery.RestKey != null)
					url += "&RestKey=" + Uri.EscapeDataString(getempleadoconsultarquery.RestKey);
                if(getempleadoconsultarquery.DNI != null)
					url += "&DNI=" + Uri.EscapeDataString(getempleadoconsultarquery.DNI);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Get, url.StartsWith("/") ? url.Substring(1) : url);
	        var response = await proxy.Client.SendAsync(req);

            return new practica1.Empleado.Models.EmpleadoConsultarGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Consultar empleado - /Empleado/consultar
		/// </summary>
		/// <param name="request">practica1.Empleado.Models.EmpleadoConsultarGetRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<practica1.Empleado.Models.EmpleadoConsultarGetResponse> Get(practica1.Empleado.Models.EmpleadoConsultarGetRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/Empleado/consultar";
            if(request.Query != null)
            {
                url += "?";
                if(request.Query.RestKey != null)
                    url += "&RestKey=" + Uri.EscapeDataString(request.Query.RestKey);
                if(request.Query.DNI != null)
                    url += "&DNI=" + Uri.EscapeDataString(request.Query.DNI);
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
            return new practica1.Empleado.Models.EmpleadoConsultarGetResponse  
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
    public partial class EmpleadoClient
    {

		public SchemaValidationSettings SchemaValidation { get; private set; } 

        protected readonly HttpClient client;
        public const string BaseUri = "http://api.mtis.org/";

        internal HttpClient Client { get { return client; } }




        public EmpleadoClient(string endpointUrl)
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

        public EmpleadoClient(HttpClient httpClient)
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

        

        public virtual Empleado Empleado
        {
            get { return new Empleado(this); }
        }
                

        public virtual EmpleadoNuevo EmpleadoNuevo
        {
            get { return new EmpleadoNuevo(this); }
        }
                

        public virtual EmpleadoBorrar EmpleadoBorrar
        {
            get { return new EmpleadoBorrar(this); }
        }
                

        public virtual EmpleadoModificar EmpleadoModificar
        {
            get { return new EmpleadoModificar(this); }
        }
                

        public virtual EmpleadoConsultar EmpleadoConsultar
        {
            get { return new EmpleadoConsultar(this); }
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









namespace practica1.Empleado.Models
{
    public partial class  Error 
    {

        public int Codigo { get; set; }


        public string Mensaje { get; set; }


    } // end class

    public partial class  Empleado 
    {

        public string DNI { get; set; }


        public string Nombre { get; set; }


        public string Apellidos { get; set; }


        public string Direccion { get; set; }


        public string Poblacion { get; set; }


        public string Telefono { get; set; }


        public string Email { get; set; }


        public string Fecha_nacimiento { get; set; }


        public string NSS { get; set; }


        public string IBAN { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Ipbool, Error
    /// </summary>
    public partial class  MultipleEmpleadoNuevoPost : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleEmpleadoNuevoPost()
        {
            names.Add((HttpStatusCode)200, "Ipbool");
            types.Add((HttpStatusCode)200, typeof(bool?));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Empleado añadido correctamente 
        /// </summary>

        public bool? Ipbool { get; set; }


        /// <summary>
        /// Error 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Ipbool, Error
    /// </summary>
    public partial class  MultipleEmpleadoBorrarPost : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleEmpleadoBorrarPost()
        {
            names.Add((HttpStatusCode)200, "Ipbool");
            types.Add((HttpStatusCode)200, typeof(bool?));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Empleado eliminado correctamente 
        /// </summary>

        public bool? Ipbool { get; set; }


        /// <summary>
        /// Error 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Ipbool, Error
    /// </summary>
    public partial class  MultipleEmpleadoModificarPut : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleEmpleadoModificarPut()
        {
            names.Add((HttpStatusCode)200, "Ipbool");
            types.Add((HttpStatusCode)200, typeof(bool?));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Empleado modificado correctamente 
        /// </summary>

        public bool? Ipbool { get; set; }


        /// <summary>
        /// Error 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Empleado, Error
    /// </summary>
    public partial class  MultipleEmpleadoConsultarGet : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleEmpleadoConsultarGet()
        {
            names.Add((HttpStatusCode)200, "Empleado");
            types.Add((HttpStatusCode)200, typeof(Empleado));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Empleado consultado correctamente 
        /// </summary>

        public Empleado Empleado { get; set; }


        /// <summary>
        /// Error 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    public partial class  PostEmpleadoNuevoQuery 
    {

        public string RestKey { get; set; }


    } // end class

    public partial class  PostEmpleadoBorrarQuery 
    {

        public string RestKey { get; set; }


        public string DNI { get; set; }


    } // end class

    public partial class  PutEmpleadoModificarQuery 
    {

        public string RestKey { get; set; }


    } // end class

    public partial class  GetEmpleadoConsultarQuery 
    {

        public string RestKey { get; set; }


        public string DNI { get; set; }


    } // end class

    /// <summary>
    /// Request object for method Post of class EmpleadoNuevo
    /// </summary>
    public partial class EmpleadoNuevoPostRequest : ApiRequest
    {
        public EmpleadoNuevoPostRequest(Empleado Content = null, MediaTypeFormatter Formatter = null, PostEmpleadoNuevoQuery Query = null)
        {
            this.Content = Content;
            this.Formatter = Formatter;
            this.Query = Query;
        }


        /// <summary>
        /// Request content
        /// </summary>
        public Empleado Content { get; set; }

        /// <summary>
        /// Request formatter
        /// </summary>
        public MediaTypeFormatter Formatter { get; set; }

        /// <summary>
        /// Request query string properties
        /// </summary>
        public PostEmpleadoNuevoQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Post of class EmpleadoBorrar
    /// </summary>
    public partial class EmpleadoBorrarPostRequest : ApiRequest
    {
        public EmpleadoBorrarPostRequest(HttpContent Content = null, MediaTypeFormatter Formatter = null, PostEmpleadoBorrarQuery Query = null)
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
        public PostEmpleadoBorrarQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Put of class EmpleadoModificar
    /// </summary>
    public partial class EmpleadoModificarPutRequest : ApiRequest
    {
        public EmpleadoModificarPutRequest(Empleado Content = null, MediaTypeFormatter Formatter = null, PutEmpleadoModificarQuery Query = null)
        {
            this.Content = Content;
            this.Formatter = Formatter;
            this.Query = Query;
        }


        /// <summary>
        /// Request content
        /// </summary>
        public Empleado Content { get; set; }

        /// <summary>
        /// Request formatter
        /// </summary>
        public MediaTypeFormatter Formatter { get; set; }

        /// <summary>
        /// Request query string properties
        /// </summary>
        public PutEmpleadoModificarQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Get of class EmpleadoConsultar
    /// </summary>
    public partial class EmpleadoConsultarGetRequest : ApiRequest
    {
        public EmpleadoConsultarGetRequest(GetEmpleadoConsultarQuery Query = null)
        {
            this.Query = Query;
        }


        /// <summary>
        /// Request query string properties
        /// </summary>
        public GetEmpleadoConsultarQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Response object for method Post of class EmpleadoNuevo
    /// </summary>

    public partial class EmpleadoNuevoPostResponse : ApiResponse
    {

	    private MultipleEmpleadoNuevoPost typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleEmpleadoNuevoPost Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleEmpleadoNuevoPost();

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
            return MultipleEmpleadoNuevoPost.GetSchema(statusCode);
        }      

    } // end class

    /// <summary>
    /// Response object for method Post of class EmpleadoBorrar
    /// </summary>

    public partial class EmpleadoBorrarPostResponse : ApiResponse
    {

	    private MultipleEmpleadoBorrarPost typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleEmpleadoBorrarPost Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleEmpleadoBorrarPost();

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
            return MultipleEmpleadoBorrarPost.GetSchema(statusCode);
        }      

    } // end class

    /// <summary>
    /// Response object for method Put of class EmpleadoModificar
    /// </summary>

    public partial class EmpleadoModificarPutResponse : ApiResponse
    {

	    private MultipleEmpleadoModificarPut typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleEmpleadoModificarPut Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleEmpleadoModificarPut();

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
            return MultipleEmpleadoModificarPut.GetSchema(statusCode);
        }      

    } // end class

    /// <summary>
    /// Response object for method Get of class EmpleadoConsultar
    /// </summary>

    public partial class EmpleadoConsultarGetResponse : ApiResponse
    {

	    private MultipleEmpleadoConsultarGet typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleEmpleadoConsultarGet Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleEmpleadoConsultarGet();

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
            return MultipleEmpleadoConsultarGet.GetSchema(statusCode);
        }      

    } // end class


} // end Models namespace
