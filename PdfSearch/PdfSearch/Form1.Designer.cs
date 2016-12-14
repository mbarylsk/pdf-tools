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
            this.button_search = new System.Windows.Forms.Button();
            this.label_folder = new System.Windows.Forms.Label();
            this.label_phrase = new System.Windows.Forms.Label();
            this.label_results = new System.Windows.Forms.Label();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.textBox_phrase = new System.Windows.Forms.TextBox();
            this.button_folder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label_status = new System.Windows.Forms.Label();
            this.checkBox_foundOnly = new System.Windows.Forms.CheckBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.linkLabel_tas = new System.Windows.Forms.LinkLabel();
            this.label_autor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(466, 66);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 40);
            this.button_search.TabIndex = 0;
            this.button_search.Text = "<Search>";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label_folder
            // 
            this.label_folder.AutoSize = true;
            this.label_folder.Location = new System.Drawing.Point(69, 13);
            this.label_folder.Name = "label_folder";
            this.label_folder.Size = new System.Drawing.Size(51, 13);
            this.label_folder.TabIndex = 1;
            this.label_folder.Text = "<Folder:>";
            // 
            // label_phrase
            // 
            this.label_phrase.AutoSize = true;
            this.label_phrase.Location = new System.Drawing.Point(9, 40);
            this.label_phrase.Name = "label_phrase";
            this.label_phrase.Size = new System.Drawing.Size(112, 13);
            this.label_phrase.TabIndex = 2;
            this.label_phrase.Text = "<Phrase to be found:>";
            // 
            // label_results
            // 
            this.label_results.AutoSize = true;
            this.label_results.Location = new System.Drawing.Point(9, 112);
            this.label_results.Name = "label_results";
            this.label_results.Size = new System.Drawing.Size(89, 13);
            this.label_results.TabIndex = 4;
            this.label_results.Text = "<Search results:>";
            // 
            // textBox_folder
            // 
            this.textBox_folder.Location = new System.Drawing.Point(121, 10);
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.Size = new System.Drawing.Size(404, 20);
            this.textBox_folder.TabIndex = 5;
            // 
            // textBox_phrase
            // 
            this.textBox_phrase.Location = new System.Drawing.Point(121, 37);
            this.textBox_phrase.Name = "textBox_phrase";
            this.textBox_phrase.Size = new System.Drawing.Size(404, 20);
            this.textBox_phrase.TabIndex = 6;
            this.textBox_phrase.TextChanged += new System.EventHandler(this.textBox_phrase_TextChanged);
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
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(12, 128);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(610, 274);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "<.pdf document>";
            this.columnHeader1.Width = 469;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "<pages>";
            this.columnHeader2.Width = 127;
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
            this.label_status.Location = new System.Drawing.Point(21, 93);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(0, 13);
            this.label_status.TabIndex = 9;
            // 
            // checkBox_foundOnly
            // 
            this.checkBox_foundOnly.AutoSize = true;
            this.checkBox_foundOnly.Location = new System.Drawing.Point(231, 66);
            this.checkBox_foundOnly.Name = "checkBox_foundOnly";
            this.checkBox_foundOnly.Size = new System.Drawing.Size(115, 17);
            this.checkBox_foundOnly.TabIndex = 10;
            this.checkBox_foundOnly.Text = "<show found only>";
            this.checkBox_foundOnly.UseVisualStyleBackColor = true;
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(547, 66);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 40);
            this.button_clear.TabIndex = 11;
            this.button_clear.Text = "<Clear>";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(547, 412);
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
            this.linkLabel_tas.Location = new System.Drawing.Point(57, 442);
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
            this.label_autor.Location = new System.Drawing.Point(9, 442);
            this.label_autor.Name = "label_autor";
            this.label_autor.Size = new System.Drawing.Size(53, 13);
            this.label_autor.TabIndex = 14;
            this.label_autor.Text = "<Author:>";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(634, 464);
            this.Controls.Add(this.label_autor);
            this.Controls.Add(this.linkLabel_tas);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.checkBox_foundOnly);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_folder);
            this.Controls.Add(this.textBox_phrase);
            this.Controls.Add(this.textBox_folder);
            this.Controls.Add(this.label_results);
            this.Controls.Add(this.label_phrase);
            this.Controls.Add(this.label_folder);
            this.Controls.Add(this.button_search);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "<.pdf searcher>";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Label label_folder;
        private System.Windows.Forms.Label label_phrase;
        private System.Windows.Forms.Label label_results;
        private System.Windows.Forms.TextBox textBox_folder;
        private System.Windows.Forms.TextBox textBox_phrase;
        private System.Windows.Forms.Button button_folder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.CheckBox checkBox_foundOnly;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.LinkLabel linkLabel_tas;
        private System.Windows.Forms.Label label_autor;
    }
}

