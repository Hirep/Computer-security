namespace CSlab5_DES
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelKey = new System.Windows.Forms.Label();
            this.labelInput = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_Encrypt = new System.Windows.Forms.Button();
            this.button_Decrypt = new System.Windows.Forms.Button();
            this.textBox_PrivKey = new System.Windows.Forms.TextBox();
            this.label_sikSum = new System.Windows.Forms.Label();
            this.button1_Swap = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(12, 14);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(61, 13);
            this.labelKey.TabIndex = 4;
            this.labelKey.Text = "Private Key";
            // 
            // labelInput
            // 
            this.labelInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(195, 82);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(31, 13);
            this.labelInput.TabIndex = 6;
            this.labelInput.Text = "Input";
            // 
            // labelOutput
            // 
            this.labelOutput.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(189, 108);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(39, 13);
            this.labelOutput.TabIndex = 7;
            this.labelOutput.Text = "Output";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxInput.Location = new System.Drawing.Point(226, 79);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(221, 20);
            this.textBoxInput.TabIndex = 8;
            this.textBoxInput.Text = "C:\\Users\\Dima\\Desktop\\in.txt";
            this.textBoxInput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxInput_MouseDown);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxOutput.Location = new System.Drawing.Point(226, 105);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(221, 20);
            this.textBoxOutput.TabIndex = 9;
            this.textBoxOutput.Text = "C:\\Users\\Dima\\Desktop\\out.txt";
            this.textBoxOutput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxOutput_MouseDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 134);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(508, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // button_Encrypt
            // 
            this.button_Encrypt.Location = new System.Drawing.Point(15, 70);
            this.button_Encrypt.Name = "button_Encrypt";
            this.button_Encrypt.Size = new System.Drawing.Size(108, 23);
            this.button_Encrypt.TabIndex = 17;
            this.button_Encrypt.Text = "Encrypt";
            this.button_Encrypt.UseVisualStyleBackColor = true;
            this.button_Encrypt.Click += new System.EventHandler(this.button_Encrypt_Click);
            // 
            // button_Decrypt
            // 
            this.button_Decrypt.Location = new System.Drawing.Point(15, 104);
            this.button_Decrypt.Name = "button_Decrypt";
            this.button_Decrypt.Size = new System.Drawing.Size(108, 23);
            this.button_Decrypt.TabIndex = 18;
            this.button_Decrypt.Text = "Decrypt";
            this.button_Decrypt.UseVisualStyleBackColor = true;
            this.button_Decrypt.Click += new System.EventHandler(this.button_Decrypt_Click);
            // 
            // textBox_PrivKey
            // 
            this.textBox_PrivKey.Location = new System.Drawing.Point(79, 12);
            this.textBox_PrivKey.Name = "textBox_PrivKey";
            this.textBox_PrivKey.Size = new System.Drawing.Size(336, 20);
            this.textBox_PrivKey.TabIndex = 23;
            // 
            // label_sikSum
            // 
            this.label_sikSum.AutoSize = true;
            this.label_sikSum.Location = new System.Drawing.Point(342, 15);
            this.label_sikSum.Name = "label_sikSum";
            this.label_sikSum.Size = new System.Drawing.Size(0, 13);
            this.label_sikSum.TabIndex = 20;
            // 
            // button1_Swap
            // 
            this.button1_Swap.Location = new System.Drawing.Point(453, 79);
            this.button1_Swap.Name = "button1_Swap";
            this.button1_Swap.Size = new System.Drawing.Size(50, 46);
            this.button1_Swap.TabIndex = 21;
            this.button1_Swap.Text = "Swap";
            this.button1_Swap.UseVisualStyleBackColor = true;
            this.button1_Swap.Click += new System.EventHandler(this.button1_Swap_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(508, 156);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button1_Swap);
            this.Controls.Add(this.label_sikSum);
            this.Controls.Add(this.textBox_PrivKey);
            this.Controls.Add(this.button_Decrypt);
            this.Controls.Add(this.button_Encrypt);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.labelKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainForm";
            this.Text = "Knapsack";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button_Encrypt;
        private System.Windows.Forms.Button button_Decrypt;
        private System.Windows.Forms.TextBox textBox_PrivKey;
        private System.Windows.Forms.Label label_sikSum;
        private System.Windows.Forms.Button button1_Swap;
        private System.Windows.Forms.Button button1;
    }
}

