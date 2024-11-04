using Mini_projet_net.Models;

namespace Mini_projet_net.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        readonly AppDbContext context;
        public CategorieRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Categorie s)
        {
            context.categories.Add(s);
            context.SaveChanges();
        }

        public void Delete(Categorie s)
        {
            Categorie c1 = context.categories.Find(s.categorieId);
            if (c1 != null)
            {
                context.categories.Remove(c1);
                context.SaveChanges();
            }
        }

        public void Edit(Categorie s)
        {
            Categorie c1 = context.categories.Find(s.categorieId);
            if (c1 != null)
            {
                c1.Namecategorie = s.Namecategorie;
                context.SaveChanges();
            }
        }

        public IList<Categorie> GetAll()
        {
            return context.categories.OrderBy(s => s.Namecategorie).ToList();
        }

        public Categorie GetById(int id)
        {
            return context.categories.Find(id);
        }
    }
}
