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
using practica1.Utilidades.Models;

namespace practica1.Utilidades
{
    public partial class Utilidades
    {
        private readonly UtilidadesClient proxy;

        internal Utilidades(UtilidadesClient proxy)
        {
            this.proxy = proxy;
        }

    }

    public partial class UtilidadesValidarNIF
    {
        private readonly UtilidadesClient proxy;

        internal UtilidadesValidarNIF(UtilidadesClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Valida el NIF de un usuario y devuelve cierto si es correcto o falso si no lo es - /Utilidades/validarNIF
		/// </summary>
		/// <param name="getutilidadesvalidarnifquery">query properties</param>
        public virtual async Task<practica1.Utilidades.Models.UtilidadesValidarNIFGetResponse> Get(practica1.Utilidades.Models.GetUtilidadesValidarNIFQuery getutilidadesvalidarnifquery)
        {

            var url = "/Utilidades/validarNIF";
            if(getutilidadesvalidarnifquery != null)
            {
                url += "?";
                if(getutilidadesvalidarnifquery.DNI != null)
					url += "&DNI=" + Uri.EscapeDataString(getutilidadesvalidarnifquery.DNI);
                if(getutilidadesvalidarnifquery.RestKey != null)
					url += "&RestKey=" + Uri.EscapeDataString(getutilidadesvalidarnifquery.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Get, url.StartsWith("/") ? url.Substring(1) : url);
	        var response = await proxy.Client.SendAsync(req);

            var headers = new practica1.Utilidades.Models.GetUtilidadesValidarNIFOKResponseHeader();
            headers.SetProperties(response.Headers);
            return new practica1.Utilidades.Models.UtilidadesValidarNIFGetResponse  
                                            {
                                                RawContent = response.Content,
                                                Headers = headers, 
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Valida el NIF de un usuario y devuelve cierto si es correcto o falso si no lo es - /Utilidades/validarNIF
		/// </summary>
		/// <param name="request">practica1.Utilidades.Models.UtilidadesValidarNIFGetRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<practica1.Utilidades.Models.UtilidadesValidarNIFGetResponse> Get(practica1.Utilidades.Models.UtilidadesValidarNIFGetRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/Utilidades/validarNIF";
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

            if(request.Headers != null)
            {
                foreach(var header in request.Headers.Headers)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
            if(request.RawHeaders != null)
            {
                foreach(var header in request.RawHeaders)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, string.Join(",", header.Value));
                }
            }
	        var response = await proxy.Client.SendAsync(req);
            var headers = new practica1.Utilidades.Models.GetUtilidadesValidarNIFOKResponseHeader();
            headers.SetProperties(response.Headers);
            return new practica1.Utilidades.Models.UtilidadesValidarNIFGetResponse  
                                            {
                                                RawContent = response.Content,
                                                Headers = headers, 
                                                RawHeaders = response.Headers,
	                                            Formatters = responseFormatters,
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };
        }

    }

    public partial class UtilidadesValidarNAFSS
    {
        private readonly UtilidadesClient proxy;

        internal UtilidadesValidarNAFSS(UtilidadesClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// valida el NAFSS de un usuario - /Utilidades/validarNAFSS
		/// </summary>
		/// <param name="getutilidadesvalidarnafssquery">query properties</param>
        public virtual async Task<practica1.Utilidades.Models.UtilidadesValidarNAFSSGetResponse> Get(practica1.Utilidades.Models.GetUtilidadesValidarNAFSSQuery getutilidadesvalidarnafssquery)
        {

            var url = "/Utilidades/validarNAFSS";
            if(getutilidadesvalidarnafssquery != null)
            {
                url += "?";
                if(getutilidadesvalidarnafssquery.DNI != null)
					url += "&DNI=" + Uri.EscapeDataString(getutilidadesvalidarnafssquery.DNI);
                if(getutilidadesvalidarnafssquery.RestKey != null)
					url += "&RestKey=" + Uri.EscapeDataString(getutilidadesvalidarnafssquery.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Get, url.StartsWith("/") ? url.Substring(1) : url);
	        var response = await proxy.Client.SendAsync(req);

            return new practica1.Utilidades.Models.UtilidadesValidarNAFSSGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// valida el NAFSS de un usuario - /Utilidades/validarNAFSS
		/// </summary>
		/// <param name="request">practica1.Utilidades.Models.UtilidadesValidarNAFSSGetRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<practica1.Utilidades.Models.UtilidadesValidarNAFSSGetResponse> Get(practica1.Utilidades.Models.UtilidadesValidarNAFSSGetRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/Utilidades/validarNAFSS";
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
            return new practica1.Utilidades.Models.UtilidadesValidarNAFSSGetResponse  
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

    public partial class UtilidadesValidarIBAN
    {
        private readonly UtilidadesClient proxy;

        internal UtilidadesValidarIBAN(UtilidadesClient proxy)
        {
            this.proxy = proxy;
        }


        /// <summary>
		/// Valida el IBAN de un usuario - /Utilidades/validarIBAN
		/// </summary>
		/// <param name="getutilidadesvalidaribanquery">query properties</param>
        public virtual async Task<practica1.Utilidades.Models.UtilidadesValidarIBANGetResponse> Get(practica1.Utilidades.Models.GetUtilidadesValidarIBANQuery getutilidadesvalidaribanquery)
        {

            var url = "/Utilidades/validarIBAN";
            if(getutilidadesvalidaribanquery != null)
            {
                url += "?";
                if(getutilidadesvalidaribanquery.DNI != null)
					url += "&DNI=" + Uri.EscapeDataString(getutilidadesvalidaribanquery.DNI);
                if(getutilidadesvalidaribanquery.RestKey != null)
					url += "&RestKey=" + Uri.EscapeDataString(getutilidadesvalidaribanquery.RestKey);
            }

            url = url.Replace("?&", "?");

            var req = new HttpRequestMessage(HttpMethod.Get, url.StartsWith("/") ? url.Substring(1) : url);
	        var response = await proxy.Client.SendAsync(req);

            return new practica1.Utilidades.Models.UtilidadesValidarIBANGetResponse  
                                            {
                                                RawContent = response.Content,
                                                RawHeaders = response.Headers, 
                                                StatusCode = response.StatusCode,
                                                ReasonPhrase = response.ReasonPhrase,
												SchemaValidation = new Lazy<SchemaValidationResults>(() => new SchemaValidationResults(true), true)
                                            };

        }

        /// <summary>
		/// Valida el IBAN de un usuario - /Utilidades/validarIBAN
		/// </summary>
		/// <param name="request">practica1.Utilidades.Models.UtilidadesValidarIBANGetRequest</param>
		/// <param name="responseFormatters">response formatters</param>
        public virtual async Task<practica1.Utilidades.Models.UtilidadesValidarIBANGetResponse> Get(practica1.Utilidades.Models.UtilidadesValidarIBANGetRequest request, IEnumerable<MediaTypeFormatter> responseFormatters = null)
        {

            var url = "/Utilidades/validarIBAN";
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
            return new practica1.Utilidades.Models.UtilidadesValidarIBANGetResponse  
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
    public partial class UtilidadesClient
    {

		public SchemaValidationSettings SchemaValidation { get; private set; } 

        protected readonly HttpClient client;
        public const string BaseUri = "http://api.mtis.org/";

        internal HttpClient Client { get { return client; } }




        public UtilidadesClient(string endpointUrl)
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

        public UtilidadesClient(HttpClient httpClient)
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

        

        public virtual Utilidades Utilidades
        {
            get { return new Utilidades(this); }
        }
                

        public virtual UtilidadesValidarNIF UtilidadesValidarNIF
        {
            get { return new UtilidadesValidarNIF(this); }
        }
                

        public virtual UtilidadesValidarNAFSS UtilidadesValidarNAFSS
        {
            get { return new UtilidadesValidarNAFSS(this); }
        }
                

        public virtual UtilidadesValidarIBAN UtilidadesValidarIBAN
        {
            get { return new UtilidadesValidarIBAN(this); }
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









namespace practica1.Utilidades.Models
{
    public partial class  Error 
    {

        public int Codigo { get; set; }


        public string Mensaje { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Ipbool, Error
    /// </summary>
    public partial class  MultipleUtilidadesValidarNIFGet : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleUtilidadesValidarNIFGet()
        {
            names.Add((HttpStatusCode)200, "Ipbool");
            types.Add((HttpStatusCode)200, typeof(bool?));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Validacion correcta 
        /// </summary>

        public bool? Ipbool { get; set; }


        /// <summary>
        /// NIF invalido 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Ipbool, Error
    /// </summary>
    public partial class  MultipleUtilidadesValidarNAFSSGet : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleUtilidadesValidarNAFSSGet()
        {
            names.Add((HttpStatusCode)200, "Ipbool");
            types.Add((HttpStatusCode)200, typeof(bool?));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Validacion correcta 
        /// </summary>

        public bool? Ipbool { get; set; }


        /// <summary>
        /// NAFSS invalido 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    /// <summary>
    /// Multiple Response Types Ipbool, Error
    /// </summary>
    public partial class  MultipleUtilidadesValidarIBANGet : ApiMultipleResponse
    {
        static readonly Dictionary<HttpStatusCode, string> schemas = new Dictionary<HttpStatusCode, string>
        {
		};
        
		public static string GetSchema(HttpStatusCode statusCode)
        {
            return schemas.ContainsKey(statusCode) ? schemas[statusCode] : string.Empty;
        }
        
        public MultipleUtilidadesValidarIBANGet()
        {
            names.Add((HttpStatusCode)200, "Ipbool");
            types.Add((HttpStatusCode)200, typeof(bool?));
            names.Add((HttpStatusCode)400, "Error");
            types.Add((HttpStatusCode)400, typeof(Error));
        }

        /// <summary>
        /// Validacion correcta 
        /// </summary>

        public bool? Ipbool { get; set; }


        /// <summary>
        /// IBAN invalido 
        /// </summary>

        public Error Error { get; set; }


    } // end class

    public partial class  GetUtilidadesValidarNIFQuery 
    {

        public string DNI { get; set; }


        public string RestKey { get; set; }


    } // end class

    public partial class  GetUtilidadesValidarNAFSSQuery 
    {

        public string DNI { get; set; }


        public string RestKey { get; set; }


    } // end class

    public partial class  GetUtilidadesValidarIBANQuery 
    {

        public string DNI { get; set; }


        public string RestKey { get; set; }


    } // end class

    public partial class GetUtilidadesValidarNIFHeader : ApiHeader
    {


		[JsonProperty("Access-Control-Allow-Origin")]
        public string AccessControlAllowOrigin { get; set; }

    } // end class

    public partial class GetUtilidadesValidarNIFOKResponseHeader : ApiResponseHeader
    {

		[JsonProperty("Access-Control-Allow-Origin")]
        public string AccessControlAllowOrigin { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Get of class UtilidadesValidarNIF
    /// </summary>
    public partial class UtilidadesValidarNIFGetRequest : ApiRequest
    {
        public UtilidadesValidarNIFGetRequest(GetUtilidadesValidarNIFHeader Headers = null, GetUtilidadesValidarNIFQuery Query = null)
        {
            this.Headers = Headers;
            this.Query = Query;
        }


        /// <summary>
        /// Typed Request headers
        /// </summary>
        public GetUtilidadesValidarNIFHeader Headers { get; set; }

        /// <summary>
        /// Request query string properties
        /// </summary>
        public GetUtilidadesValidarNIFQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Get of class UtilidadesValidarNAFSS
    /// </summary>
    public partial class UtilidadesValidarNAFSSGetRequest : ApiRequest
    {
        public UtilidadesValidarNAFSSGetRequest(GetUtilidadesValidarNAFSSQuery Query = null)
        {
            this.Query = Query;
        }


        /// <summary>
        /// Request query string properties
        /// </summary>
        public GetUtilidadesValidarNAFSSQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Request object for method Get of class UtilidadesValidarIBAN
    /// </summary>
    public partial class UtilidadesValidarIBANGetRequest : ApiRequest
    {
        public UtilidadesValidarIBANGetRequest(GetUtilidadesValidarIBANQuery Query = null)
        {
            this.Query = Query;
        }


        /// <summary>
        /// Request query string properties
        /// </summary>
        public GetUtilidadesValidarIBANQuery Query { get; set; }

    } // end class

    /// <summary>
    /// Response object for method Get of class UtilidadesValidarNIF
    /// </summary>

    public partial class UtilidadesValidarNIFGetResponse : ApiResponse
    {


        /// <summary>
        /// Typed Response headers (defined in RAML)
        /// </summary>
        public practica1.Utilidades.Models.GetUtilidadesValidarNIFOKResponseHeader Headers { get; set; }
	    private MultipleUtilidadesValidarNIFGet typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleUtilidadesValidarNIFGet Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleUtilidadesValidarNIFGet();

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
            return MultipleUtilidadesValidarNIFGet.GetSchema(statusCode);
        }      

    } // end class

    /// <summary>
    /// Response object for method Get of class UtilidadesValidarNAFSS
    /// </summary>

    public partial class UtilidadesValidarNAFSSGetResponse : ApiResponse
    {

	    private MultipleUtilidadesValidarNAFSSGet typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleUtilidadesValidarNAFSSGet Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleUtilidadesValidarNAFSSGet();

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
            return MultipleUtilidadesValidarNAFSSGet.GetSchema(statusCode);
        }      

    } // end class

    /// <summary>
    /// Response object for method Get of class UtilidadesValidarIBAN
    /// </summary>

    public partial class UtilidadesValidarIBANGetResponse : ApiResponse
    {

	    private MultipleUtilidadesValidarIBANGet typedContent;
        /// <summary>
        /// Typed response content
        /// </summary>
        public MultipleUtilidadesValidarIBANGet Content 
	    {
	        get
	        {
		        if (typedContent != null) 
					return typedContent;

		        typedContent = new MultipleUtilidadesValidarIBANGet();

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
            return MultipleUtilidadesValidarIBANGet.GetSchema(statusCode);
        }      

    } // end class


} // end Models namespace
