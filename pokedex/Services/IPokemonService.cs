using pokedex.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pokedex.Services
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetPokemons();
        Task<Pokemon> GetPokemonById(string id);
        Task<Pokemon> GetPokemonByName(string name);
        Task<Pokemon> AddPokemon(Pokemon newPokemon);
        Task<Pokemon> UpdatePokemon(string id, Pokemon updatedPokemon);
        Task<bool> DeletePokemon(string id);
    }
}
