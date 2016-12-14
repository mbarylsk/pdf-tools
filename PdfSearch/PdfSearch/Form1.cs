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

namespace PdfSearch
{
    public partial class Form1 : Form
    {
        private CustomProgressBar customProgressBar1;
        private Localization localization;
        private const String VERSION = "1.0.15";
        private const String NORESULTS = "-";

        public Form1()
        {
            InitializeComponent();
            customProgressBar1 = new CustomProgressBar();
            customProgressBar1.DisplayStyle = ProgressBarDisplayText.Percentage;
            customProgressBar1.Value = 0;
            customProgressBar1.SetBounds(23, 414, 505, 25);
            customProgressBar1.Visible = false;

            localization = new Localization();

            button_exit.Text = localization.GetValueForItem(LocalizedItem.ButtonExit);
            button_clear.Text = localization.GetValueForItem(LocalizedItem.ButtonClear);
            button_search.Text = localization.GetValueForItem(LocalizedItem.ButtonSearch);
            label_folder.Text = localization.GetValueForItem(LocalizedItem.TextFolder);
            label_phrase.Text = localization.GetValueForItem(LocalizedItem.TextPhrase);
            label_results.Text = localization.GetValueForItem(LocalizedItem.TextResults);
            label_autor.Text = localization.GetValueForItem(LocalizedItem.TextAuthor);
            checkBox_foundOnly.Text = localization.GetValueForItem(LocalizedItem.TextShowFoundOnly);
            listView1.Columns[0].Text = localization.GetValueForItem(LocalizedItem.TextPdfDocument);
            listView1.Columns[1].Text = localization.GetValueForItem(LocalizedItem.TextPages);
        }

        private List<int> ReadPdfFile(string fileName, String searthText)
        {
            List<int> pages = new List<int>();
            if (File.Exists(fileName))
            {
                PdfReader pdfReader = new PdfReader(fileName);
                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                    string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                    if (currentPageText.Contains(searthText))
                    {
                        pages.Add(page);
                    }
                }
                pdfReader.Close();
            }
            return pages;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                if (!String.IsNullOrEmpty(textBox_folder.Text))
                {
                    if (String.IsNullOrEmpty(textBox_phrase.Text))
                    {
                        label_status.Text = localization.GetValueForItem(LocalizedItem.ErrorMissingPhrase);
                        label_status.ForeColor = Color.Red;
                        textBox_folder.BackColor = Color.Empty;
                        textBox_phrase.BackColor = Color.Yellow;
                        button_clear.Enabled = true;
                    }
                    else
                    {
                        if (!Directory.Exists(textBox_folder.Text))
                        {
                            label_status.ForeColor = Color.Red;
                            label_status.Text = localization.GetValueForItem(LocalizedItem.ErrorNonExistentFolder);
                        }
                        else
                        {
                            button_clear.Enabled = false;
                            textBox_folder.BackColor = Color.Empty;
                            textBox_phrase.BackColor = Color.Empty;
                            customProgressBar1.Visible = true;

                            button_clear.Enabled = false;
                            button_search.Text = localization.GetValueForItem(LocalizedItem.ButtonCancel);
                            listView1.Items.Clear();
                            StartThread();
                        }
                    }
                }
                else
                {
                    label_status.Text = localization.GetValueForItem(LocalizedItem.ErrorMissingFolder);
                    label_status.ForeColor = Color.Red;
                    textBox_folder.BackColor = Color.Yellow;
                    textBox_phrase.BackColor = Color.Empty;
                    button_clear.Enabled = true;
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
            string[] filePaths = null;
            try
            {
                filePaths = Directory.GetFiles(textBox_folder.Text, "*.pdf", SearchOption.AllDirectories);
            }
            catch (UnauthorizedAccessException e)
            {
                label_status.Text = localization.GetValueForItem(LocalizedItem.ErrorException).Replace("%s", e.Message);
                label_status.ForeColor = Color.Red;
                customProgressBar1.Visible = false;
                button_search.Text = localization.GetValueForItem(LocalizedItem.ButtonSearch);
                textBox_folder.BackColor = Color.Yellow;
            }
            if (filePaths != null)
            {
                label_status.Text = localization.GetValueForItem(LocalizedItem.TextSearchStarted).Replace("%i", filePaths.Length.ToString());
                label_status.ForeColor = Color.Blue;

                SearchData search = new SearchData
                {
                    filePaths = filePaths,
                    searchText = textBox_phrase.Text
                };
                backgroundWorker1.RunWorkerAsync(search);
            }
        }

