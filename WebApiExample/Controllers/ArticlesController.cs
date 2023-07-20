using Microsoft.AspNetCore.Mvc;
using WebApiExample.Model;
using WebApiExample.Services;

namespace WebApiExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController : ControllerBase
{
    private readonly IArticleRepository _articleRepository;

    public ArticlesController(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    [HttpGet]
    public IActionResult ByName(string name)
    {
        try
        {
            var articles = _articleRepository.GetByName(name);
            return Ok(articles);
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }

    [HttpGet("/shop/{id}")]
    public IActionResult ByShop(int id)
    {
        try
        {
            var articles = _articleRepository.GetByShop(id);
            return Ok(articles);
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }
    
}