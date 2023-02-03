using BookManagerAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagerAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public async Task<Book> Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                return book;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                Book bookDelete = await _context.Books.FindAsync(id);
                _context.Books.Remove(bookDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Book>> Get()
        {
            try
            {
                return await _context.Books.ToListAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Book> Get(int id)
        {
            try
            {
                return await _context.Books.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task Update(Book book)
        {
            try
            {
                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync(); 
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
