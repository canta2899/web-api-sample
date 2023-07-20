using System.Globalization;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WebApiExample.Model;

namespace WebApiExample.Services;

public class ApiDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ApiDbContext(DbContextOptions<ApiDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public DbSet<Article> Articles { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<ArticleShop> ArticleShops { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ArticleShop>().HasKey(x => new { x.ArticleId, x.ShopId });
        
        var shouldSeed = _configuration.GetSection("DbContextSettings").GetValue<bool?>("ShouldSeed") ?? false;
        
        if (shouldSeed) Seed(builder);
    }

    private void Seed(ModelBuilder builder)
    {
        var manager1 = new Manager()
        {
            Id = 1,
            Name = "Zio",
            LastName = "Pera",
            BirthDate = DateTime.Today.AddYears(-40)
        };
        
        var manager2 = new Manager()
        {
            Id = 2,
            Name = "Alessandro",
            LastName = "Magno",
            BirthDate = DateTime.Today.AddYears(-30)
        };
        
        builder.Entity<Manager>().HasData(manager1, manager2);
        
        var article1 = new Article()
        {
            Id = 1,
            Category = ArticleCategory.Food,
            Description = "Kinder Fetta al Latte",
        };

        var article2 = new Article()
        {
            Id = 2,
            Category = ArticleCategory.Toys,
            Description = "Astronave Lego",
        };

        var article3 = new Article()
        {
             Id = 3,
             Category = ArticleCategory.House,
             Description = "Tagliera per salame",
        };
        
        
        var shop1 = new Shop()
        {
            Address = "Via Paoli, 0, Udine",
            Id = 1,
            ManagerId = 1,
            Name = "Negozio di Udine",
        };
        
        var shop2 = new Shop()
        {
            Address = "Via Paoli, 0, Udine",
            Id = 2,
            ManagerId = 2,
            Name = "Negozio di Lignano",
        };

        builder.Entity<Article>().HasData(article1, article2, article3);

        builder.Entity<Shop>().HasData(shop1, shop2);
        builder.Entity<ArticleShop>().HasData(
            new ArticleShop() { ShopId = 1, ArticleId = 1 },
            new ArticleShop() { ShopId = 1, ArticleId = 2 },
            new ArticleShop() { ShopId = 2, ArticleId = 1 },
            new ArticleShop() { ShopId = 2, ArticleId = 3 }
        );
    }
}