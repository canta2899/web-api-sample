using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApiExample.Model;

namespace WebApiExample.Services;

public class ArticleRepository :  IArticleRepository
{
    private readonly ApiDbContext _dbContext;

    public ArticleRepository(ApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IQueryable<Article> GetByName(string name)
    {
        return _dbContext.Articles.Where(x => x.Description.Contains(name));
    }

    public IQueryable<Article> GetByShop(int shopId)
    {
        return _dbContext
            .ArticleShops
            .Where(x => x.ShopId == shopId)
            .Include(x => x.Article)
            .Select(x => x.Article);
    }
}