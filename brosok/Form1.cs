using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;//using System.Drawing
using System.Windows.Forms;
 
namespace Kinulo
{
    
    public partial class Form1 : Form
    {
        double _vx, _vy, _v0, _agile, _h0;
        double _dev = 50;
        int _setka = 0;
        int _koof_Y = 500;
        int _koof_X = 900;
        double G = 9.81;
        public Form1()
        {

            InitializeComponent();

        }

        
        public void Input() { 
        

        
        
        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _v0 = Convert.ToDouble(textBox2.Text)*_dev;
            }
            catch
            {
                textBox2.BackColor = Color.Red;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _setka = Convert.ToInt32(textBox5.Text) * Convert.ToInt32(_dev);
            }
            catch{
                textBox5.BackColor = Color.Red;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _agile = Convert.ToDouble(textBox3.Text);
            }
            catch {
                textBox3.BackColor = Color.Red;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _dev = Convert.ToDouble(textBox4.Text);
            }
            catch {
                textBox4.BackColor = Color.Red;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _h0 = Convert.ToDouble(textBox1.Text)*_dev;
            }
            catch {
                textBox1.BackColor = Color.Red;
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 0), new Point(0, _koof_Y));
            g.DrawLine(new Pen(Brushes.Black, 1), new Point(0, _koof_Y), new Point(_koof_X, _koof_Y)); 

            if (_setka !=0) { // отрисовка сетки

                for (int i = _setka; i < _koof_Y; i = i + _setka) {
                    g.DrawLine(new Pen(Brushes.Gray, 1), new Point(0, _koof_Y-i), new Point(_koof_X, _koof_Y-i));
                   
                }
                for (int i = _setka; i < _koof_X; i = i + _setka)
                {
                   
                    g.DrawLine(new Pen(Brushes.Gray, 1), new Point(i, 0), new Point(i, _koof_Y));
                }

            }


            // Create pen.
        //    Pen blackPen = new Pen(Color.Black, 2);

            // Create rectangle for ellipse.
         //   Rectangle rect = new Rectangle(100, 100, 1, 1);

            // Draw ellipse to screen.
         //   g.DrawRectangle(blackPen, rect);
/*
            for (int i = 0; i < 50; i++) {
                Pen blackPen1 = new Pen(Color.Black, 2);

                Rectangle rect1 = new Rectangle(100, i, 1, 1);

                
                g.DrawRectangle(blackPen1, rect1);

            }
*/



        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;

            if (_agile == 0 || _v0 == 0) //защита от дэбила
            {
                textBox2.BackColor = Color.Red;
                textBox3.BackColor = Color.Red;
            }
            else
            {
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;

                double rad = _agile * (Math.PI / 180.0);

                _vy = (Math.Sin(rad)) * _v0; // играем с тригонометрией и раскладываем скорость по направлениям
                _vx = (Math.Cos(rad)) * _v0;
                int vy = Convert.ToInt32(_vy);
                int vx = Convert.ToInt32(_vx);
                // примимаем _vy/_dev как нормальное значение, тоесть, v0*sin; тож самое и дл косинуса
                double time;
                time = ((_vy/_dev) + Math.Sqrt((_vy / _dev) * (_vy / _dev)) + (2 * G * (_h0/_dev))) / G; //
                textBox6.Text = Convert.ToString(((((_vy / _dev) * (_vy / _dev)) / 2*G) + (_h0/_dev))); // максимальная высота
                textBox7.Text = Convert.ToString(time); 
                textBox8.Text = Convert.ToString(time*(_vx/_dev));  // маскимальная длинна
                Graphics g = pictureBox1.CreateGraphics();
                Pen blackPen1 = new Pen(Color.Black, 2);
                double x = 0, y = 0;
                int i = 0;
                while (0 == 0)
                {
                    Rectangle rect1 = new Rectangle(Convert.ToInt32(x), Convert.ToInt32(_koof_Y - y), 1, 1);
                    Console.Write(x);
                    x = _vx * i;
                    y = (_vy * i) - ((10 * i * i) / 2) + _h0;

                    if (y < 0)
                    {  /// было бы неплохо пофиксить, ибо тут должен отключаться цикл если значение переходят в отрицательный у
                        //upd 1.4 вроде пофиксил, но хз как это тестить
                        break;
                    }

                    try
                    {
                        g.DrawRectangle(blackPen1, rect1);
                    }
                    catch { }
                    i++;
                }
            }
        }
    }
}
