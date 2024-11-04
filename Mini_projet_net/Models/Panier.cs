namespace Mini_projet_net.Models
{
    public class Panier
    {
        public int panierId { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int Quantity { get; set; }
    }
}
