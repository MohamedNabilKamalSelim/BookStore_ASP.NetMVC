using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositories
{
    public class BookDBRepository : IBookstoreRepository<Book>
    {
        BookstoreDBContext db;
        public BookDBRepository(BookstoreDBContext _db)
        {
            db = _db;
        }
        public void Add(Book entity)
        {
            db.Books.Add(entity);
            Commit();
        }

        public void Delete(int id)
        {
            var book = Find(id);
            db.Books.Remove(book);
            Commit();
        }

        public Book Find(int id)
        {
            var book = db.Books.Include(a => a.Author).SingleOrDefault(b => b.Id == id);
            return book;
        }

        public IList<Book> List()
        {
            return db.Books.Include(a => a.Author).ToList();
        }

        public IList<Book> Search(string term)
        {
            IList<Book> result = db.Books.Include(a => a.Author).Where(b => b.Title.Contains(term)
                                            || b.Description.Contains(term)
                                            || b.Author.FullName.Contains(term)).ToList();
            return result;
        }

        public void Update(int id, Book newBook)
        {
            db.Update(newBook);
            Commit();
        }
        void Commit()
        {
            db.SaveChanges();
        }
    }
}