namespace WebApiExample.Model;

public class ArticleShop
{
    public int ArticleId { get; set; }
    public int ShopId { get; set; }
    public Article Article { get; set; }
    public Shop Shop { get; set; }
}