namespace CSlab4_bookCipher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.richTextBox_Input = new System.Windows.Forms.RichTextBox();
            this.radioButton_Encrypt = new System.Windows.Forms.RadioButton();
            this.radioButton_Decrypt = new System.Windows.Forms.RadioButton();
            this.groupBox_radioButtons_Mode = new System.Windows.Forms.GroupBox();
            this.button_Swap_richBoxes = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label_Output = new System.Windows.Forms.Label();
            this.button_OpenFile = new System.Windows.Forms.Button();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_ClearOutput = new System.Windows.Forms.Button();
            this.label_key = new System.Windows.Forms.RichTextBox();
            this.groupBox_radioButtons_Mode.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox_Input
            // 
            this.richTextBox_Input.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_Input.Location = new System.Drawing.Point(12, 12);
            this.richTextBox_Input.Name = "richTextBox_Input";
            this.richTextBox_Input.Size = new System.Drawing.Size(219, 171);
            this.richTextBox_Input.TabIndex = 0;
            this.richTextBox_Input.Text = "hello world";
            // 
            // radioButton_Encrypt
            // 
            this.radioButton_Encrypt.AutoSize = true;
            this.radioButton_Encrypt.Checked = true;
            this.radioButton_Encrypt.Location = new System.Drawing.Point(6, 19);
            this.radioButton_Encrypt.Name = "radioButton_Encrypt";
            this.radioButton_Encrypt.Size = new System.Drawing.Size(61, 17);
            this.radioButton_Encrypt.TabIndex = 2;
            this.radioButton_Encrypt.TabStop = true;
            this.radioButton_Encrypt.Text = "Encrypt";
            this.radioButton_Encrypt.UseVisualStyleBackColor = true;
            // 
            // radioButton_Decrypt
            // 
            this.radioButton_Decrypt.AutoSize = true;
            this.radioButton_Decrypt.Location = new System.Drawing.Point(6, 42);
            this.radioButton_Decrypt.Name = "radioButton_Decrypt";
            this.radioButton_Decrypt.Size = new System.Drawing.Size(62, 17);
            this.radioButton_Decrypt.TabIndex = 3;
            this.radioButton_Decrypt.Text = "Decrypt";
            this.radioButton_Decrypt.UseVisualStyleBackColor = true;
            // 
            // groupBox_radioButtons_Mode
            // 
            this.groupBox_radioButtons_Mode.Controls.Add(this.radioButton_Decrypt);
            this.groupBox_radioButtons_Mode.Controls.Add(this.radioButton_Encrypt);
            this.groupBox_radioButtons_Mode.Location = new System.Drawing.Point(237, 65);
            this.groupBox_radioButtons_Mode.Name = "groupBox_radioButtons_Mode";
            this.groupBox_radioButtons_Mode.Size = new System.Drawing.Size(73, 72);
            this.groupBox_radioButtons_Mode.TabIndex = 4;
            this.groupBox_radioButtons_Mode.TabStop = false;
            this.groupBox_radioButtons_Mode.Text = "Mode";
            // 
            // button_Swap_richBoxes
            // 
            this.button_Swap_richBoxes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_Swap_richBoxes.BackgroundImage")));
            this.button_Swap_richBoxes.Location = new System.Drawing.Point(236, 143);
            this.button_Swap_richBoxes.Name = "button_Swap_richBoxes";
            this.button_Swap_richBoxes.Size = new System.Drawing.Size(74, 40);
            this.button_Swap_richBoxes.TabIndex = 5;
            this.button_Swap_richBoxes.UseVisualStyleBackColor = true;
            this.button_Swap_richBoxes.Click += new System.EventHandler(this.button_Swap_richBoxes_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label_Output
            // 
            this.label_Output.Location = new System.Drawing.Point(316, 15);
            this.label_Output.Name = "label_Output";
            this.label_Output.Size = new System.Drawing.Size(228, 168);
            this.label_Output.TabIndex = 6;
            this.label_Output.Text = "Output";
            // 
            // button_OpenFile
            // 
            this.button_OpenFile.Location = new System.Drawing.Point(12, 189);
            this.button_OpenFile.Name = "button_OpenFile";
            this.button_OpenFile.Size = new System.Drawing.Size(75, 23);
            this.button_OpenFile.TabIndex = 7;
            this.button_OpenFile.Text = "Open";
            this.button_OpenFile.UseVisualStyleBackColor = true;
            this.button_OpenFile.Click += new System.EventHandler(this.button_OpenFile_Click);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(236, 12);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(74, 47);
            this.button_Start.TabIndex = 4;
            this.button_Start.Text = "START";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_ClearOutput
            // 
            this.button_ClearOutput.Location = new System.Drawing.Point(471, 189);
            this.button_ClearOutput.Name = "button_ClearOutput";
            this.button_ClearOutput.Size = new System.Drawing.Size(75, 23);
            this.button_ClearOutput.TabIndex = 9;
            this.button_ClearOutput.Text = "Clear Output";
            this.button_ClearOutput.UseVisualStyleBackColor = true;
            this.button_ClearOutput.Click += new System.EventHandler(this.button_ClearOutput_Click);
            // 
            // label_key
            // 
            this.label_key.Location = new System.Drawing.Point(93, 189);
            this.label_key.Name = "label_key";
            this.label_key.Size = new System.Drawing.Size(372, 102);
            this.label_key.TabIndex = 10;
            this.label_key.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(558, 303);
            this.Controls.Add(this.label_key);
            this.Controls.Add(this.button_ClearOutput);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.button_OpenFile);
            this.Controls.Add(this.label_Output);
            this.Controls.Add(this.button_Swap_richBoxes);
            this.Controls.Add(this.groupBox_radioButtons_Mode);
            this.Controls.Add(this.richTextBox_Input);
            this.Name = "MainForm";
            this.Text = "Book Cipher";
            this.groupBox_radioButtons_Mode.ResumeLayout(false);
            this.groupBox_radioButtons_Mode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_Input;
        private System.Windows.Forms.RadioButton radioButton_Encrypt;
        private System.Windows.Forms.RadioButton radioButton_Decrypt;
        private System.Windows.Forms.GroupBox groupBox_radioButtons_Mode;
        private System.Windows.Forms.Button button_Swap_richBoxes;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label_Output;
        private System.Windows.Forms.Button button_OpenFile;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_ClearOutput;
        private System.Windows.Forms.RichTextBox label_key;
    }
}

