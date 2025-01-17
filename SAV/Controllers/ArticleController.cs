using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAV.Models;
using SAV.Repository;

namespace SAV.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IRepository<Article> _articleRepository;

        public ArticleController(IRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _articleRepository.GetAllAsync();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            if (article == null) return NotFound();
            return Ok(article);
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] Article article)
        {
            if (article == null) return BadRequest("Invalid article data.");

            await _articleRepository.AddAsync(article);
            await _articleRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArticleById), new { id = article.ArticleId }, article);
        }
        [Authorize(Roles = "Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] Article article)
        {
            if (id != article.ArticleId) return BadRequest("Article ID mismatch.");

            var existingArticle = await _articleRepository.GetByIdAsync(id);
            if (existingArticle == null) return NotFound();

            await _articleRepository.UpdateAsync(article);
            return NoContent();
        }
        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            if (article == null) return NotFound();

            _articleRepository.Delete(article);
            await _articleRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
