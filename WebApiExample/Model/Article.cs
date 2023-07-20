namespace WebApiExample.Model;

public class Article
{
    public int Id { get; set; }    
    public string Description { get; set; }
    public virtual ArticleCategory Category { get; set; }
    public ICollection<Shop> Shops { get; set; }
}