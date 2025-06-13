using CatFacts.Models;

namespace CatFacts.Data
{
    public interface ICatRepo
    {

        bool SaveChanges();
        IEnumerable<Cat> GetAllCats();
        Cat GetCatById(int id);
        void CreateCat(Cat cat);
        void UpdateCat(Cat cat);
        void DeleteCat(Cat cat);
    }

}