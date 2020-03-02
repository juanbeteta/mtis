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
    public partial class Form3 : Form
    {
        private int privateModificar = 0;
        private string soapkey = "";
        
        //Empleado.EmpleadoService empleado = new Empleado.EmpleadoService();
        public Form3(string soapkey)
        {
            InitializeComponent();
            deshabilitarTextBox();
            button1.Enabled = false;
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

        private void habilitarTextBox()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (privateModificar == 0)
            {
                // enable
                habilitarTextBox();
                privateModificar++;
            }else
            {
                privateModificar = 0;

                // disable
                deshabilitarTextBox();

                // Datos de empleado
                Empleado.Models.Empleado empleado = new Empleado.Models.Empleado();
                empleado.DNI = textBox2.Text;
                empleado.Nombre = textBox3.Text;
                empleado.Apellidos = textBox4.Text;
                empleado.Direccion = textBox5.Text;
                empleado.Poblacion = textBox6.Text;
                empleado.Telefono = textBox7.Text;
                empleado.Email = textBox8.Text;
                empleado.Fecha_nacimiento = dateTimePicker1.Value.Date.ToString();
                empleado.NSS = textBox10.Text;
                empleado.IBAN = textBox11.Text;

                // peticion al servidor
                EmpleadoClient empleadorequest = new EmpleadoClient("http://localhost:2038/");
                PutEmpleadoModificarQuery param = new PutEmpleadoModificarQuery();
                param.RestKey = soapkey;

                var response = await empleadorequest.EmpleadoModificar.Put(empleado, param);
                var stream = await response.RawContent.ReadAsStreamAsync();

                using (var contentStream = await response.RawContent.ReadAsStreamAsync())
                {
                    contentStream.Seek(0, SeekOrigin.Begin);
                    using (var sr = new StreamReader(contentStream))
                    {
                        MultipleEmpleadoModificarPut salida = JsonConvert.DeserializeObject<MultipleEmpleadoModificarPut>(sr.ReadToEnd());
                        bool modificado = salida.Ipbool.Value;
                        if (modificado)
                            MessageBox.Show("Modificado correctamente.");
                        else
                            MessageBox.Show("Error: \n Codigo: " + salida.Error.Codigo + "\n Mensaje: " + salida.Error.Mensaje);

                    }
                };
            }
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

                        button1.Enabled = true;
                        deshabilitarTextBox();
                    }
                    else
                    {
                        button1.Enabled = false;
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        dateTimePicker1.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                        MessageBox.Show("Error: \n Codigo: " + salida.Error.Codigo + "\n Mensaje: " + salida.Error.Mensaje);
                    }

                }
            };
            
            /*string dni, Nombre, Apellidos, Direccion, Poblacion, Telefono, Email, NSS, IBAN, errores="";
            dni = textBox1.Text;
            DateTime Fecha_nacimiento;
            Nombre = "";//empleado.consultar(ref dni, this.soapkey, out Apellidos, out Direccion, out Poblacion, out Telefono, out Email, out Fecha_nacimiento, out NSS, out IBAN, out errores);
           
            if (errores.Equals("")){
               /* textBox2.Text = dni;
                textBox3.Text = Nombre;
                textBox4.Text = Apellidos;
                textBox5.Text = Direccion;
                textBox6.Text = Poblacion;
                textBox7.Text = Telefono;
                textBox8.Text = Email;
                dateTimePicker1.Text = Fecha_nacimiento.ToString();
                textBox10.Text = NSS;
                textBox11.Text = IBAN;

                button1.Enabled = true;

                // disable
                deshabilitarTextBox();
            } else{
                button1.Enabled = false;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                dateTimePicker1.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                MessageBox.Show("Error: " + errores);
               
            }
            */
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
