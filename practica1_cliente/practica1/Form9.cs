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
    public partial class Form9 : Form
    {
        private string soapkey = "";
        public Form9(string soapkey)
        {
            InitializeComponent();
            this.soapkey = soapkey;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SeguridadClient cliente = new SeguridadClient("http://localhost:2038/");
            PostSeguridadAsignarPermisosQuery param = new PostSeguridadAsignarPermisosQuery();
            param.RestKey = soapkey;
            param.DNI = textBox1.Text;
            param.Sala = textBox2.Text;

            var response = await cliente.SeguridadAsignarPermisos.Post("", param);
            var stream = await response.RawContent.ReadAsStreamAsync();

            using (var contentStream = await response.RawContent.ReadAsStreamAsync())
            {
                contentStream.Seek(0, SeekOrigin.Begin);
                using (var sr = new StreamReader(contentStream))
                {
                    MultipleSeguridadAsignarPermisosPost result = JsonConvert.DeserializeObject<MultipleSeguridadAsignarPermisosPost>(sr.ReadToEnd());

                    bool asignado = result.Ipbool.Value;

                    if (asignado)
                        MessageBox.Show("Asignado correctamente.");
                    else
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
