using BookStores.Domain.Models;
using BookStores.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStores.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService AuthorService;

        public AuthorsController(IAuthorService authorService)
        {
            AuthorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthors()
        {
            var authors = await AuthorService.GetAllAuthors();

            return Ok(authors);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(int id)
        {
            var author = await AuthorService.GetAuthorById(id);
            return Ok(author);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> UpdateAuthor(int id, [FromBody] Author author)
        {
            var AuthorToBeUpdated = await AuthorService.GetAuthorById(id);
            if (AuthorToBeUpdated == null)
                return NotFound();
            await AuthorService.UpdateAuthor(AuthorToBeUpdated, author);
            var updatedAuthor = await AuthorService.GetAuthorById(id);
            return Ok(updatedAuthor);
        }
    }
}
