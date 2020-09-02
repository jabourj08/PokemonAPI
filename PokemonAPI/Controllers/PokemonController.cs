using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonDAL _pokemonDAL;

        public PokemonController()
        {
            _pokemonDAL = new PokemonDAL();
        }

        public async Task<IActionResult> PokemonJSON()
        {
            var pokemonJSON = await _pokemonDAL.GetRawJSON();

            return View(pokemonJSON);
        }

        public async Task<IActionResult> GetPokemon()
        {
            var pokemon = await _pokemonDAL.GetPokemon();

            return View(pokemon);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
