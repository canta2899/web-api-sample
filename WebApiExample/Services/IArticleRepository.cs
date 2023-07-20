using WebApiExample.Model;

namespace WebApiExample.Services;

public interface IArticleRepository
{
   public IQueryable<Article> GetByName(string name);
   public IQueryable<Article> GetByShop(int shopId);
}