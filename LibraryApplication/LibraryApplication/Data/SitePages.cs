using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApplication.Data
{
    public enum LibraryPage
    {
        Home,
        Login,
        Authors,
        AddAuthor,
        EditAuthor,
        Books,
        AddBook,
        EditBook,
        Libraries,
        AddLibrary,
        EditLibrary,
        Librarians,
        AddLibrarian,
        EditLibrarian,
        BookCopies,
        Patrons,
        AddPatron,
        EditPatron
    }
    public static class SitePages
    {
        public static string GetUrl(LibraryPage page)
        {
            switch(page)
            {
                case LibraryPage.Login:
                    return "~/Login.aspx";
                case LibraryPage.Authors:
                    return "~/Authors.aspx";
                case LibraryPage.AddAuthor:
                    return "~/AddAuthor.aspx";
                case LibraryPage.EditAuthor:
                    return "~/EditAuthor.aspx";
                case LibraryPage.Books:
                    return "~/Books.aspx";
                case LibraryPage.AddBook:
                    return "~/AddBook.aspx";
                case LibraryPage.EditBook:
                    return "~/EditBook.aspx";
                case LibraryPage.Libraries:
                    return "~/Libraries.aspx";
                case LibraryPage.AddLibrary:
                    return "~/AddLibrary.aspx";
                case LibraryPage.EditLibrary:
                    return "~/EditLibrary.aspx";
                case LibraryPage.Librarians:
                    return "~/Librarians.aspx";
                case LibraryPage.AddLibrarian:
                    return "~/AddLibrarian.aspx";
                case LibraryPage.EditLibrarian:
                    return "~/EditLibrarian.aspx";
                case LibraryPage.Patrons:
                    return "~/Patrons/List.aspx";
                case LibraryPage.AddPatron:
                    return "~/Patrons/Add.aspx";
                case LibraryPage.EditPatron:
                    return "~/Patrons/Edit.aspx";
                default:
                    return "~/";
            }
        }
    }
}