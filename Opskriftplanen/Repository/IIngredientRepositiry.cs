using Opskriftplanen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Repository
{
    interface IIngredientRepositiry
    {
        IEnumerable<Ingredient> GetAll();
        Ingredient GetById(int Id);
        void Insert(Ingredient ingredient);
        void Update(Ingredient ingredient);
        void Delete(int Id);
        void Save();
    }
}
