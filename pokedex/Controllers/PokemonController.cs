using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using pokedex.Services;

namespace pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<List<Pokemon>> Get()
        {
            return await _pokemonService.GetPokemons();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPokemon(string id)
        {
            try
            {
                return Ok(await _pokemonService.GetPokemonById(id));
            }
            catch (Exception)
            {
                return NotFound("Pokemon not found");
            }
        }

        [HttpPost]
        public async Task<Pokemon> AddPokemon(Pokemon newPokemon)
        {
            return await _pokemonService.AddPokemon(newPokemon);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pokemon>> UpdatePokemon(string id, Pokemon updatedPokemon)
        {
            try
            {
                return Ok(await _pokemonService.UpdatePokemon(id, updatedPokemon));
            }
            catch (Exception)
            {
                return NotFound("Pokemon not found");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePokemon(string id)
        {
            try
            {
                await _pokemonService.DeletePokemon(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound("Pokemon not found");
            }
        }
    }
}
