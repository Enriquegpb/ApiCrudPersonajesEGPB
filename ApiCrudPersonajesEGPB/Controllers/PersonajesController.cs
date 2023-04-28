using ApiCrudPersonajesEGPB.Models;
using ApiCrudPersonajesEGPB.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudPersonajesEGPB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;
        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonajeAsync(id);
            return Ok();
        } 
        [HttpPost("[action]/{idpersonaje}/{personaje}/{imagen}/{idserie}")]

        public async Task<ActionResult> InsertarPersonaje(int idpersonaje, string personaje, string imagen, int idserie)
        {
            await this.repo.InsertPersonajeAsync(idpersonaje, personaje, imagen, idserie);
            return Ok();
        }
        [HttpPut("[action]/{idpersonaje}/{personaje}/{imagen}/{idserie}")]

        public async Task<ActionResult> UpdatePersonaje(int idpersonaje, string personaje, string imagen, int idserie)
        {
            await this.repo.UpdatePersonajeAsync(idpersonaje, personaje, imagen, idserie);
            return Ok();
        }
    }
}
