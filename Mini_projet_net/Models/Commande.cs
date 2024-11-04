namespace Mini_projet_net.Models
{
    public class Commande
    {
        public int commandeId { get; set; }
        public string Email { get; set; }
        public string NumeroTelephone { get; set; }
       
        public List<Panier> Articles { get; set; }
    }
}
