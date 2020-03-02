﻿using Newtonsoft.Json;
using practica1.Utilidades;
using practica1.Utilidades.Models;
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
    public partial class Form12 : Form
    {
        private string soapkey = "";
        public Form12(string soapkey)
        {
            InitializeComponent();
            this.soapkey = soapkey;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            UtilidadesClient cliente = new UtilidadesClient("http://localhost:2038/");
            GetUtilidadesValidarIBANQuery param = new GetUtilidadesValidarIBANQuery();
            param.RestKey = soapkey;
            param.DNI = textBox1.Text;

            var response = await cliente.UtilidadesValidarIBAN.Get(param);
            var stream = await response.RawContent.ReadAsStreamAsync();

            using (var contentStream = await response.RawContent.ReadAsStreamAsync())
            {
                contentStream.Seek(0, SeekOrigin.Begin);
                using (var sr = new StreamReader(contentStream))
                {
                    MultipleUtilidadesValidarIBANGet result = JsonConvert.DeserializeObject<MultipleUtilidadesValidarIBANGet>(sr.ReadToEnd());

                    bool valido = result.Ipbool.Value;

                    if (valido)
                        MessageBox.Show("IBAN válido.");
                    else
                    {
                        MessageBox.Show("IBAN inválido.");

                    }

                    if (!valido && result.Error.Mensaje != null)
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
