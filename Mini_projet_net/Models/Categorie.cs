namespace Mini_projet_net.Models
{
    public class Categorie
    {
        public int categorieId { get; set; }
        public string Namecategorie { get; set; }
        public List<Article> articles { get; set; }
    }
}
