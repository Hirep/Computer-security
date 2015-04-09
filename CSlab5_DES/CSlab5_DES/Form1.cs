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

namespace CSlab5_DES
{
    public partial class mainForm : Form
    {

        public mainForm()
        {
            InitializeComponent();
        }

        

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxKey.Text))
            {
                MessageBox.Show("Enter key");
                return;
            }

            if (String.IsNullOrWhiteSpace(textBoxIV.Text))
            {
                MessageBox.Show("Enter IV");
                return;
            }
            if (String.IsNullOrWhiteSpace(textBoxInput.Text))
            {
                MessageBox.Show("Choose input file");
                return;
            }
            if (String.IsNullOrWhiteSpace(textBoxOutput.Text))
            {
                MessageBox.Show("Choose outputs file");
                return;
            }
            String filePathInput = textBoxInput.Text;
            String filePathOutput = textBoxOutput.Text;

            Stopwatch timer = new Stopwatch();
            timer.Start();
            DES Des = new DES(textBoxKey.Text, textBoxIV.Text, filePathInput,filePathOutput);
            if (radioButtonEncrypt.Checked)
            {
                Des.Encrypt(filePathInput);
            }
            else
            {
                Des.Decrypt(filePathInput);
            }
            timer.Stop();
            toolStripStatusLabel1.Text = "Done in "+timer.Elapsed;
            
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

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKey.Text.Length > 8)
            {
                textBoxKey.Text = textBoxKey.Text.Remove(8);
            }
        }

        private void textBoxIV_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIV.Text.Length > 8)
            {
                textBoxIV.Text = textBoxIV.Text.Remove(8);
            }
        }

        

        

        

       

    }
}
