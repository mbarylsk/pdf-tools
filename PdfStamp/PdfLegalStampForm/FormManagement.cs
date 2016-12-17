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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace WindowsFormsApplication1
{
    public partial class Stamp : Form
    {
        String inputImagePath;
        String legalText;
        String dateText;

        const String VERSION = "1.0.9";

        /// <summary>
        /// Form constructor
        /// </summary>
        public Stamp()
        {
            InitializeComponent();
            textBox_sourceFile.Text = @"";
            legalText = @"Confidential";
            dateText = @"Document valid at " + DateTime.Now.ToShortDateString();
            textBox_legal.Text = legalText;
            textBox_date.Text = dateText;
            textBox_destinationFile.Text = @"";
            textBox_x.Text = "40";
            textBox_y.Text = "750";

            this.Text += " v. " + VERSION;

            inputImagePath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";

            GenerateImage(inputImagePath);
        }

        /// <summary>
        /// Choose source file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_sourceFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog_sourceFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_sourceFile.Text = openFileDialog_sourceFile.FileName;
            }
        }

        /// <summary>
        /// Choose destination file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_destinationFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog_destinationFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_destinationFile.Text = openFileDialog_destinationFile.FileName;
            }
        }

        /// <summary>
        /// Action when legal text is changing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_legal_TextChanged(object sender, EventArgs e)
        {
            legalText = textBox_legal.Text;
            GenerateImage(inputImagePath);
        }

        /// <summary>
        /// Action when date is changing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_date_TextChanged(object sender, EventArgs e)
        {
            dateText = textBox_date.Text;
            GenerateImage(inputImagePath);
        }

        /// <summary>
        /// Exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Stamp.ActiveForm.Close();
        }

        /// <summary>
        /// Action when source file is changing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_sourceFile_TextChanged(object sender, EventArgs e)
        {
            textBox_sourceFile.BackColor = Color.Empty;
            label_message.Text = String.Empty;

            if (File.Exists(textBox_sourceFile.Text))
            {
                textBox_destinationFile.Text = SetDestinationFile(textBox_sourceFile.Text);
            }
        }

        /// <summary>
        /// Action when closing form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                File.Delete(inputImagePath);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Action when transparency checkbox is changing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_transparent_CheckedChanged(object sender, EventArgs e)
        {
            GenerateImage(inputImagePath);
        }

        /// <summary>
        /// Action when form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // make form non-resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        /// <summary>
        /// Action when link is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_tas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel_tas.Links[linkLabel_tas.Links.IndexOf(e.Link)].Visited = true;
            System.Diagnostics.Process.Start(linkLabel_tas.Text);
        }
    }
}
