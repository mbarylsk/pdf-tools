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