using Mini_projet_net.Models;

namespace Mini_projet_net.Repositories
{
    public interface IPanierRepository
    {
        void AddToCart(int articleId);
        bool IsInCart(int articleId);
        void RemoveFromCart(int articleId);
        List<Panier> GetCartItems();
        public Panier EditPanier(Panier panierArt);
        Panier GetPanierArtById(int panierArtId);
    }
}
