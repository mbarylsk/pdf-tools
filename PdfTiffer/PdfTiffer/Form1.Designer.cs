/*
This program is free software; you can redistribute it and/or modify it under the terms of the GNU Affero General Public License version 3 as published by the Free Software Foundation with the addition of the following permission added to Section 15 as permitted in Section 7(a): FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY ITEXT GROUP NV, ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT OF THIRD PARTY RIGHTS
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more details. You should have received a copy of the GNU Affero General Public License along with this program; if not, see http://www.gnu.org/licenses or write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA, 02110-1301 USA, or download the license from the following URL: http://itextpdf.com/terms-of-use/
The interactive user interfaces in modified source and object code versions of this program must display Appropriate Legal Notices, as required under Section 5 of the GNU Affero General Public License.
In accordance with Section 7(b) of the GNU Affero General Public License, you must retain the producer line in every PDF that is created or manipulated using iText.
You can be released from the requirements of the license by purchasing a commercial license. Buying such a license is mandatory as soon as you develop commercial activities involving the iText software without disclosing the source code of your own applications. These activities include: offering paid services to customers as an ASP, serving PDFs on the fly in a web application, shipping iText with a closed source product.
*/

namespace PdfSearch
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_decompose = new System.Windows.Forms.Button();
            this.label_file = new System.Windows.Forms.Label();
            this.label_destFolder = new System.Windows.Forms.Label();
            this.textBox_file = new System.Windows.Forms.TextBox();
            this.textBox_destFolder = new System.Windows.Forms.TextBox();
            this.button_folder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label_status = new System.Windows.Forms.Label();
            this.button_exit = new System.Windows.Forms.Button();
            this.linkLabel_tas = new System.Windows.Forms.LinkLabel();
            this.label_autor = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button_decompose
            // 
            this.button_decompose.Location = new System.Drawing.Point(466, 66);
            this.button_decompose.Name = "button_decompose";
            this.button_decompose.Size = new System.Drawing.Size(75, 40);
            this.button_decompose.TabIndex = 0;
            this.button_decompose.Text = "<Decompose>";
            this.button_decompose.UseVisualStyleBackColor = true;
            this.button_decompose.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label_file
            // 
            this.label_file.AutoSize = true;
            this.label_file.Location = new System.Drawing.Point(9, 13);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(38, 13);
            this.label_file.TabIndex = 1;
            this.label_file.Text = "<File:>";
            // 
            // label_destFolder
            // 
            this.label_destFolder.AutoSize = true;
            this.label_destFolder.Location = new System.Drawing.Point(9, 40);
            this.label_destFolder.Name = "label_destFolder";
            this.label_destFolder.Size = new System.Drawing.Size(104, 13);
            this.label_destFolder.TabIndex = 2;
            this.label_destFolder.Text = "<Destination folder:>";
            // 
            // textBox_file
            // 
            this.textBox_file.Location = new System.Drawing.Point(121, 10);
            this.textBox_file.Name = "textBox_file";
            this.textBox_file.Size = new System.Drawing.Size(404, 20);
            this.textBox_file.TabIndex = 5;
            // 
            // textBox_destFolder
            // 
            this.textBox_destFolder.Location = new System.Drawing.Point(121, 37);
            this.textBox_destFolder.Name = "textBox_destFolder";
            this.textBox_destFolder.Size = new System.Drawing.Size(404, 20);
            this.textBox_destFolder.TabIndex = 6;
            this.textBox_destFolder.TextChanged += new System.EventHandler(this.textBox_phrase_TextChanged);
            // 
            // button_folder
            // 
            this.button_folder.Location = new System.Drawing.Point(531, 8);
            this.button_folder.Name = "button_folder";
            this.button_folder.Size = new System.Drawing.Size(29, 23);
            this.button_folder.TabIndex = 7;
            this.button_folder.Text = "..";
            this.button_folder.UseVisualStyleBackColor = true;
            this.button_folder.Click += new System.EventHandler(this.button_folder_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(21, 80);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(0, 13);
            this.label_status.TabIndex = 9;
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(547, 66);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(75, 40);
            this.button_exit.TabIndex = 12;
            this.button_exit.Text = "<Exit>";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // linkLabel_tas
            // 
            this.linkLabel_tas.AutoSize = true;
            this.linkLabel_tas.Location = new System.Drawing.Point(71, 156);
            this.linkLabel_tas.Name = "linkLabel_tas";
            this.linkLabel_tas.Size = new System.Drawing.Size(118, 13);
            this.linkLabel_tas.TabIndex = 13;
            this.linkLabel_tas.TabStop = true;
            this.linkLabel_tas.Text = "http://www.auto.gda.pl";
            this.linkLabel_tas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_tas_LinkClicked);
            // 
            // label_autor
            // 
            this.label_autor.AutoSize = true;
            this.label_autor.Location = new System.Drawing.Point(12, 156);
            this.label_autor.Name = "label_autor";
            this.label_autor.Size = new System.Drawing.Size(53, 13);
            this.label_autor.TabIndex = 14;
            this.label_autor.Text = "<Author:>";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(633, 179);
            this.Controls.Add(this.label_autor);
            this.Controls.Add(this.linkLabel_tas);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.button_folder);
            this.Controls.Add(this.textBox_destFolder);
            this.Controls.Add(this.textBox_file);
            this.Controls.Add(this.label_destFolder);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.button_decompose);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "<.pdf tiffer>";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_decompose;
        private System.Windows.Forms.Label label_file;
        private System.Windows.Forms.Label label_destFolder;
        private System.Windows.Forms.TextBox textBox_file;
        private System.Windows.Forms.TextBox textBox_destFolder;
        private System.Windows.Forms.Button button_folder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.LinkLabel linkLabel_tas;
        private System.Windows.Forms.Label label_autor;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

