using Newtonsoft.Json;
using practica1.Empleado;
using practica1.Empleado.Models;
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
    public partial class Form6 : Form
    {
        private string soapkey = "";
        public Form6(string soapkey)
        {
            InitializeComponent();
            deshabilitarTextBox();
            this.soapkey = soapkey;
        }
        private void deshabilitarTextBox()
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            EmpleadoClient empleado = new EmpleadoClient("http://localhost:2038/");

            GetEmpleadoConsultarQuery param = new GetEmpleadoConsultarQuery();
            param.RestKey = soapkey;
            param.DNI = textBox1.Text;

            var response = await empleado.EmpleadoConsultar.Get(param);

            var stream = await response.RawContent.ReadAsStreamAsync();

            using (var contentStream = await response.RawContent.ReadAsStreamAsync())
            {
                contentStream.Seek(0, SeekOrigin.Begin);
                using (var sr = new StreamReader(contentStream))
                {
                    MultipleEmpleadoConsultarGet salida = JsonConvert.DeserializeObject<MultipleEmpleadoConsultarGet>(sr.ReadToEnd());
                    
                    if (salida.Empleado != null)
                    {
                        textBox2.Text = salida.Empleado.DNI;
                        textBox3.Text = salida.Empleado.Nombre;
                        textBox4.Text = salida.Empleado.Apellidos;
                        textBox5.Text = salida.Empleado.Direccion;
                        textBox6.Text = salida.Empleado.Poblacion;
                        textBox7.Text = salida.Empleado.Telefono;
                        textBox8.Text = salida.Empleado.Email;
                        dateTimePicker1.Text = salida.Empleado.Fecha_nacimiento.ToString();
                        textBox10.Text = salida.Empleado.NSS;
                        textBox11.Text = salida.Empleado.IBAN;
                    }
                    else
                    {
                        MessageBox.Show("Error: \n Codigo: " + salida.Error.Codigo + "\n Mensaje: " + salida.Error.Mensaje);
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
