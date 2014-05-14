using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace punkte
{
    public partial class Form1 : Form
    {
        List<Point> people = new List<Point>();
        List<Point> passingPoints = new List<Point>();
        Random rnd = new Random();
        Point move = new Point(1, 1);
        List<Rectangle> rectLst = new List<Rectangle>();
        Point ziel;
        bool run = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.Red);
            SolidBrush sbZiel = new SolidBrush(Color.Yellow);
            Pen p = new Pen(Color.Yellow, 3);

            g.DrawLine(p, panel1.Width / 3, panel1.Height / 5, panel1.Width / 3, panel1.Height / 5 * 3);
            g.DrawLine(p, panel1.Width / 3, panel1.Height / 5, panel1.Width / 3 * 2, panel1.Height / 5);
            passingPoints.Add(new Point(panel1.Width / 3 * 2, panel1.Height / 5));            
            g.DrawLine(p, panel1.Width / 3, panel1.Height / 5 * 3, panel1.Width / 3 * 2, panel1.Height / 5 * 3);
            passingPoints.Add(new Point(panel1.Width / 3 * 2, panel1.Height / 5 * 3));
           
            g.FillEllipse(sbZiel, ziel.X, ziel.Y, 5, 5);  

            Rectangle tempRect = new Rectangle(panel1.Width / 3, panel1.Height / 5, (panel1.Width / 3 * 2) - (panel1.Width / 3), (panel1.Height / 5 * 3) - (panel1.Height / 5));

            rectLst.Add(tempRect);
            
            try
            {
                foreach (Point item in people)
                {
                    g.FillEllipse(sb, item.X, item.Y, 5, 5);        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Liste();
        }

        public void Liste()
        {
            listBox1.Items.Clear();
            people.Clear();
            int anz = Convert.ToInt32(textBox1.Text);
            int maxW = panel1.Width;
            int maxH = panel1.Height;
            int startW = 0;
            int startH = 0;

            if (checkBox1.Checked)
            {
                startW = rectLst[0].X;
                startH = rectLst[0].Y;
                maxW = rectLst[0].X + rectLst[0].Width;
                maxH = rectLst[0].Y + rectLst[0].Height;

                for (int i = 0; i < anz; i++)
                {
                    people.Add(new Point(rnd.Next(startW, maxW),
                                         rnd.Next(startH, maxH)));
                }
            }
            else
            { 
                for (int i = 0; i < anz; i++)
                {
                    people.Add(new Point(rnd.Next(0, maxW),
                                         rnd.Next(0, maxH)));
                }
            }
            foreach (Point item in people)
            {
                listBox1.Items.Add(item.X + "/" + item.Y);
            }
            panel1.Invalidate();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Liste();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ziel = new Point(rnd.Next(0, panel1.Width), rnd.Next(0, panel1.Height));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (run)
            {
                case false:
                    timer1.Start();
                    run = true;
                    break;
                case true:
                    timer1.Stop();
                    run = false;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Point> temp = people;
            foreach (Point item in temp)
            {
                Point tempHold = new Point(0, 0);
                    if (item.X > ziel.X)
                    {
                        int z = people.IndexOf(item);
                        people[z] = tempHold = new Point(item.X - 1, item.Y);
                    }
                    if (item.X < ziel.X)
                    {
                        int z = people.IndexOf(item);
                        people[z] = tempHold = new Point(item.X + 1, item.Y);
                    }
               
                    if (item.Y > ziel.Y)
                    {
                        int z = people.IndexOf(tempHold);
                        people[z] = new Point(item.X, item.Y-1);
                    }
                    if (item.Y < ziel.Y)
                    {
                        int z = people.IndexOf(tempHold);
                        people[z] = new Point(item.X, item.Y+1);
                    }
            }
        }
    }
}
