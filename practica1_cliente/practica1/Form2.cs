using Newtonsoft.Json;
using practica1.Empleado;
using practica1.Empleado.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace practica1
{
    public partial class Form2 : Form
    {
        private string soapkey = "";
        public Form2(string soapkey)
        {
            InitializeComponent();
            this.soapkey = soapkey;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // API request 
            EmpleadoClient empleado = new EmpleadoClient("http://localhost:2038/");
            PostEmpleadoNuevoQuery restkey = new PostEmpleadoNuevoQuery();
            restkey.RestKey = soapkey;

            var response = await empleado.EmpleadoNuevo.Post(new practica1.Empleado.Models.Empleado
            {
                DNI = textBox2.Text,
                Nombre = textBox3.Text,
                Apellidos = textBox4.Text,
                Direccion = textBox5.Text,
                Poblacion = textBox6.Text,
                Telefono = textBox7.Text,
                Email = textBox8.Text,
                Fecha_nacimiento = dateTimePicker1.Value.Date.ToString(),
                NSS = textBox10.Text,
                IBAN = textBox11.Text,
            }, restkey);

            var stream = await response.RawContent.ReadAsStreamAsync();

            using (var contentStream = await response.RawContent.ReadAsStreamAsync())
            {
                contentStream.Seek(0, SeekOrigin.Begin);
                using (var sr = new StreamReader(contentStream))
                {
                    MultipleEmpleadoNuevoPost result = JsonConvert.DeserializeObject<MultipleEmpleadoNuevoPost>(sr.ReadToEnd());
                    bool guardado = result.Ipbool.Value;
                    if (guardado)
                    {
                        MessageBox.Show("Guardado correctamente. ");
                    }
                    else
                    {
                        string errores = result.Error.Mensaje.ToString();
                        MessageBox.Show(errores);
                    }
                }
            };
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
