using Mini_projet_net.Models;

namespace Mini_projet_net.Repositories
{
    public interface ICategorieRepository
    {
        IList<Categorie> GetAll();
        Categorie GetById(int id);
        void Add(Categorie s);
        void Edit(Categorie s);
        void Delete(Categorie s);
        //int ArticleCount(int CategorieId);
        
    }
}
