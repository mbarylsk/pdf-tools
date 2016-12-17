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
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

public enum LocalizedItem
{
    ButtonDecompose,
    ButtonExit,
    ButtonClear,
    ButtonCancel,
    TextDecomposeCompleted,
    TextDecomposeCompletedPartial,    
    TextSearchStarted,
    TextSearchResultCleared,
    TextAppName,
    TextFile,
    TextDestFolder,
    TextResults,
    TextCancelling,
    TextShowFoundOnly,
    TextPdfDocument,
    TextPages,
    TextAuthor,
    ErrorMissingFolder,
    ErrorMissingFile,
    ErrorNonExistentFolder
}

class Localization
{
    private CultureInfo culture { get; set; }

    public Localization()
    {
        culture = Thread.CurrentThread.CurrentCulture;
    }

    public String GetValueForItem(LocalizedItem item)
    {
        String value = String.Empty;
        switch (culture.Name)
        {
            case "pl-PL":
                switch (item)
                {
                    case LocalizedItem.ButtonDecompose:
                        value = "Podziel";
                        break;
                    case LocalizedItem.ButtonExit:
                        value = "Wyjdź";
                        break;
                    case LocalizedItem.ButtonClear:
                        value = "Wyczyść";
                        break;
                    case LocalizedItem.ButtonCancel:
                        value = "Przerwij";
                        break;
                    case LocalizedItem.TextDecomposeCompleted:
                        value = "Zakończyłem dzielenie %i. stronicowego pliku.";
                        break;
                    case LocalizedItem.TextCancelling:
                        value = "Przerywam dzielenie ...";
                        break;
                    case LocalizedItem.TextDecomposeCompletedPartial:
                        value = "Dzielenie zostało przerwane. Wyniki dostępne częściowo.";
                        break;
                    case LocalizedItem.TextSearchResultCleared:
                        value = "Wyczyściłem wyniki poprzedniego wyszukiwania.";
                        break;
                    case LocalizedItem.TextSearchStarted:
                        value = "Rozpoczynam dekompozycję %i. stronicowego pliku .pdf ...";
                        break;
                    case LocalizedItem.TextAppName:
                        value = "Tiffer .pdfów v. %s";
                        break;
                    case LocalizedItem.TextFile:
                        value = "Plik wejściowy:";
                        break;
                    case LocalizedItem.TextDestFolder:
                        value = "Katalog wynikowy:";
                        break;
                    case LocalizedItem.TextResults:
                        value = "Wyniki szukania:";
                        break;
                    case LocalizedItem.TextShowFoundOnly:
                        value = "pokaż tylko znalezione";
                        break;
                    case LocalizedItem.TextPdfDocument:
                        value = "dokument .pdf";
                        break;
                    case LocalizedItem.TextPages:
                        value = "strony";
                        break;
                    case LocalizedItem.TextAuthor:
                        value = "Autor:";
                        break;
                    case LocalizedItem.ErrorMissingFolder:
                        value = "Błąd. Wskaż katalog do przeszukania.";
                        break;
                    case LocalizedItem.ErrorNonExistentFolder:
                        value = "Błąd. Podany katalog nie istnieje lub nie jest dostępny do odczytu.";
                        break;
                    case LocalizedItem.ErrorMissingFile:
                        value = "Błąd. Podaj plik .pdf do rozłożenia.";
                        break;
                    default:
                        value = String.Empty;
                        break;
                }
                break;
            default:
                switch (item)
                {
                    case LocalizedItem.ButtonDecompose:
                        value = "Decompose";
                        break;
                    case LocalizedItem.ButtonExit:
                        value = "Exit";
                        break;
                    case LocalizedItem.ButtonClear:
                        value = "Clear";
                        break;
                    case LocalizedItem.ButtonCancel:
                        value = "Cancel";
                        break;
                    case LocalizedItem.TextDecomposeCompleted:
                        value = "Decompose of %i page file has been completed.";
                        break;
                    case LocalizedItem.TextCancelling:
                        value = "Cancelling decompose...";
                        break;
                    case LocalizedItem.TextDecomposeCompletedPartial:
                        value = "Decompose has been canceled. Partial results are available.";
                        break;
                    case LocalizedItem.TextSearchResultCleared:
                        value = "Previous search results cleared.";
                        break;
                    case LocalizedItem.TextSearchStarted:
                        value = "I am decomposing %i page .pdf file now ...";
                        break;
                    case LocalizedItem.TextAppName:
                        value = ".pdf tiffer v. %s";
                        break;
                    case LocalizedItem.TextFile:
                        value = "Input file:";
                        break;
                    case LocalizedItem.TextDestFolder:
                        value = "Output folder:";
                        break;
                    case LocalizedItem.TextResults:
                        value = "Search results:";
                        break;
                    case LocalizedItem.TextShowFoundOnly:
                        value = "show found only";
                        break;
                    case LocalizedItem.TextPdfDocument:
                        value = ".pdf document";
                        break;
                    case LocalizedItem.TextPages:
                        value = "pages";
                        break;
                    case LocalizedItem.TextAuthor:
                        value = "Author:";
                        break;
                    case LocalizedItem.ErrorMissingFolder:
                        value = "Error. Please provide a folder to be searched.";
                        break;
                    case LocalizedItem.ErrorMissingFile:
                        value = "Error. Please provide .pdf file to decompose.";
                        break;
                    case LocalizedItem.ErrorNonExistentFolder:
                        value = "Error. The given folder does not exist or is not readable.";
                        break;
                    default:
                        value = String.Empty;
                        break;
                }
                break;
        }
        return value;
    }
}