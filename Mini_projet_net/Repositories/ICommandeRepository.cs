using Mini_projet_net.Models;

namespace Mini_projet_net.Repositories
{
    public interface ICommandeRepository
    {
        void AddCommande(Commande commande);
        List<Commande> GetAllCommandes();
        List<Commande> GetAllCommandesByUser(string userId);
        Commande GetCommandeById(int id);
        void Edit(Commande commande);
    }
}
