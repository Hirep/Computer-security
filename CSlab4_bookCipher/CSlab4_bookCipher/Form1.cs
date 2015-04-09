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
using CryptoBase;

namespace CSlab4_bookCipher
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
						
		}

		private void button_OpenFile_Click(object sender, EventArgs e)
		{
			Stream file;
			if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if ((file = openFileDialog1.OpenFile()) != null)
				{
					label_key.Text = File.ReadAllText(openFileDialog1.FileName);
				}
			}
		}

		private void button_Swap_richBoxes_Click(object sender, EventArgs e)
		{
			String temp = label_Output.Text;
			label_Output.Text = richTextBox_Input.Text;
			richTextBox_Input.Text = temp; 
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (label_key.Text == "Choose key")
			{
				MessageBox.Show("Choose key file");
				return;
			}
			if (label_key.Text.Length > 9800)
			{
				MessageBox.Show("Too long key");
				return;
			}
			if (richTextBox_Input.Text == "")
			{
				MessageBox.Show("Enter input text");
				return;
			}
			
			//initialize class
			BookCipher BookCipherObj = new BookCipher(label_key.Text);
			//check radiobtn
			if (radioButton_Encrypt.Checked)
			{
				var Result = BookCipherObj.Encrypt(richTextBox_Input.Text);
				if (Result == "Error code alpha-one")
				{
					MessageBox.Show("Key does not cover all message symbols.\nChoose other key.");
				}
				else
				{
					label_Output.Text = Result;
				}
			}
			else
			{
				foreach (var c in richTextBox_Input.Text)
				{
					if (!Char.IsDigit(c))
					{
						MessageBox.Show("Wrong input format");
						return;
					}
				}
				var Result = BookCipherObj.Decrypt(richTextBox_Input.Text);
				if (Result == "Error code alpha-one")
				{
					MessageBox.Show("Key does not cover all message symbols.\nChoose other key.");
				}
				else
				{
					label_Output.Text = Result;
				}
			}
		}

		private void button_ClearOutput_Click(object sender, EventArgs e)
		{
			label_Output.Text = "";
		}
	}
}
