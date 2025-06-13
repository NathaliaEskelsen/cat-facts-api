using CatFacts.Models;
using System.Linq;
using System.Collections.Generic;

namespace CatFacts.Data
{

    public class SqlCatRepo : ICatRepo
    {
        private readonly CatContext _context;

        public SqlCatRepo(CatContext context)
        {
            _context = context;
        }

        public void CreateCat(Cat cat)
        {
            if (cat == null)
            {
                throw new ArgumentNullException(nameof(cat));
            }

            _context.Cats.Add(cat);
        }

        public void DeleteCat(Cat cat)
        {
            if (cat == null)
            {
                throw new ArgumentNullException(nameof(cat));
            }
             _context.Cats.Remove(cat);
        }
           
        public IEnumerable<Cat> GetAllCats()
        {
            return _context.Cats.ToList();
        }

        public Cat GetCatById(int id)
        {
            return _context.Cats.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCat(Cat cat)
        {
            //Nothing
        }
    }
}