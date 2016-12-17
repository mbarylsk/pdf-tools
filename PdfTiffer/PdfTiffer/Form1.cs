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
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.pdf.parser;
using System.Runtime.InteropServices;

namespace PdfSearch
{
    public partial class Form1 : Form
    {
       
        private CustomProgressBar customProgressBar1;
        private Localization localization;
        private const String VERSION = "1.0.5";
        private const String NORESULTS = "-";

        public Form1()
        {
            InitializeComponent();
            customProgressBar1 = new CustomProgressBar();
            customProgressBar1.DisplayStyle = ProgressBarDisplayText.Percentage;
            customProgressBar1.Value = 0;
            customProgressBar1.SetBounds(23, 120, 505, 25);
            customProgressBar1.Visible = false;

            localization = new Localization();

            button_exit.Text = localization.GetValueForItem(LocalizedItem.ButtonExit);
            button_decompose.Text = localization.GetValueForItem(LocalizedItem.ButtonDecompose);
            label_file.Text = localization.GetValueForItem(LocalizedItem.TextFile);
            label_destFolder.Text = localization.GetValueForItem(LocalizedItem.TextDestFolder);
            label_autor.Text = localization.GetValueForItem(LocalizedItem.TextAuthor);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                if (!File.Exists(textBox_file.Text))
                {
                    label_status.Text = localization.GetValueForItem(LocalizedItem.ErrorMissingFile);
                    label_status.ForeColor = Color.Red;
                    textBox_file.BackColor = Color.Yellow;
                    textBox_destFolder.BackColor = Color.Empty;
                }
                else
                {
                    if (!Directory.Exists(textBox_destFolder.Text))
                    {
                        label_status.ForeColor = Color.Red;
                        label_status.Text = localization.GetValueForItem(LocalizedItem.ErrorNonExistentFolder);
                        textBox_file.BackColor = Color.Empty;
                        textBox_destFolder.BackColor = Color.Yellow;
                    }
                    else
                    {
                        textBox_file.BackColor = Color.Empty;
                        textBox_destFolder.BackColor = Color.Empty;
                        customProgressBar1.Visible = true;

                        button_decompose.Text = localization.GetValueForItem(LocalizedItem.ButtonCancel);
                        StartThread();
                    }
                }                
            }
            else
            {
                label_status.Text = localization.GetValueForItem(LocalizedItem.TextCancelling);
                CancelThread();
            }
        }

        private void StartThread()
        {
            List<String> filePaths = new List<string>();

            // create one-page pdfs first
            iTextSharp.text.pdf.PdfReader reader = null;
            int currentPage = 1;
            int pageCount = 0;
            String filepath = textBox_file.Text;

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            reader = new iTextSharp.text.pdf.PdfReader(filepath);
            reader.RemoveUnusedObjects();
            pageCount = reader.NumberOfPages;
            string ext = System.IO.Path.GetExtension(filepath);
            for (int i = 1; i <= pageCount; i++)
            {
                iTextSharp.text.pdf.PdfReader reader1 = new iTextSharp.text.pdf.PdfReader(filepath);
                string outfile = filepath.Replace((System.IO.Path.GetFileName(filepath)), (System.IO.Path.GetFileName(filepath).Replace(".pdf", "") + "_" + i.ToString()) + ext);
                reader1.RemoveUnusedObjects();
                iTextSharp.text.Document doc = new iTextSharp.text.Document(reader.GetPageSizeWithRotation(currentPage));
                iTextSharp.text.pdf.PdfCopy pdfCpy = new iTextSharp.text.pdf.PdfCopy(doc, new System.IO.FileStream(outfile, System.IO.FileMode.Create));
                doc.Open();
                for (int j = 1; j <= 1; j++)
                {
                    iTextSharp.text.pdf.PdfImportedPage page = pdfCpy.GetImportedPage(reader1, currentPage);
                    pdfCpy.AddPage(page);
                    currentPage += 1;
                }
                doc.Close();
                pdfCpy.Close();
                reader1.Close();
                reader.Close();
                
                filePaths.Add(outfile);
            }

            DecomposeData decompose = new DecomposeData
            {
                filePathsPdf = filePaths,
                folder = textBox_destFolder.Text
            };

            backgroundWorker1.RunWorkerAsync(decompose);

            label_status.Text = localization.GetValueForItem(LocalizedItem.TextSearchStarted).Replace("%i", filePaths.Count.ToString());
            label_status.ForeColor = Color.Blue;            
        }

        private void CancelThread()
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DecomposeData argumentDecompose = e.Argument as DecomposeData;
            List<String> listFileNames = new List<string>();
            DecomposeResults decomposeResults = new DecomposeResults();
            decomposeResults.notCancelled = true;
            decomposeResults.filePathsPdf = argumentDecompose.filePathsPdf;

            int filesCount = argumentDecompose.filePathsPdf.Count;

