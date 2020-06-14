using FT.Library.Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FT.Library.Core
{
    public class RepositoryAccess
    {
        // Globals
        private LibraryContext libraryContext;

        public RepositoryAccess(LibraryContext context)
        {
            libraryContext = context;
        }

        #region Authors

        public List<Authors> GetAuthors()
        {
            try
            {
                var authors = libraryContext.Authors.ToList();
                return authors;
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public Authors GetAuthorByID(int id)
        {
            try
            {
                var author = libraryContext.Authors.FirstOrDefault(row => row.ID == id);
                return author;
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public bool CreateAuthor(Authors authors)
        {
            try
            {
                libraryContext.Authors.Add(authors);
                int resultAuthor = libraryContext.SaveChanges();

                return resultAuthor == 0 ? false : true;
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public bool UpdateAuthor(Authors authors)
        {
            try
            {
                var author = libraryContext.Authors.FirstOrDefault(row => row.ID == authors.ID);

                if (author != null)
                {
                    author.BirthDay = authors.BirthDay;
                    author.FirstName = authors.FirstName;
                    author.LastName = authors.LastName;
                    int resultAuthor = libraryContext.SaveChanges();

                    return resultAuthor == 0 ? false : true;
                }
                else
                {
                    return false;
                }                
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public bool DeleteAuthor(int id)
        {
            try
            {
                var author = libraryContext.Authors.FirstOrDefault(row => row.ID == id);

                if (author != null)
                {
                    libraryContext.Authors.Remove(author);
                    int resultAuthor = libraryContext.SaveChanges();

                    return resultAuthor == 0 ? false : true;
                }
                else
                {
                    return false;
                }                
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Books

        public List<Books> GetBooks()
        {
            try
            {
                var books = libraryContext.Books.ToList();
                return books;
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public Books GetBookByID(int id)
        {
            try
            {
                var book = libraryContext.Books.FirstOrDefault(row => row.ID == id);
                return book;
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public Books GetBookByName(string name)
        {
            try
            {
                var book = libraryContext.Books.FirstOrDefault(row => row.Name.Contains(name));
                return book;
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public Books GetBookByCategory(int categoryID)
        {
            try
            {
                var book = libraryContext.Books.FirstOrDefault(row => row.Category_ID == categoryID);
                return book;
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public Books GetBookByAuthor(int authorID)
        {
            try
            {
                var book = libraryContext.Books.FirstOrDefault(row => row.Author_ID == authorID);
                return book;
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public bool CreateBook(Books books)
        {
            try
            {
                libraryContext.Books.Add(books);
                int resultBook = libraryContext.SaveChanges();

                return resultBook == 0 ? false : true;
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public bool UpdateBook(Books books)
        {
            try
            {
                var book = libraryContext.Books.FirstOrDefault(row => row.ID == books.ID);

                if (book != null)
                {
                    book.Author_ID = books.Author_ID;
                    book.Category_ID = books.Category_ID;
                    book.ISBN = books.ISBN;
                    book.Name = books.Name;
                    int resultBook = libraryContext.SaveChanges();

                    return resultBook == 0 ? false : true;
                }
                else
                {
                    return false;
                }
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public bool DeleteBook(int id)
        {
            try
            {
                var book = libraryContext.Books.FirstOrDefault(row => row.ID == id);

                if (book != null)
                {
                    libraryContext.Books.Remove(book);
                    int resultBook = libraryContext.SaveChanges();

                    return resultBook == 0 ? false : true;
                }
                else
                {
                    return false;
                }
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Categories

        public List<Categories> GetCategories()
        {
            try
            {
                var categories = libraryContext.Categories.ToList();
                return categories;
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public Categories GetCategoryByID(int id)
        {
            try
            {
                var category = libraryContext.Categories.FirstOrDefault(row => row.ID == id);
                return category;
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public bool CreateCategory(Categories categories)
        {
            try
            {
                libraryContext.Categories.Add(categories);
                int resultCategory = libraryContext.SaveChanges();

                return resultCategory == 0 ? false : true;
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public bool UpdateCategory(Categories categories)
        {
            try
            {
                var category = libraryContext.Categories.FirstOrDefault(row => row.ID == categories.ID);

                if (category != null)
                {
                    category.Description = categories.Description;
                    category.Name = categories.Name;
                    int resultCategory = libraryContext.SaveChanges();

                    return resultCategory == 0 ? false : true;
                }
                else
                {
                    return false;
                }
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                var category = libraryContext.Categories.FirstOrDefault(row => row.ID == id);

                if (category != null)
                {
                    libraryContext.Categories.Remove(category);
                    int resultCategory = libraryContext.SaveChanges();

                    return resultCategory == 0 ? false : true;
                }
                else
                {
                    return false;
                }
            }
            catch (RepositoryAccessException ex)
            {
                throw ex;
            }
        }

        #endregion
    }

    public class RepositoryAccessException : Exception
    {
        public RepositoryAccessException(string message) : base(message)
        {

        }
    }
}
