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
    public partial class Form5 : Form
    {
        private string soapkey = "";
        public Form5(string soapkey)
        {
            InitializeComponent();
            this.soapkey = soapkey;
        }

        private async void button1_Click(object sender, EventArgs e)
        {        
            DialogResult result = MessageBox.Show("Seguro que desea eliminar el usuario?", "Eliminar", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                EmpleadoClient empleado = new EmpleadoClient("http://localhost:2038/");
                PostEmpleadoBorrarQuery restkey = new PostEmpleadoBorrarQuery();
                restkey.RestKey = soapkey;
                restkey.DNI = textBox1.Text;
                var response = await empleado.EmpleadoBorrar.Post("", restkey);

                var stream = await response.RawContent.ReadAsStreamAsync();

                using (var contentStream = await response.RawContent.ReadAsStreamAsync())
                {
                    contentStream.Seek(0, SeekOrigin.Begin);
                    using (var sr = new StreamReader(contentStream))
                    {
                        MultipleEmpleadoNuevoPost salida = JsonConvert.DeserializeObject<MultipleEmpleadoNuevoPost>(sr.ReadToEnd());
                        bool borrado = salida.Ipbool.Value;
                        if (borrado)
                        {
                            MessageBox.Show("Borrado correctamente");

                            this.Hide();
                            Form1 form = new Form1();
                            form.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            string errores = salida.Error.Mensaje;
                            MessageBox.Show("Error al borrar: \n" + errores);
                        }
                    }
                };
            }
            else if (result == DialogResult.No)
            {
                this.Close();
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
