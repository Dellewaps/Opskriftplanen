using Microsoft.EntityFrameworkCore;
using Opskriftplanen.Data;
using Opskriftplanen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Delete(int Id)
        {
            Category category = _context.Category.Find(Id);
            _context.Category.Remove(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public Category GetById(int Id)
        {
            return _context.Category.Find(Id);
        }

        public void Insert(Category category)
        {
            _context.Category.Add(category);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Disposed(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose(bool dispose)
        {
            dispose = true;
            Dispose(dispose);

            GC.SuppressFinalize(this);
        }
    }
}
