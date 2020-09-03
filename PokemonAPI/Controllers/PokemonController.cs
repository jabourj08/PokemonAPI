using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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

        //public IActionResult Favorites()
        //{
        //    string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

        //    if (id != null && id != "")
        //    {
        //        List<FavoritePokemon> myPokemon = _PokemonContext.PokemonDb.Where(x => x.UserId == id).ToList();

        //        return View(myPokemon);
        //    }
        //    else
        //    {
        //        List<FavoritePokemon> myPokemon = _PokemonContext.PokemonDb.ToList();

        //        return View(myPokemon);
        //    }
        //}

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


        public IActionResult Index()
        {
            return View();
        }
    }
}
