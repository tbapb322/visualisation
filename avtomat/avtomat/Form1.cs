using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace avtomat
{
    
    public partial class Form1 : Form
    {       
        Image craw;
        public Form1()
        {
            InitializeComponent();
           
            pictureBox1.Image = craw;
        }
        int time = 0;
        int currentState;

        private void Form1_Load(object sender, EventArgs e)
        {
            currentState = 1;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (currentState == 1 )
            {
                time = 30;
                label3.Text = "Режим: ожидание действия";
                label2.Text = time.ToString();
            }
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            pictureBox2.Left = 375;
            currentState = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Left-20>=0)
                pictureBox1.Left -= 20;
            timer1.Enabled = true;
            currentState = 3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Right + 20 <= 800)
                pictureBox1.Left += 20;
            timer1.Enabled = true;
            currentState = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentState = 1;
            while (pictureBox1.Bottom <= pictureBox2.Bottom)
            {
                pictureBox1.Top += 7;
            }
            pictureBox1.Top += 1;

            if (pictureBox2.Left >= pictureBox1.Left && pictureBox2.Right <= pictureBox1.Right)
            {
                while (pictureBox2.Top >= label3.Bottom)
                {
                    pictureBox2.Top -= 7;
                    pictureBox1.Top -= 7;
                }
                while (pictureBox2.Left >= 0)
                {
                    pictureBox2.Left -= 7;
                    pictureBox1.Left -= 7;
                }
                
                while (pictureBox2.Bottom <= pictureBox3.Bottom)
                {
                    pictureBox2.Top += 7;
                }
                label3.Text = "Режим: ожидание жетона";
                timer1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                label2.Text = "--";
            }
            else
            {
                label3.Text = "Режим: ожидание жетона";
                timer1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                label2.Text = "--";
                while (pictureBox1.Top >= label3.Bottom)
                {
                    pictureBox1.Top -= 5;
                }
                while(pictureBox1.Left >= 0)
                {
                    pictureBox1.Left -= 5;
                }
               
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "режим: управления";
            label2.Text = time.ToString();
            time--;
            if (time <= 0)
            {                
                label3.Text = "Режим: ожидание жетона";
                timer1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                label2.Text = "--";
            }

        }        
    }
}
