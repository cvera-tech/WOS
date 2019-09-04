namespace LibraryApplication.Data
{
    public enum LibraryPage
    {
        Home,
        Login,
        NotAuthorized,
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
        EditPatron,
        AccountSettings
    }
    public static class SitePages
    {
        public static string GetUrl(LibraryPage page)
        {
            switch(page)
            {
                case LibraryPage.Home:
                    return "~/";
                case LibraryPage.NotAuthorized:
                    return "~/NotAuthorized.aspx";
                case LibraryPage.Login:
                    return "~/Login.aspx";
                case LibraryPage.Authors:
                    return "~/Pages/Authors/List.aspx";
                case LibraryPage.AddAuthor:
                    return "~/Pages/Authors/Add.aspx";
                case LibraryPage.EditAuthor:
                    return "~/Pages/Authors/Edit.aspx";
                case LibraryPage.Books:
                    return "~/Pages/Books/List.aspx";
                case LibraryPage.AddBook:
                    return "~/Pages/Books/Add.aspx";
                case LibraryPage.EditBook:
                    return "~/Pages/Books/Edit.aspx";
                case LibraryPage.BookCopies:
                    return "~/Pages/Books/Copies.aspx";
                case LibraryPage.Libraries:
                    return "~/Pages/Libraries/List.aspx";
                case LibraryPage.AddLibrary:
                    return "~/Pages/Libraries/Add.aspx";
                case LibraryPage.EditLibrary:
                    return "~/Pages/Libraries/Edit.aspx";
                case LibraryPage.Librarians:
                    return "~/Pages/Librarians/List.aspx";
                case LibraryPage.AddLibrarian:
                    return "~/Pages/Librarians/Add.aspx";
                case LibraryPage.EditLibrarian:
                    return "~/Pages/Librarians/Edit.aspx";
                case LibraryPage.Patrons:
                    return "~/Pages/Patrons/List.aspx";
                case LibraryPage.AddPatron:
                    return "~/Pages/Patrons/Add.aspx";
                case LibraryPage.EditPatron:
                    return "~/Pages/Patrons/Edit.aspx";
                case LibraryPage.AccountSettings:
                    // Placeholder
                    return "~/Pages/Account/ChangePassword.aspx";
                default:
                    return "~/";
            }
        }
    }
}