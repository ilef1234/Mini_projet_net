using Mini_projet_net.Models;

namespace Mini_projet_net.Repositories
{
    public class PanierRepository : IPanierRepository
    {
        private readonly List<Panier> _panier = new List<Panier>();
        private readonly AppDbContext _context;

        public PanierRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddToCart(int articleId)
        {
            throw new NotImplementedException();
        }

        public Panier EditPanier(Panier panierArt)
        {
            throw new NotImplementedException();
        }

        public List<Panier> GetCartItems()
        {
            throw new NotImplementedException();
        }

        public Panier GetPanierArtById(int panierArtId)
        {
            throw new NotImplementedException();
        }

        public bool IsInCart(int articleId)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromCart(int articleId)
        {
            throw new NotImplementedException();
        }
    }
}
