using Mini_projet_net.Models;

namespace Mini_projet_net.Repositories
{
    public interface IArticleRepository
    {
        IList<Article> GetAll();
        Article GetById(int id);
        void Add(Article article);
        public Article Update(Article article);
        void Delete(Article article);
        List<Article> Search(String Designation);
        IList<Article> GetArticlesByCategoryID(int? categorieId);
        IList<Article> FindByDesingnation(string designation);
    }
}
