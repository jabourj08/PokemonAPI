using System;
using System.Collections.Generic;

namespace PokemonAPI.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
<<<<<<< HEAD
<<<<<<< HEAD
            FavoritePokemon = new HashSet<FavoritePokemon>();
=======
<<<<<<< HEAD
            FavoritePokemon = new HashSet<FavoritePokemon>();
=======
>>>>>>> a0f7a559a60173d9ccdfb2c607a2378e9681a65b
>>>>>>> 695537b888ea6c06860ac93f4937b82a8b30ea43
=======
            FavoritePokemon = new HashSet<FavoritePokemon>();
>>>>>>> 2516b02fba0beadb171911135bae14d7dc76a761
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
        public virtual ICollection<FavoritePokemon> FavoritePokemon { get; set; }
=======
<<<<<<< HEAD
        public virtual ICollection<FavoritePokemon> FavoritePokemon { get; set; }
=======
>>>>>>> a0f7a559a60173d9ccdfb2c607a2378e9681a65b
>>>>>>> 695537b888ea6c06860ac93f4937b82a8b30ea43
=======
        public virtual ICollection<FavoritePokemon> FavoritePokemon { get; set; }
>>>>>>> 2516b02fba0beadb171911135bae14d7dc76a761
    }
}
