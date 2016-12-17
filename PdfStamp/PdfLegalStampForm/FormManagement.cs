/*
This program is free software; you can redistribute it and/or modify it under the terms of the GNU Affero General Public License version 3 as published by the Free Software Foundation with the addition of the following permission added to Section 15 as permitted in Section 7(a): FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY ITEXT GROUP NV, ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT OF THIRD PARTY RIGHTS
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more details. You should have received a copy of the GNU Affero General Public License along with this program; if not, see http://www.gnu.org/licenses or write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA, 02110-1301 USA, or download the license from the following URL: http://itextpdf.com/terms-of-use/
The interactive user interfaces in modified source and object code versions of this program must display Appropriate Legal Notices, as required under Section 5 of the GNU Affero General Public License.
In accordance with Section 7(b) of the GNU Affero General Public License, you must retain the producer line in every PDF that is created or manipulated using iText.
You can be released from the requirements of the license by purchasing a commercial license. Buying such a license is mandatory as soon as you develop commercial activities involving the iText software without disclosing the source code of your own applications. These activities include: offering paid services to customers as an ASP, serving PDFs on the fly in a web application, shipping iText with a closed source product.
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