            for (int i = 0; i < filesCount; i++)
            {
                if (backgroundWorker1.CancellationPending == true)
                {
                    decomposeResults.notCancelled = false;
                    break;
                }
                else
                {
                    String fileName = argumentDecompose.filePathsPdf[i];
                    String fileNameTiff = fileName + ".tiff";

                    // create tiff
                    ConvertPDFToTIFF(fileName, textBox_destFolder.Text, fileNameTiff);
                    listFileNames.Add(fileNameTiff);                    

                    backgroundWorker1.ReportProgress((i + 1) * 100 / filesCount);
                }
            }
            decomposeResults.filePathsTiff = listFileNames;

            e.Result = decomposeResults;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DecomposeResults results = e.Result as DecomposeResults;
            if (results.filePathsTiff.Count == 0)
            {
                customProgressBar1.Visible = false;
            }
            
            if (results.notCancelled)
            {
                label_status.Text = localization.GetValueForItem(LocalizedItem.TextDecomposeCompleted).Replace("%i", results.filePathsTiff.Count.ToString());
            }
            else
            {
                label_status.Text = localization.GetValueForItem(LocalizedItem.TextDecomposeCompletedPartial);
            }

            // delete temporary files
            foreach (String file in results.filePathsPdf)
            {
                File.Delete(file);
            }

            label_status.ForeColor = Color.Green;
            button_decompose.Enabled = true;
            button_decompose.Text = localization.GetValueForItem(LocalizedItem.ButtonDecompose);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            label_status.Text = localization.GetValueForItem(LocalizedItem.TextSearchResultCleared);
            label_status.ForeColor = Color.Green;
            customProgressBar1.Value = 0;
            customProgressBar1.Visible = false;
            textBox_file.BackColor = Color.Empty;
            textBox_destFolder.BackColor = Color.Empty;
            button_decompose.Enabled = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }

        private void listView1_DoubleClick_1(object sender, EventArgs e)
        {
            //Process.Start(listView1.SelectedItems[0].SubItems[0].Text);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            customProgressBar1.Value = e.ProgressPercentage;
            customProgressBar1.CustomText = e.ProgressPercentage + "%";
        }

        private void button_folder_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox_file.Text = openFileDialog1.FileName;
                    textBox_destFolder.Text = Path.GetDirectoryName(openFileDialog1.FileName);
                    textBox_file.BackColor = Color.Empty;
                    textBox_destFolder.BackColor = Color.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void textBox_phrase_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_destFolder.BackColor == Color.Yellow) && (!String.IsNullOrEmpty(textBox_destFolder.Text)))
            {
                textBox_destFolder.BackColor = Color.Empty;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = localization.GetValueForItem(LocalizedItem.TextAppName).Replace("%s", VERSION);

            // make form non-resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.Controls.Add(customProgressBar1);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void linkLabel_tas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel_tas.Links[linkLabel_tas.Links.IndexOf(e.Link)].Visited = true;
            System.Diagnostics.Process.Start(linkLabel_tas.Text);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GSVersion
        {
            public string product;
            public string copyright;
            public int revision;
            public int revisionDate;
        }
        
        [DllImport("gsdll32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int gsapi_revision(ref GSVersion version, int len);

        [DllImport("gsdll32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int gsapi_new_instance(ref System.IntPtr pinstance, System.IntPtr handle);

        [DllImport("gsdll32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int gsapi_init_with_args(IntPtr pInstance, int argc, [In, Out] string[] argv);

        [DllImport("gsdll32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int gsapi_exit(IntPtr instance);

        [DllImport("gsdll32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern void gsapi_delete_instance(System.IntPtr pinstance);

        public static void getVersion(ref GSVersion version)
        {
            gsapi_revision(ref version, Marshal.SizeOf(version));
        }

        public static void run(string[] argv)
        {
            IntPtr inst = IntPtr.Zero;
            int code = gsapi_new_instance(ref inst, IntPtr.Zero);
            if (code != 0) return;
            code = gsapi_init_with_args(inst, argv.Length, argv);
            gsapi_exit(inst);
            gsapi_delete_instance(inst);
        }
        
        public void ConvertPDFToTIFF(String inputPdfFileName, String outputFolder, String outputFileName)
        {
            GSVersion gsVer = new GSVersion();
            getVersion(ref gsVer);
            // execute this command, to convert pdf to tiff
            string[] argv = { "-q", "-sOutputFile=" + outputFileName, "-dNOPAUSE", "-sDEVICE=tiff24nc", inputPdfFileName, "-c quit" };
            run(argv);
        }

        class DecomposeData
        {
            public List<String> filePathsPdf { get; set; }
            public String folder { get; set; }
        }

        class DecomposeResults
        {
            public List<String> filePathsTiff { get; set; }
            public List<String> filePathsPdf { get; set; }
            public bool notCancelled { get; set; }
        }
    }
}
