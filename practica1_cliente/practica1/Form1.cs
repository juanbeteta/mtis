using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica1
{
    public partial class Form1 : Form
    {
        private string GlobalSoapKey = "";
        //Empleado.EmpleadoService empleado = new Empleado.EmpleadoService();
        public Form1()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2(GlobalSoapKey);
            form.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form = new Form5(GlobalSoapKey);
            form.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3(GlobalSoapKey);
            form.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form = new Form6(GlobalSoapKey);
            form.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form = new Form7(GlobalSoapKey);
            form.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 form = new Form8(GlobalSoapKey);
            form.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 form = new Form9(GlobalSoapKey);
            form.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 form = new Form10(GlobalSoapKey);
            form.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 form = new Form11(GlobalSoapKey);
            form.ShowDialog();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 form = new Form12(GlobalSoapKey);
            form.ShowDialog();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 form = new Form13(GlobalSoapKey);
            form.ShowDialog();
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.GlobalSoapKey = textBox1.Text;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                this.GlobalSoapKey = "123";
                textBox1.Enabled = false;
                button12.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                this.GlobalSoapKey = "";
                textBox1.Enabled = true;
                button12.Enabled = true;
            }
        }
    }
}
