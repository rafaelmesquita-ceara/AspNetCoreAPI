using System.Collections.Generic; 
using System.Threading.Tasks; // Trabalhando de forma assíncrona
using Microsoft.AspNetCore.Mvc; // Trabalhando com o padrão MVC do aspnetcore
using Microsoft.EntityFrameworkCore; // Importando a biblioteca EntityFramework
using aspnetcoreapi.Data; // Importando meu DbContext
using aspnetcoreapi.Models; // Importando meus models
using System.Linq;

namespace aspnetcoreapi.Controllers
{
    [ApiController] // Especificando o controller para API (e não para razor pages)
    // Como não especifiquei um roteamento no startup, ele vai se mapear pelo controller
    [Route("v1/products")]  // v1 para versionamento, no caminho /products
    public class ProductController : ControllerBase
    {
      #region GET
      [HttpGet] // Método de requisição GET
      [Route("")] // Rota padrão (/)
      public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context) 
      // Task para forma assincrona, irei retornar uma lista de produtos, irei pegar o DataContext dos services, onde já defini o DataContext
      {
        var products = await context.Products.ToListAsync(); // Faço uma consulta no meu database para pegar todos os produtos
        return products; // Retorno os produtos
      }

      [HttpGet] // Método de requisição GET
      [Route("{id:int}")] // Recebo meu id de produto
      public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)  // no final recebo um int id para referenciar o id recebido na rota
      // Task para forma assincrona, irei retornar um produto com base no ID, irei pegar o DataContext dos services, onde já defini o DataContext
      {
        var product = await context.Products
          .Include(x => x.Category) // Dou um join nas categorias para incluir no meu json retornado
          .AsNoTracking() // Para nao criar proxys do meu objeto
          .FirstOrDefaultAsync(x => x.Id == id); // Recebo o produto com base no id
        return product; // Retorno o produto
      }

      [HttpGet] // Método de requisição GET
      [Route("categories/{id:int}")] // Recebo meu id de categoria
      public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] DataContext context, int id)  // no final recebo um int id para referenciar o id recebido na rota
      // Task para forma assincrona, irei retornar produtos com base na categoria, irei pegar o DataContext dos services, onde já defini o DataContext
      {
        var products = await context.Products
          .Include(x => x.Category) // Dou um join nas categorias
          .AsNoTracking() // Para nao criar proxys do meu objeto
          .Where(x => x.CategoryId == id) // Pego apenas os produtos daquelas categorias
          .ToListAsync(); // Jogo na lista de forma assincrona

        return products; // Retorno os produtos
      }
      #endregion

      [HttpPost] // Método de requisição Post
      [Route("")] // Rota padrão (/)
      public async Task<ActionResult<Product>> Post(
        [FromServices] DataContext context, // Pego o DataContext dos services no Startup.cs
        [FromBody]Product model) // Pego o modelo Product do corpo da requisição
      {
        // Valido minha categoria com base no Model Product.cs
        if (ModelState.IsValid)   
        {
          //  Caso todos a validacao tenha sido bem sucedida, ele salva no meu banco de dados o Produto
          context.Products.Add(model);
          await context.SaveChangesAsync();
          return model; // Retorno meu modelo Product
        }
        else
        {
          // Caso a validacao nao tenha sido bem sucedida, ele retorna o erro especificado no Model
          return BadRequest(ModelState);
        }
      }
    }
}