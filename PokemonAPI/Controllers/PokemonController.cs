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
        [HttpPost]
        public IActionResult UpdatePokemon(FavoritePokemon pokeName)
        {

            FavoritePokemon pokemonNickname = _pokemonContext.FavoritePokemon.Find(pokeName);

            pokemonNickname.Nickname = pokeName.Nickname;
            

            _pokemonContext.Entry(pokemonNickname).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _pokemonContext.Update(pokemonNickname);
            _pokemonContext.SaveChanges();
            return RedirectToAction("Favorites");
           // return View();
        }
        [HttpGet]
        public IActionResult UpdatePokemon(int Id)
        {
            FavoritePokemon pokemon = _pokemonContext.FavoritePokemon.Find(Id);
            if (pokemon == null)
            {
                return RedirectToAction("Favorites");
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

        public IActionResult Favorites()
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (id != null && id != "")
            {
                List<FavoritePokemon> myPokemon = _pokemonContext.FavoritePokemon.Where(x => x.UserId == id).ToList();

                return View(myPokemon);
            }
            else
            {
                List<FavoritePokemon> myPokemon = _pokemonContext.FavoritePokemon.ToList();

                return View(myPokemon);
            }
        }
      
        
        public async Task<IActionResult> AddPokemon(int id)
        {
            string activeUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value; //finds the user id of the logged in user

            var newFav = new FavoritePokemon();
            var newpokemon =await  _pokemonDAL.GetPokemonById(id);
            newFav.Nickname = newpokemon.name;
            newFav.PokemonId = newpokemon.id;
            newFav.Height = newpokemon.height.ToString();
            newFav.Sprite = newpokemon.sprites.ToString();
            newFav.Type = newpokemon.types.ToString();
            newFav.Weight = newpokemon.weight.ToString();
            newFav.BaseExp = newpokemon.base_experience.ToString();
            newFav.Stats = newpokemon.stats.ToString();
            newFav.UserId = activeUserId;
           
            if (ModelState.IsValid)
            {
                _pokemonContext.FavoritePokemon.Add(newFav);
                _pokemonContext.SaveChanges(); 
            }
            return RedirectToAction("UpdatePokemon", newFav.Id);
        }
    }
}
