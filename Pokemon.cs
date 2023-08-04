﻿namespace myQ
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PokemonType { get; set; }

        public override string ToString()
        {
            return $"{Id} |{Name} | {PokemonType}";
        }

    }
}

//pokemons.FirstOrDefault
//pokemons.First
//pokemons.Where
//pokemons.Sum
//pokemons.LastOrDefault
//pokemons.SingleOrDefault
//pokemons.Skip
//pokemons.Take
//pokemons.Any
//pokemons.All
//pokemons.Distinct
//pokemons.OrderBy
//pokemons.GroupBy
