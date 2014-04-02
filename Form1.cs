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
    }
}
