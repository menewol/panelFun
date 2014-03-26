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
        Random rnd = new Random();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.Red);
            Pen p = new Pen(Color.Yellow, 3);
            try
            {
                g.DrawLine(p, panel1.Width / 3, panel1.Height / 5, panel1.Width / 3 * 2, panel1.Height / 5);
                g.DrawLine(p, panel1.Width / 3, panel1.Height / 5, panel1.Width / 3, panel1.Height / 5 * 3);
                g.DrawLine(p, panel1.Width / 3, panel1.Height / 5 * 3, panel1.Width / 3 * 2, panel1.Height / 5 * 3);

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
            
            }

            for (int i = 0; i < anz; i++)
            {
                people.Add(new Point(rnd.Next(startW, maxW),
                                     rnd.Next(startH, maxH)));
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
    }
}
