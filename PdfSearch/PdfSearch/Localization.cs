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
    ButtonSearch,
    ButtonExit,
    ButtonClear,
    ButtonCancel,
    TextSearchCompleted,
    TextSearchCompletedPartial,
    TextSearchCompletedNoFiles,
    TextSearchStarted,
    TextSearchResultCleared,
    TextAppName,
    TextFolder,
    TextPhrase,
    TextResults,
    TextCancelling,
    TextShowFoundOnly,
    TextPdfDocument,
    TextPages,
    TextAuthor,
    ErrorMissingFolder,
    ErrorMissingPhrase,
    ErrorNonExistentFolder,
    ErrorException
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
                    case LocalizedItem.ButtonSearch:
                        value = "Szukaj";
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
                    case LocalizedItem.TextSearchCompleted:
                        value = "Zakończyłem przeszukiwanie %i plików.";
                        break;
                    case LocalizedItem.TextSearchCompletedNoFiles:
                        value = "W podanym katalogu nie znalazłem plików .pdf.";
                        break;
                    case LocalizedItem.TextCancelling:
                        value = "Przerywam przeszukiwanie ...";
                        break;
                    case LocalizedItem.TextSearchCompletedPartial:
                        value = "Wyszukiwanie zostało przerwane. Prezentuję częściowe wyniki.";
                        break;
                    case LocalizedItem.TextSearchResultCleared:
                        value = "Wyczyściłem wyniki poprzedniego wyszukiwania.";
                        break;
                    case LocalizedItem.TextSearchStarted:
                        value = "Rozpoczynam przeszukiwanie %i plików .pdf ...";
                        break;
                    case LocalizedItem.TextAppName:
                        value = "Przeszukiwacz .pdfów v. %s";
                        break;
                    case LocalizedItem.TextFolder:
                        value = "Katalog:";
                        break;
                    case LocalizedItem.TextPhrase:
                        value = "Fraza do znalezienia:";
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
                    case LocalizedItem.ErrorMissingPhrase:
                        value = "Błąd. Podaj frazę do znalezienia.";
                        break;
                    case LocalizedItem.ErrorException:
                        value = "Błąd. %s.";
                        break;
                    default:
                        value = String.Empty;
                        break;
                }
                break;
            default:
                switch (item)
                {
                    case LocalizedItem.ButtonSearch:
                        value = "Search";
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
                    case LocalizedItem.TextSearchCompleted:
                        value = "Search in %i files has been completed.";
                        break;
                    case LocalizedItem.TextSearchCompletedNoFiles:
                        value = "No .pdf files found in the given folder.";
                        break;
                    case LocalizedItem.TextCancelling:
                        value = "Cancelling search ...";
                        break;
                    case LocalizedItem.TextSearchCompletedPartial:
                        value = "Search has been canceled. Partial results are presented.";
                        break;
                    case LocalizedItem.TextSearchResultCleared:
                        value = "Previous search results cleared.";
                        break;
                    case LocalizedItem.TextSearchStarted:
                        value = "I am searching through %i .pdf files now ...";
                        break;
                    case LocalizedItem.TextAppName:
                        value = ".pdf searcher v. %s";
                        break;
                    case LocalizedItem.TextFolder:
                        value = "Folder:";
                        break;
                    case LocalizedItem.TextPhrase:
                        value = "Phrase to be found:";
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
                    case LocalizedItem.ErrorMissingPhrase:
                        value = "Error. Please provide a needle to be found in .pdf haystack.";
                        break;
                    case LocalizedItem.ErrorNonExistentFolder:
                        value = "Error. The given folder does not exist or is not readable.";
                        break;
                    case LocalizedItem.ErrorException:
                        value = "Error. No access to %s.";
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