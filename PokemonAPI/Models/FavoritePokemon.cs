using System;
using System.Collections.Generic;

namespace PokemonAPI.Models
{
    public partial class FavoritePokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int? PokemonId { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
