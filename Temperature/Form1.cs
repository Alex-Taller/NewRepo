using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onverter0
{
    public partial class Form1 : Form
    {

        double _t2, _t1;
       

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "C", "K", "F" });
            comboBox2.Items.AddRange(new string[] { "C", "K", "F" });
            button1.Visible = false;
            textBox1.TextChanged += textBox1_TextChanged;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        


 private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try {
                _t1 = Convert.ToDouble(textBox1.Text);
                button1.Visible = true;
            }
            catch {
                textBox1.BackColor = Color.Red;
                button1.Visible = false;
            }
         
        }


 

  private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.BackColor = Color.White;


            if (comboBox1.SelectedIndex == comboBox1.SelectedIndex) { // С в С
                textBox2.Text = textBox1.Text;
                textBox2.BackColor = Color.Green;
                comboBox1.BackColor = Color.White;
            }


            //С
            if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1) { // С в К
                textBox2.Text = Convert.ToString(_t1 + 273);
                textBox2.BackColor = Color.Green;
                comboBox1.BackColor = Color.White;

            }

            if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 2) { // С в F
                textBox2.Text = Convert.ToString((_t1*1.8)+32);
                textBox2.BackColor = Color.Green;
                comboBox1.BackColor = Color.White;

            }
            //K
            
            if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 0){ // K в C
                if (_t1 <= 0)
                {
                    textBox2.Text = "вы больной";
                }
                else
                {
                    textBox2.Text = Convert.ToString(_t1 - 273);

                    textBox2.BackColor = Color.Green;
                    comboBox1.BackColor = Color.White;
                }

            }

            if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 2){ // K в F
                if (_t1 <= 0)
                {
                    textBox2.Text = "вы больной";
                }
                else
                {
                    textBox2.Text = Convert.ToString(((_t1 - 273) * 1.8) + 32);
                    textBox2.BackColor = Color.Green;
                    comboBox1.BackColor = Color.White;
                }
            }

            //F

            if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 0){ // F в C
                textBox2.Text = Convert.ToString((_t1-32)*1.8);
                textBox2.BackColor = Color.Green;
                comboBox1.BackColor = Color.White;

            }

            if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 1){ // F в K
                textBox2.Text = Convert.ToString(((_t1 - 32) * 1.8)+273);
                textBox2.BackColor = Color.Green;
                comboBox1.BackColor = Color.White;

            }








        }



     




















        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

       
    }
}
