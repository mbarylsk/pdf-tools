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
        /// <summary>
        /// Adding stamp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string inputFile = textBox_sourceFile.Text;
            string outputFile = textBox_destinationFile.Text;

            if (!File.Exists(inputFile))
            {
                label_message.Text = "Error! Source .pdf file does not exist. Please choose a file first.";
                label_message.ForeColor = Color.Red;
                textBox_sourceFile.BackColor = Color.Yellow;
                textBox_legal.BackColor = Color.Empty;
                textBox_date.BackColor = Color.Empty;
                return;
            }

            if (String.IsNullOrEmpty(textBox_legal.Text))
            {
                label_message.Text = "Error! Legal header is empty.";
                label_message.ForeColor = Color.Red;
                textBox_sourceFile.BackColor = Color.Empty;
                textBox_legal.BackColor = Color.Yellow;
                textBox_date.BackColor = Color.Empty;
                return;
            }

            if (String.IsNullOrEmpty(textBox_date.Text))
            {
                label_message.Text = "Error! Date is empty.";
                label_message.ForeColor = Color.Red;
                textBox_sourceFile.BackColor = Color.Empty;
                textBox_legal.BackColor = Color.Empty;
                textBox_date.BackColor = Color.Yellow;
                return;
            }

            textBox_sourceFile.BackColor = Color.Empty;
            textBox_date.BackColor = Color.Empty;
            textBox_legal.BackColor = Color.Empty;

            try
            {
                using (Stream inputPdfStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (Stream inputImageStream = new FileStream(inputImagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (Stream outputPdfStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    if (!String.IsNullOrEmpty(textBox_password.Text))
                    {
                        byte[] password = Encoding.ASCII.GetBytes(textBox_password.Text);
                        var reader = new PdfReader(inputPdfStream, password);
                        var stamper = new PdfStamper(reader, outputPdfStream);

                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(inputImageStream);
                        image.SetAbsolutePosition(float.Parse(textBox_x.Text), float.Parse(textBox_y.Text));

                        if (radioButton_firstOnly.Checked)
                        {
                            var pdfContentByte = stamper.GetOverContent(1);
                            pdfContentByte.AddImage(image);
                        }
                        else if (radioButton_allPages.Checked)
                        {
                            for (int i = 1; i <= reader.NumberOfPages; i++)
                            {
                                var pdfContentByte = stamper.GetOverContent(i);
                                pdfContentByte.AddImage(image);
                            }
                        }
                        stamper.Close();
                    }
                    else
                    {
                        var reader = new PdfReader(inputPdfStream);
                        var stamper = new PdfStamper(reader, outputPdfStream);

                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(inputImageStream);
                        image.SetAbsolutePosition(float.Parse(textBox_x.Text), float.Parse(textBox_y.Text));

                        if (radioButton_firstOnly.Checked)
                        {
                            var pdfContentByte = stamper.GetOverContent(1);
                            pdfContentByte.AddImage(image);
                        }
                        else if (radioButton_allPages.Checked)
                        {
                            for (int i = 1; i <= reader.NumberOfPages; i++)
                            {
                                var pdfContentByte = stamper.GetOverContent(i);
                                pdfContentByte.AddImage(image);
                            }
                        }
                        stamper.Close();
                    }
                }

                if (radioButton_firstOnly.Checked)
                {
                    label_message.Text = "Stamp added to the source file (first page) and saved in the destination file.";
                }
                else if (radioButton_allPages.Checked)
                {
                    label_message.Text = "Stamp added to the source file (all pages) and saved in the destination file.";
                }
                label_message.ForeColor = Color.Green;
            }
            catch (Exception exc)
            {
                label_message.ForeColor = Color.Red;
                label_message.Text = exc.Message;
            }
        }
    }
}
