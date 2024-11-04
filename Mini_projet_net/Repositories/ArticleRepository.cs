using Microsoft.EntityFrameworkCore;
using Mini_projet_net.Models;
using System.Xml.Linq;

namespace Mini_projet_net.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        readonly AppDbContext context;
        public ArticleRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Article article)
        {
            context.Add(article);
            context.SaveChanges();
        }

        public void Delete(Article article)
        {
            Article a = context.articles.Find(article.articleId);
            if (a != null)
            {
                context.articles.Remove(a);
                context.SaveChanges();
            }
        }

        public IList<Article> FindByDesingnation(string designation)
        {
            return context.articles.Where(s =>
                s.Designation.Contains(designation)).Include(std =>
                std.categorie).ToList();
        }

        public IList<Article> GetAll()
        {
            return context.articles.OrderBy(a => a.Designation).ToList();
        }

        public Article GetById(int id)
        {
            return context.articles.Find(id);
        }

        public IList<Article> GetArticlesByCategoryID(int? categorieId)
        {
            return context.articles.Where(s =>
                s.categorieId.Equals(categorieId))
                .OrderBy(s => s.Designation)
                .Include(std => std.categorie).ToList();
        }

        public List<Article> Search(string Designation)
        {
            throw new NotImplementedException();
        }

        public Article Update(Article article)
        {
            Article c1 = context.articles.Find(article.articleId);
            if (c1 == null)
            {
                context.articles.Add(article);
            }
            else
            {
                c1.Designation = article.Designation;
                c1.Quantite = article.Quantite;
                c1.Prix = article.Prix;
                c1.categorieId = article.categorieId;
            }

            context.SaveChanges();

            return article;
        }
    }
}
