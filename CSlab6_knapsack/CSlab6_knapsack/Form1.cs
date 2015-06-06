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

        public mainForm()
        {
            InitializeComponent();
        }

        private void GatherKeys(out int[] privateKey, out int q, out int w, out int r)
        {
            if (!isCoPrime(Convert.ToInt32(textBox_R.Text), Convert.ToInt32(textBox_Q.Text)))
            {
                throw new Exception("r and q must be coprime!");
            }
            calcPublic();
            var parts = textBox_PubKey.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var ints = parts.Select(p => Int32.Parse(p, NumberStyles.Integer)).ToArray();
            privateKey = textBox_PrivKey.Text.Trim(' ').Split(' ').Select(s => Int32.Parse(s)).ToArray();

            w = ints.Sum();

            r = Convert.ToInt32(textBox_R.Text);

            q = Convert.ToInt32(textBox_Q.Text);

            if (q < Convert.ToInt32(label_sikSum.Text))
            {
                throw new Exception("q must be greater than SIK!");
            }
        }

        private void button_Encrypt_Click(object sender, EventArgs e)
        {
            try
            {
                int[] publicKey;
                int w, q, r;
                GatherKeys(out publicKey, out q, out w, out r);

                publicKey = calcPublic();
                var ks = new Knapsack(publicKey, w, q, r);

                String input = readFile(textBoxInput.Text);
                var output = ks.Encrypt(input);
                writeFile(textBoxOutput.Text, output);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                int[] PrivKey;
                int w, q, r;
                GatherKeys(out PrivKey, out q, out w, out r);

                var parts = textBox_PubKey.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                var ks = new Knapsack(PrivKey, w, q, r)
                {
                    secretKey = PrivKey
                };

                String input = readFile(textBoxInput.Text);
                var output = ks.Decrypt(input);
                writeFile(textBoxOutput.Text, output);
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isCoPrime(Int32 a, Int32 b)
        {
            if (a<b)
            {
                var t = b;
                b = a;
                a = t;
            }
            Int32 c = a % b;
            while (c!=0)
            {
                a = b;
                b = c;
                c = a % b;
            };

            if (b == 1)
            {
                return true;
            }

            return false;
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

        private void textBox_PrivKey_Leave(object sender, EventArgs e)
        {
            
            var parts = textBox_PrivKey.Text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 8)
            {
                MessageBox.Show("SIK must be 8-element");
                return;
            }

            try
            {
                var ints = parts.Select(p => Int32.Parse(p, NumberStyles.Integer)).ToArray();

                //check for SIK
                var stepSum = 0;
                for (int i = 0; i < ints.Count(); i++)
                {
                    if (ints[i] <= stepSum)
                    {
                        MessageBox.Show("Private key must be SIK!");
                        return;
                    }

                    stepSum += ints[i];
                }

                var sum = ints.Sum();
                label_sikSum.Text = sum.ToString();
                calcPublic();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong format SIK!");
                textBox_PrivKey.Focus();
            }
        }

        private Int32 [] calcPublic()
        {
            var parts = textBox_PrivKey.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var ints = parts.Select(p => Int32.Parse(p, NumberStyles.Integer)).ToArray();
            //public key - Super Increasing Knapsack
            var publicKey = new int[ints.Length];
            //form secret key General Knapsack
            for (int i = 0; i < ints.Length; i++)
            {

                publicKey[i] = ( ints[i] * (Convert.ToInt32(textBox_R.Text) ) % (Convert.ToInt32(textBox_Q.Text)));
            }

            textBox_PubKey.Text = String.Empty;
            foreach (int t in publicKey)
                textBox_PubKey.Text += t + " ";
            return publicKey;
        }

        private void textBox_Q_Leave(object sender, EventArgs e)
        {
            calcPublic();
        }

        private void textBox_R_Leave(object sender, EventArgs e)
        {
            calcPublic();
        }

        private void textBox_PrivKey_TextChanged(object sender, EventArgs e)
        {
             var parts = textBox_PrivKey.Text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var ints = parts.Select(p => Int32.Parse(p, NumberStyles.Integer)).ToArray();
            //check for SIK
            var stepSum = 0;
            for (int i = 0; i < ints.Count(); i++)
            {
                if (ints[i] <= stepSum)
                {
                    MessageBox.Show("Private key must be SIK!");
                    return;
                }

                stepSum += ints[i];
            }

            var sum = ints.Sum();
            label_sikSum.Text = sum.ToString();
        }

        private void button1_Swap_Click(object sender, EventArgs e)
        {
            var t = textBoxInput.Text;
            textBoxInput.Text = textBoxOutput.Text;
            textBoxOutput.Text = t;

        }

    }

}


