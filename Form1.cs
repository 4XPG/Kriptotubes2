using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kriptotubes2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private String GetFileName(String filter)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = filter;
            open.RestoreDirectory = true;
            if (open.ShowDialog(this) == DialogResult.OK)
            {
                return open.FileName;
            }
            else
            {
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = GetFileName("Text Files (*.txt)|*.txt");
            if (fileName != null)
            {
                textBox1.Text = fileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                String file = textBox1.Text;
                try
                {
                    textBox2.Text = File.ReadAllText(file);
                }
                catch (IOException)
                {
                }
            }
        }

        private String convertToBinary(String s)
        {
            String result = String.Empty;
            if (s.Length > 0)
            {
                foreach (char ch in textBox3.Text)
                {
                    result += Convert.ToString((int)ch, 2);
                }
            }
            else
            {
                result = "0";
            }
            return result;
        }

        private long splitK(String b)
        {
            int part = b.Length / 2;
            int step = b.Length;
            String Z1 = String.Empty;
            String Z2 = String.Empty;
            Z1 += b.Substring(0, part);
            Z2 += b.Substring(part);
            long C1 = Convert.ToInt64(Z1, 2);
            long C2 = Convert.ToInt64(Z2, 2);
            long C3 = C1 + C2;
            return C3;
        }

        private String intToBinary(long C)
        {
            String Z3 = Convert.ToString(C, 2);
            return Z3;
        }

        private String checkBinaryLength(String Z)
        {
            int X = Z.Length;
            int y;
            long V;
            String I = String.Empty;
            if (X > 8)
            {
                y = Z.Length;
                while (y > 8)
                {
                    V = splitK(Z);
                    Z = intToBinary(V);
                    y = Z.Length;
                }
                //I = Z;
            }
            else if (X < 8)
            {
                while(Z.Length < 8)
                    Z += "0";
                //I = Z;
            }
            I = Z;
            return I;
        }

        private String splitPText(String P)
        {
            while (P.Length % 8 != 0)
                P += "0";
            int part = P.Length / 8;
            int step = P.Length;
            String Z1 = String.Empty;
            Z1 += P.Substring(0, 8);
            return Z1;
        }

        private String splitKey(String K)
        {
            while (K.Length % 8 != 0)
                K += "0";
            int part = K.Length / 8;
            int step = K.Length;
            String Z1 = String.Empty;
            Z1 += K.Substring(0, 8);
            return Z1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String a = textBox3.Text;
            textBox4.Text = convertToBinary(a);

            String b = textBox4.Text;
            //int part = b.Length / 2;
            //int step = b.Length;
            //String Z1 = String.Empty;
            //String Z2 = String.Empty;
            //for (int i = 0; i < step; i += part)
            //{
            //    if (i + 2 > step)
            //        part = step - i;
            //Z1 += b.Substring(0, part);
            //Z2 += b.Substring(part);
            //}
            //textBox1.Text = Z1;
            //textBox2.Text = Z2;

            //int C1 = Convert.ToInt32(textBox1.Text, 2);
            //int C2 = Convert.ToInt32(textBox2.Text, 2);
            //textBox3.Text = C1.ToString();
            //textBox4.Text = C2.ToString();
            //int C3 = C1 + C2;
            //textBox2.Text = C3.ToString();

            long C3 = splitK(b);
            String Z3 = Convert.ToString(C3, 2);
            textBox1.Text = Z3;
            textBox1.Text = checkBinaryLength(Z3);
            textBox2.Text = splitPText(b);
        }
    }
}
