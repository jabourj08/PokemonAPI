using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAPI.Models
{
    public class PokemonDAL
    {
        public HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

            return client;
        }

        public async Task<string> GetRawJSON()
        {
            var client = GetClient();
            var response = await client.GetAsync("pokemon/3");
            var pokemonJSON = await response.Content.ReadAsStringAsync();

            return pokemonJSON;
        }
        public async Task<Pokemon> GetPokemon()
        {
            var client = GetClient();
            var response = await client.GetAsync("pokemon/3");
            Pokemon pokemon = await response.Content.ReadAsAsync<Pokemon>();

            return pokemon;
        }

        public async Task<Pokemon> GetPokemonByName(string searchName)
        {
            var client = GetClient();
            var response = await client.GetAsync($"pokemon/{searchName}");
            var pokemon = await response.Content.ReadAsAsync<Pokemon>();

            return pokemon;
        }
        public async Task<Pokemon> GetPokemonById(int id)
        {
            var client = GetClient();
            var response = await client.GetAsync($"pokemon/{id.ToString()}");
            var pokemon = await response.Content.ReadAsAsync<Pokemon>();

            return pokemon;
        }
        public async Task<Pokemon> GetPokemonByType(string type)
        {
            var client = GetClient();
            var response = await client.GetAsync($"type/{type}");
            var pokemon = await response.Content.ReadAsAsync<Pokemon>();

            return pokemon;
        }
    }
}
