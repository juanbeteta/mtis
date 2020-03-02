using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using practica1.Utilidades.Models;
using practica1.Empleado.Models;
using practica1.Empleado;
using practica1.Seguridad;
using System.IO;
using practica1.Utilidades;
using Newtonsoft.Json;

namespace practica1
{
    public partial class Form11 : Form
    {
        private string soapkey = "";
        public Form11(string soapkey)
        {
            InitializeComponent();
            this.soapkey = soapkey;
        }
        
        private async void button1_Click(object sender, EventArgs e)
        {

            UtilidadesClient cliente = new UtilidadesClient("http://localhost:2038/");
            GetUtilidadesValidarNIFQuery param = new GetUtilidadesValidarNIFQuery();
            param.RestKey = soapkey;
            param.DNI = textBox1.Text;

            var response = await cliente.UtilidadesValidarNIF.Get(param);
            var stream = await response.RawContent.ReadAsStreamAsync();

            using (var contentStream = await response.RawContent.ReadAsStreamAsync())
            {
                contentStream.Seek(0, SeekOrigin.Begin);
                using (var sr = new StreamReader(contentStream))
                {
                    MultipleUtilidadesValidarNIFGet result = JsonConvert.DeserializeObject<MultipleUtilidadesValidarNIFGet>(sr.ReadToEnd());

                    bool valido = result.Ipbool.Value;

                    if (valido)
                        MessageBox.Show("NIF válido.");
                    else
                    {
                        MessageBox.Show("NIF inválido.");
                        
                    }

                    if(!valido && result.Error.Mensaje != null)
                    {
                        MessageBox.Show("Error: \n Codigo: " + result.Error.Codigo + "\n Mensaje: " + result.Error.Mensaje);
                    }
                }
            }
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
