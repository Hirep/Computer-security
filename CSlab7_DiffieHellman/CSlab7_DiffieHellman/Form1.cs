using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using CryptoBase;
using System.Globalization;

namespace CSlab5_DES
{
    public partial class mainForm : Form
    {
        DiffieHellmanProtocol d;

        public mainForm()
        {
            InitializeComponent();
        }

        private void button_Encrypt_Click(object sender, EventArgs e)
        {
            if (textBox_PrivKey.Text == "")
            {
                MessageBox.Show("Generate secret key!");
                return;
            }
            try
            {
                String input = readFile(textBoxInput.Text);
                var output = d.Encrypt(input);
                writeFile(textBoxOutput.Text, output);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Decrypt_Click(object sender, EventArgs e)
        {
            if (textBox_PrivKey.Text == "")
            {
                MessageBox.Show("Generate secret key!");
                return;
            }
            try
            {
                String input = readFile(textBoxInput.Text);
                var output = d.Decrypt(input);
                writeFile(textBoxOutput.Text, output);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string readFile(string name)
        {
            try
            {
                using (StreamReader sr = new StreamReader(name))
                {
                    String line = sr.ReadToEnd();
                    return line;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File could not be read");
            }
            return null;
        }
        private void writeFile(string name, string text)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(name))
                {
                    sr.Write(text);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File could not written");
            }
        }
        private void textBoxInput_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) // Test result.
            {
                MessageBox.Show("Cannot open file");
            }
            else
            {
                textBoxInput.Text = openFileDialog1.FileName;
            }
        }
        private void textBoxOutput_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) // Test result.
            {
                MessageBox.Show("Cannot open file");
            }
            else
            {
                textBoxOutput.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Swap_Click(object sender, EventArgs e)
        {
            var t = textBoxInput.Text;
            textBoxInput.Text = textBoxOutput.Text;
            textBoxOutput.Text = t;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            d = new DiffieHellmanProtocol();
            textBox_PrivKey.Text = d.getKey();
        }

    }
}
