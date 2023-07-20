namespace WebApiExample.Model;

public class Shop
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Address { get; set; }
    public virtual ICollection<Article> Articles { get; set; }
    
    public int ManagerId { get; set; }
    public virtual Manager Manager { get; set; }
}