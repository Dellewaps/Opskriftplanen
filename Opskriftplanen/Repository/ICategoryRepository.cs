using Opskriftplanen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Repository
{
    interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int Id);
        void Insert(Category category);
        void Update(Category category);
        void Delete(int Id);
        void Save();
    }
}
