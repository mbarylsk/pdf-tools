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
