# TODO

## Required
* ~~Librarian pages~~
* ~~Book copy (possibly separate pages from Book pages)~~
* Patron pages
* Borrow book pages
* Add existing patron as librarian
* Account details page

## Quality of life
* Exception handling!!!
* EditBook custom validator to ensure that something has changed (see EditAuthor)
* Make pages DRYer:
    * Refactor Add/Edit pages to user controls
    * Create separate base classes for List pages, Add pages, and Edit pages.
    * Have a static class with urls for every other page
* Bootstrap styling
* LabeledCheckBox user control (see BookCopies page)
* Better authorization (replace hard-coded checks in page behind)

## BUGS
* Edit Author validation