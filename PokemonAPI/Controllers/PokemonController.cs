using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonDAL _pokemonDAL;
        private readonly PokemonDbContext _pokemonContext;

        public PokemonController()
        {
            _pokemonDAL = new PokemonDAL();
            
            _pokemonContext = new PokemonDbContext();
        }

        

       

        public async Task<IActionResult> PokemonJSON()
        {
            var pokemonJSON = await _pokemonDAL.GetRawJSON();

            return View(pokemonJSON);
        }

        public IActionResult SearchPokemon()
        {
            return View();
        }

        public async Task<IActionResult> GetPokemon()
        {
            Pokemon pokemon = await _pokemonDAL.GetPokemon();

            return View(pokemon);
        }

        [HttpPost]
        public async Task<IActionResult> SearchPokemonByName(string searchName)
        {
            var pokemon = await _pokemonDAL.GetPokemonByName(searchName);

            return View("SearchResults", pokemon);
        }

        public async Task<IActionResult> SearchPokemonById(int id)
        {
            var pokemon = await _pokemonDAL.GetPokemonById(id);

            return View("SearchResults", pokemon);
        }

        public async Task<IActionResult> SearchPokemonByType(string type)
        {
            var pokemonType = await _pokemonDAL.GetPokemonByType(type);

            return View("SearchResultsType", pokemonType);
        }

        public IActionResult UpdatePokemon(int id)
        {
            FavoritePokemon pokemon = _pokemonContext.FavoritePokemon.Find(id);
            if (pokemon == null)
            {
                return View();
            }
            else
            {
                return View(pokemon);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