        private void CancelThread()
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SearchData argumentSearch = e.Argument as SearchData;
            List<String> listFileNames = new List<string>();
            List<String> listPages = new List<string>();
            SearchResults searchResults = new SearchResults();
            searchResults.notCancelled = true;

            int filesCount = argumentSearch.filePaths.Length;

            for (int i = 0; i < filesCount; i++)
            {
                if (backgroundWorker1.CancellationPending == true)
                {
                    searchResults.notCancelled = false;
                    break;
                }
                else
                {
                    String fileName = argumentSearch.filePaths[i];

                    List<int> results = ReadPdfFile(fileName, argumentSearch.searchText);

                    String pages = String.Empty;
                    foreach (int j in results)
                    {
                        if (!String.IsNullOrEmpty(pages))
                        {
                            pages += ",";
                        }
                        pages += j.ToString();
                    }

                    if (String.IsNullOrEmpty(pages))
                    {
                        pages = NORESULTS;
                    }

                    listFileNames.Add(fileName);
                    listPages.Add(pages);

                    backgroundWorker1.ReportProgress((i + 1) * 100 / filesCount);
                }
            }

            searchResults.fileNames = listFileNames;
            searchResults.pages = listPages;

            e.Result = searchResults;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SearchResults results = e.Result as SearchResults;
            if (results.fileNames.Count == 0)
            {
                customProgressBar1.Visible = false;
            }

            for (int i = 0; i < results.fileNames.Count; i++)
            {
                bool add = false;
                if (checkBox_foundOnly.Checked)
                {
                    if (results.pages[i] == NORESULTS)
                    {
                        add = false;
                    }
                    else
                    {
                        add = true;
                    }
                }
                else
                {
                    add = true;
                }

                if (add)
                {
                    string[] row = { results.fileNames[i], results.pages[i] };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
            }

            if (results.fileNames.Count == 0)
            {
                label_status.Text = localization.GetValueForItem(LocalizedItem.TextSearchCompletedNoFiles);
            }
            else if (results.notCancelled)
            {
                label_status.Text = localization.GetValueForItem(LocalizedItem.TextSearchCompleted).Replace("%i", results.fileNames.Count.ToString());
            }
            else
            {
                label_status.Text = localization.GetValueForItem(LocalizedItem.TextSearchCompletedPartial);
            }
            label_status.ForeColor = Color.Green;
            button_search.Enabled = true;
            button_clear.Enabled = true;
            button_search.Text = localization.GetValueForItem(LocalizedItem.ButtonSearch);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            label_status.Text = localization.GetValueForItem(LocalizedItem.TextSearchResultCleared);
            label_status.ForeColor = Color.Green;
            customProgressBar1.Value = 0;
            customProgressBar1.Visible = false;
            textBox_folder.BackColor = Color.Empty;
            textBox_phrase.BackColor = Color.Empty;
            button_search.Enabled = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }

        private void listView1_DoubleClick_1(object sender, EventArgs e)
        {
            Process.Start(listView1.SelectedItems[0].SubItems[0].Text);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            customProgressBar1.Value = e.ProgressPercentage;
            customProgressBar1.CustomText = e.ProgressPercentage + "%";
        }

        private void button_folder_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_folder.Text = folderBrowserDialog1.SelectedPath;
                textBox_folder.BackColor = Color.Empty;
                textBox_phrase.BackColor = Color.Empty;
            }
        }

        private void textBox_phrase_TextChanged(object sender, EventArgs e)
        {
            if ((textBox_phrase.BackColor == Color.Yellow) && (!String.IsNullOrEmpty(textBox_phrase.Text)))
            {
                textBox_phrase.BackColor = Color.Empty;
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
    }

    class SearchData
    {
        public string[] filePaths { get; set; }
        public String searchText { get; set; }
    }

    class SearchResults
    {
        public List<String> fileNames { get; set; }
        public List<String> pages { get; set; }
        public bool notCancelled { get; set; }
    }
}
