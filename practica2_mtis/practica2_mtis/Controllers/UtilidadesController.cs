// Template: Controller Implementation (ApiControllerImplementation.t4) version 4.0

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using practica2_mtis.Empleado.Models;
using practica2_mtis.Models;
using practica2_mtis.Seguridad.Models;
using practica2_mtis.Utilidades.Models;

namespace practica2_mtis.Utilidades
{
    public partial class UtilidadesController : IUtilidadesController
    {
        private db db;
        /// <summary>
        /// Valida el NIF de un usuario y devuelve cierto si es correcto o falso si no lo es - /Utilidades/validarNIF
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="restkey"></param>
        /// <returns>MultipleUtilidadesValidarNIFGet</returns>
        public IHttpActionResult Get([FromUri] string dni,[FromUri] string restkey)
        {
            MultipleUtilidadesValidarNIFGet salida = new MultipleUtilidadesValidarNIFGet
            {
                Error = new Error()
            };
            string data = dni;

            db = new db();
            if (!db.ComprobarApiKey(restkey))
            {
                salida.Error.Mensaje = "RestKey no coincide.";
                salida.Error.Codigo = 401;
                return Ok(salida);
            }

            if (data == String.Empty) {
                salida.Error.Mensaje = "Introduzca los campos";
                return Ok(salida); 
            }
            try
            {
                String letra;
                letra = data.Substring(data.Length - 1, 1);
                data = data.Substring(0, data.Length - 1);
                int nifNum = int.Parse(data);
                int resto = nifNum % 23;
                string tmp = getLetra(resto);
                if (tmp.ToLower() != letra.ToLower())
                {
                    salida.Ipbool = false;
                    return Ok(salida);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                salida.Error.Mensaje = ex.Message.ToString();
                salida.Ipbool = false;
                return Ok(salida);
            }
            salida.Ipbool = true;
            return Ok(salida);
        }

/// <summary>
		/// valida el NAFSS de un usuario - /Utilidades/validarNAFSS
		/// </summary>
		/// <param name="dni"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleUtilidadesValidarNAFSSGet</returns>
        public IHttpActionResult GetValidarNAFSS([FromUri] string dni,[FromUri] string restkey)
        {
            MultipleUtilidadesValidarNAFSSGet salida = new MultipleUtilidadesValidarNAFSSGet()
            {
                Error = new Error()
            };

            db = new db();
            if (!db.ComprobarApiKey(restkey))
            {
                salida.Error.Mensaje = "RestKey no coincide.";
                salida.Error.Codigo = 401;
                return Ok(salida);
            }
            salida.Ipbool = false;
            String expresion = "(66|53|50|[0-4][0-9])-?\\d{8}-?\\d{2}";
            if (Regex.IsMatch(dni, expresion))
            {
                if (Regex.Replace(dni, expresion, String.Empty).Length == 0)
                {
                    salida.Ipbool = true;
                }
            }
            return Ok(salida);
        }

/// <summary>
		/// Valida el IBAN de un usuario - /Utilidades/validarIBAN
		/// </summary>
		/// <param name="iban"></param>
		/// <param name="restkey"></param>
		/// <returns>MultipleUtilidadesValidarIBANGet</returns>
        public IHttpActionResult GetValidarIBAN([FromUri] string bankAccount, [FromUri] string restkey)
        {
            // TODO: implement GetValidarIBAN - route: Utilidades/validarIBAN
            // var result = new MultipleUtilidadesValidarIBANGet();
            // return Ok(result);

            MultipleUtilidadesValidarIBANGet salida = new MultipleUtilidadesValidarIBANGet()
            {
                Error = new Error()
            };

            db = new db();
            if (!db.ComprobarApiKey(restkey))
            {
                salida.Error.Mensaje = "RestKey no coincide.";
                salida.Error.Codigo = 401;
                return Ok(salida);
            }

            salida.Ipbool = false;
            bankAccount = bankAccount.ToUpper(); //IN ORDER TO COPE WITH THE REGEX BELOW
            if (String.IsNullOrEmpty(bankAccount))
                return Ok(salida);
            else if (System.Text.RegularExpressions.Regex.IsMatch(bankAccount, "^[A-Z0-9]"))
            {
                bankAccount = bankAccount.Replace(" ", String.Empty);
                string bank =
                bankAccount.Substring(4, bankAccount.Length - 4) + bankAccount.Substring(0, 4);
                int asciiShift = 55;
                StringBuilder sb = new StringBuilder();
                foreach (char c in bank)
                {
                    int v;
                    if (Char.IsLetter(c)) v = c - asciiShift;
                    else v = int.Parse(c.ToString());
                    sb.Append(v);
                }
                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }
                salida.Ipbool = checksum == 1;
                return Ok(salida);
            }
            else
            {
                salida.Ipbool = false;
                return Ok(salida);
            }
        }


        private static string getLetra(int id)
        {
            Dictionary<int, String> letras = new Dictionary<int, string>();
            letras.Add(0, "T");
            letras.Add(1, "R");
            letras.Add(2, "W");
            letras.Add(3, "A");
            letras.Add(4, "G");
            letras.Add(5, "M");
            letras.Add(6, "Y");
            letras.Add(7, "F");
            letras.Add(8, "P");
            letras.Add(9, "D");
            letras.Add(10, "X");
            letras.Add(11, "B");
            letras.Add(12, "N");
            letras.Add(13, "J");
            letras.Add(14, "Z");
            letras.Add(15, "S");
            letras.Add(16, "Q");
            letras.Add(17, "V");
            letras.Add(18, "H");
            letras.Add(19, "L");
            letras.Add(20, "C");
            letras.Add(21, "K");
            letras.Add(22, "E");
            return letras[id];
        }

    }
}
