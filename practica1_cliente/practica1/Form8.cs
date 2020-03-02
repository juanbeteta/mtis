using Newtonsoft.Json;
using practica1.Seguridad;
using practica1.Seguridad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica1
{
    public partial class Form8 : Form
    {
        private string soapkey = "";
        public Form8(string soapkey)
        {
            InitializeComponent();
            this.soapkey = soapkey;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SeguridadClient cliente = new SeguridadClient("http://localhost:2038/");
            GetSeguridadObtenerNivelesQuery param = new GetSeguridadObtenerNivelesQuery();
            param.RestKey = soapkey;
            param.DNI = textBox1.Text;

            var response = await cliente.SeguridadObtenerNiveles.Get(param);
            var stream = await response.RawContent.ReadAsStreamAsync();

            using (var contentStream = await response.RawContent.ReadAsStreamAsync())
            {
                contentStream.Seek(0, SeekOrigin.Begin);
                using (var sr = new StreamReader(contentStream))
                {
                    MultipleSeguridadObtenerNivelesGet result = JsonConvert.DeserializeObject<MultipleSeguridadObtenerNivelesGet>(sr.ReadToEnd());

                    var lista = result.Ipstring.ToArray<string>();

                    string salida = "";
                    if (result.Error != null)
                    {
                        salida = "Salas: \n";
                        for (int i = 0; i < lista.Length; i++)
                        {
                            salida += "   * " + lista[i] + "\n";
                        }
                    }
                    else
                    {
                        salida = "Error: \n Codigo: " + result.Error.Codigo + " \n Mensaje: " + result.Error.Mensaje;
                    }

                    label2.Text = salida;
                }
            };
            /*Seguridad.SeguridadService seguridad = new Seguridad.SeguridadService();
           
            string dni = textBox1.Text;
            string errores = "";
            string[] lista = seguridad.obtenerNiveles(dni, this.soapkey, out errores);
            string salida = "";
            if (errores.Equals(""))
            {
                salida = "Salas: \n";
                for (int i = 0; i < lista.Length; i++)
                {
                    salida += "   * " + lista[i] + "\n";
                }
            } else
            {
                salida = "Error: " + errores;
            }

            label2.Text = salida;*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();
        }
    }
}
