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
            
            for (int i = 0; i < anz; i++)
            {
                people.Add(new Point(rnd.Next(0, panel1.Width), rnd.Next(0, panel1.Height)));
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
