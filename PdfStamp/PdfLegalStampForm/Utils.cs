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
using System.Drawing.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class Stamp : Form
    {        
        /// <summary>
        /// Generate image
        /// </summary>
        /// <param name="imagePath">Path of the image</param>
        private void GenerateImage(String imagePath)
        {
            if (String.IsNullOrEmpty(imagePath))
            {
                return;
            }

            System.Drawing.Font font = new System.Drawing.Font(FontFamily.GenericSansSerif, 8);
            List<String> list = new List<string>();
            list.Add(legalText);
            list.Add(dateText);

            Color color;
            if (checkBox_transparent.Checked)
            {
                color = Color.Transparent;
            }
            else
            {
                color = Color.White;
            }

            System.Drawing.Image imagePng = DrawText(list, font, Color.Red, color);
            imagePng.Save(imagePath);

            pictureBox_stamp.ImageLocation = inputImagePath;
        }

        /// <summary>
        /// Get the longest string size from the list
        /// </summary>
        /// <param name="listText">list</param>
        /// <returns>the longest size on the list</returns>
        private static String GetLongestString(List<String> listText)
        {
            String r = String.Empty;
            foreach (String s in listText)
            {
                if (s.Length > r.Length)
                {
                    r = s;
                }
            }
            return r;
        }

        /// <summary>
        /// Draws image with text
        /// </summary>
        /// <param name="listText">list of string to be written</param>
        /// <param name="font">font used to write the text</param>
        /// <param name="textColor">text foreground color</param>
        /// <param name="backColor">text background color</param>
        /// <returns>image with text</returns>
        private static System.Drawing.Image DrawText(List<String> listText, System.Drawing.Font font, Color textColor, Color backColor)
        {
            int width = 0;
            int height = 0;

            System.Drawing.Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            SizeF textSize = drawing.MeasureString(GetLongestString(listText), font);
            img.Dispose();
            drawing.Dispose();

            // final image
            if (textSize.Width > 0)
            {
                width = (int)(textSize.Width + 40);
            }
            else
            {
                width = 58;
            }
            if (textSize.Height > 0)
            {
                height = (int)(textSize.Height * 2 + 30);
            }
            else
            {
                height = 58;
            }

            img = new Bitmap(width, height);
            drawing = Graphics.FromImage(img);

            // paint the background
            drawing.Clear(backColor);

            Brush textBrush = new SolidBrush(textColor);
            drawing.TextRenderingHint = TextRenderingHint.AntiAlias;
            drawing.TranslateTransform(10, 20);
            drawing.RotateTransform(-5);

            int i = 0;
            foreach (String s in listText)
            {
                drawing.DrawString(s, font, textBrush, 0, i);
                i += font.Height + 2;
            }

            if (textSize.Width > 0)
            {
                width = (int)(textSize.Width + 15);
            }
            else
            {
                width = 0;
            }
            if (textSize.Height > 0)
            {
                height = (int)(textSize.Height + 15);
            }
            else
            {
                height = 0;
            }

            System.Drawing.Rectangle rec = new System.Drawing.Rectangle(0, 0, width, height);
            Pen pen = new Pen(textBrush);

            drawing.DrawRectangle(pen, rec);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;
        }

        /// <summary>
        /// Sets default destination file name
        /// </summary>
        /// <param name="pathToSourceFile">source file name path</param>
        /// <returns>Default destination file name</returns>
        private String SetDestinationFile(String pathToSourceFile)
        {
            String fileName = String.Empty;
            fileName = Path.GetFileNameWithoutExtension(pathToSourceFile);
            fileName = fileName + "_stamped.pdf";

            fileName = Path.GetDirectoryName(pathToSourceFile) + @"\" + fileName;

            return fileName;
        }
    }
}
