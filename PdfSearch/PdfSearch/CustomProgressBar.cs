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

public enum ProgressBarDisplayText
{
    Percentage,
    CustomText
}

class CustomProgressBar : ProgressBar
{
    // Property to set to decide whether to print a % or Text
    public ProgressBarDisplayText DisplayStyle { get; set; }

    // Property to hold the custom text
    public String CustomText { get; set; }

    public CustomProgressBar()
    {
        // Modify the ControlStyles flags
        // http://msdn.microsoft.com/en-us/library/system.windows.forms.controlstyles.aspx        
        this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        System.Drawing.Rectangle rect = ClientRectangle;
        Graphics g = e.Graphics;

        ProgressBarRenderer.DrawHorizontalBar(g, rect);
        rect.Inflate(-3, -3);
        if (Value > 0)
        {
            // As we doing this ourselves we need to draw the chunks on the progress bar
            System.Drawing.Rectangle clip = new System.Drawing.Rectangle(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);
            ProgressBarRenderer.DrawHorizontalChunks(g, clip);
        }

        // Set the Display text (Either a % amount or our custom text
        string text = DisplayStyle == ProgressBarDisplayText.Percentage ? Value.ToString() + '%' : CustomText;

        using (System.Drawing.Font f = new System.Drawing.Font(FontFamily.GenericSerif, 10))
        {
            SizeF len = g.MeasureString(text, f);
            // Calculate the location of the text (the middle of progress bar)
            Point location = new Point(Convert.ToInt32((rect.Width / 2) - (len.Width / 2)) + 20, Convert.ToInt32((rect.Height / 2) - (len.Height / 2)) + 3);
            // Draw the custom text
            g.DrawString(text, f, Brushes.Black, location);
        }
    }
}