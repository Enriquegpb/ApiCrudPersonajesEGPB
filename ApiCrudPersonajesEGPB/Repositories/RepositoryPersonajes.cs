using ApiCrudPersonajesEGPB.Data;
using ApiCrudPersonajesEGPB.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudPersonajesEGPB.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }
        public async Task<Personaje> FindPersonajeAsync(int idpersonaje)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == idpersonaje);
        }

        public async Task InsertPersonajeAsync(int idpersonaje, string personaje, string imagen, int idserie)
        {
            Personaje personajeserie = new Personaje
            {
                IdPersonaje= idpersonaje,
                NombrePersonaje = personaje,
                Imagen  = imagen,
                IdSerie = idserie   
            };
            this.context.Personajes.Add(personajeserie);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdatePersonajeAsync(int idpersonaje, string personaje, string imagen, int idserie)
        {
            Personaje personajeserie = await this.FindPersonajeAsync(idpersonaje);
            personajeserie.NombrePersonaje = personaje;
            personajeserie.Imagen = imagen;
            personajeserie.IdSerie = idserie;
            await this.context.SaveChangesAsync();
        }
        public async Task DeletePersonajeAsync(int idpersonaje)
        {
            Personaje personajeserie = await this.FindPersonajeAsync(idpersonaje);
            this.context.Remove(personajeserie);
            await this.context.SaveChangesAsync();
        }
    }
}
