/*
Copyright (C) 2015-2016  Marcin Barylski

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace WindowsFormsApplication1
{
    partial class Stamp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stamp));
            this.openFileDialog_sourceFile = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog_destinationFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel_tas = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.label_message = new System.Windows.Forms.Label();
            this.label_results = new System.Windows.Forms.Label();
            this.checkBox_transparent = new System.Windows.Forms.CheckBox();
            this.pictureBox_stamp = new System.Windows.Forms.PictureBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_legal = new System.Windows.Forms.TextBox();
            this.textBox_date = new System.Windows.Forms.TextBox();
            this.button_destinationFile = new System.Windows.Forms.Button();
            this.button_sourceFile = new System.Windows.Forms.Button();
            this.textBox_destinationFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_sourceFile = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton_firstOnly = new System.Windows.Forms.RadioButton();
            this.radioButton_allPages = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_stamp)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog_sourceFile
            // 
            this.openFileDialog_sourceFile.Filter = "(.pdf files)|*.pdf";
            // 
            // openFileDialog_destinationFile
            // 
            this.openFileDialog_destinationFile.Filter = "(.pdf files)|*.pdf";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_allPages);
            this.groupBox1.Controls.Add(this.radioButton_firstOnly);
            this.groupBox1.Controls.Add(this.linkLabel_tas);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_x);
            this.groupBox1.Controls.Add(this.textBox_y);
            this.groupBox1.Controls.Add(this.label_message);
            this.groupBox1.Controls.Add(this.label_results);
            this.groupBox1.Controls.Add(this.checkBox_transparent);
            this.groupBox1.Controls.Add(this.pictureBox_stamp);
            this.groupBox1.Controls.Add(this.textBox_password);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_legal);
            this.groupBox1.Controls.Add(this.textBox_date);
            this.groupBox1.Controls.Add(this.button_destinationFile);
            this.groupBox1.Controls.Add(this.button_sourceFile);
            this.groupBox1.Controls.Add(this.textBox_destinationFile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(0, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 274);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // linkLabel_tas
            // 
            this.linkLabel_tas.AutoSize = true;
            this.linkLabel_tas.Location = new System.Drawing.Point(53, 256);
            this.linkLabel_tas.Name = "linkLabel_tas";
            this.linkLabel_tas.Size = new System.Drawing.Size(118, 13);
            this.linkLabel_tas.TabIndex = 19;
            this.linkLabel_tas.TabStop = true;
            this.linkLabel_tas.Text = "http://www.auto.gda.pl";
            this.linkLabel_tas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_tas_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Preview:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Author:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(424, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "Stamp";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(468, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(401, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "X:";
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(424, 147);
            this.textBox_x.MaxLength = 3;
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(35, 20);
            this.textBox_x.TabIndex = 16;
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(491, 147);
            this.textBox_y.MaxLength = 3;
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(35, 20);
            this.textBox_y.TabIndex = 15;
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Location = new System.Drawing.Point(14, 236);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(0, 13);
            this.label_message.TabIndex = 14;
            // 
            // label_results
            // 
            this.label_results.AutoSize = true;
            this.label_results.Location = new System.Drawing.Point(239, 188);
            this.label_results.Name = "label_results";
            this.label_results.Size = new System.Drawing.Size(0, 13);
            this.label_results.TabIndex = 13;
            // 
            // checkBox_transparent
            // 
            this.checkBox_transparent.AutoSize = true;
            this.checkBox_transparent.Location = new System.Drawing.Point(316, 149);
            this.checkBox_transparent.Name = "checkBox_transparent";
            this.checkBox_transparent.Size = new System.Drawing.Size(79, 17);
            this.checkBox_transparent.TabIndex = 12;
            this.checkBox_transparent.Text = "transparent";
            this.checkBox_transparent.UseVisualStyleBackColor = true;
            this.checkBox_transparent.CheckedChanged += new System.EventHandler(this.checkBox_transparent_CheckedChanged);
            // 
            // pictureBox_stamp
            // 
            this.pictureBox_stamp.Location = new System.Drawing.Point(81, 144);
            this.pictureBox_stamp.Name = "pictureBox_stamp";
            this.pictureBox_stamp.Size = new System.Drawing.Size(215, 71);
            this.pictureBox_stamp.TabIndex = 11;
            this.pictureBox_stamp.TabStop = false;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(287, 39);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(200, 20);
            this.textBox_password.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Source .pdf file password (optional):";
            // 
            // textBox_legal
            // 
            this.textBox_legal.Location = new System.Drawing.Point(112, 65);
            this.textBox_legal.MaxLength = 28;
            this.textBox_legal.Name = "textBox_legal";
            this.textBox_legal.Size = new System.Drawing.Size(200, 20);
            this.textBox_legal.TabIndex = 2;
            this.textBox_legal.TextChanged += new System.EventHandler(this.textBox_legal_TextChanged);
            // 
            // textBox_date
            // 
            this.textBox_date.Location = new System.Drawing.Point(112, 92);
            this.textBox_date.MaxLength = 28;
            this.textBox_date.Name = "textBox_date";
            this.textBox_date.Size = new System.Drawing.Size(200, 20);
            this.textBox_date.TabIndex = 3;
            this.textBox_date.TextChanged += new System.EventHandler(this.textBox_date_TextChanged);
            // 
            // button_destinationFile
            // 
            this.button_destinationFile.Location = new System.Drawing.Point(493, 116);
            this.button_destinationFile.Name = "button_destinationFile";
            this.button_destinationFile.Size = new System.Drawing.Size(33, 23);
            this.button_destinationFile.TabIndex = 8;
            this.button_destinationFile.Text = "..";
            this.button_destinationFile.UseVisualStyleBackColor = true;
            this.button_destinationFile.Click += new System.EventHandler(this.button_destinationFile_Click);
            // 
            // button_sourceFile
            // 
            this.button_sourceFile.Location = new System.Drawing.Point(493, 13);
            this.button_sourceFile.Name = "button_sourceFile";
            this.button_sourceFile.Size = new System.Drawing.Size(33, 23);
            this.button_sourceFile.TabIndex = 7;
            this.button_sourceFile.Text = "..";
            this.button_sourceFile.UseVisualStyleBackColor = true;
            this.button_sourceFile.Click += new System.EventHandler(this.button_sourceFile_Click);
            // 
            // textBox_destinationFile
            // 
            this.textBox_destinationFile.Location = new System.Drawing.Point(112, 118);
            this.textBox_destinationFile.Name = "textBox_destinationFile";
            this.textBox_destinationFile.Size = new System.Drawing.Size(375, 20);
            this.textBox_destinationFile.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Destination .pdf file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Legal header:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Source .pdf file:";
            // 
            // textBox_sourceFile
            // 
            this.textBox_sourceFile.Location = new System.Drawing.Point(112, 13);
            this.textBox_sourceFile.Name = "textBox_sourceFile";
            this.textBox_sourceFile.Size = new System.Drawing.Size(375, 20);
            this.textBox_sourceFile.TabIndex = 0;
            this.textBox_sourceFile.TextChanged += new System.EventHandler(this.textBox_sourceFile_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_sourceFile);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 274);
            this.panel1.TabIndex = 0;
            // 
            // radioButton_firstOnly
            // 
            this.radioButton_firstOnly.AutoSize = true;
            this.radioButton_firstOnly.Checked = true;
            this.radioButton_firstOnly.Location = new System.Drawing.Point(404, 66);
            this.radioButton_firstOnly.Name = "radioButton_firstOnly";
            this.radioButton_firstOnly.Size = new System.Drawing.Size(93, 17);
            this.radioButton_firstOnly.TabIndex = 21;
            this.radioButton_firstOnly.TabStop = true;
            this.radioButton_firstOnly.Text = "First page only";
            this.radioButton_firstOnly.UseVisualStyleBackColor = true;
            // 
            // radioButton_allPages
            // 
            this.radioButton_allPages.AutoSize = true;
            this.radioButton_allPages.Location = new System.Drawing.Point(404, 89);
            this.radioButton_allPages.Name = "radioButton_allPages";
            this.radioButton_allPages.Size = new System.Drawing.Size(68, 17);
            this.radioButton_allPages.TabIndex = 22;
            this.radioButton_allPages.Text = "All pages";
            this.radioButton_allPages.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 292);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = ".pdf Legal Stamper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_stamp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog_sourceFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog_destinationFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_results;
        private System.Windows.Forms.CheckBox checkBox_transparent;
        private System.Windows.Forms.PictureBox pictureBox_stamp;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_legal;
        private System.Windows.Forms.TextBox textBox_date;
        private System.Windows.Forms.Button button_destinationFile;
        private System.Windows.Forms.Button button_sourceFile;
        private System.Windows.Forms.TextBox textBox_destinationFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_sourceFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel_tas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButton_allPages;
        private System.Windows.Forms.RadioButton radioButton_firstOnly;
    }
}

