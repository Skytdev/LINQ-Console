﻿using myQ;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace myQ
{

    internal class Program
    {
        private static List<Pokemon> pokemons = new List<Pokemon>();
        public static int menuChoice;
        public static List<float> numbers = new List<float> { 43.68F, 1.25F, 583.7F, 6.5F };

        static void Main(string[] args)
        {

            while (menuChoice != 16)
            {
                pokemons = RegeneratePokemonList();
                DisplayMenu();
                switch (menuChoice)
                {
                    case 1:
                        DisplayChangeTypesToFire(pokemons);
                        break;
                    case 2:
                        DisplayMyFirstOrDefault(pokemons);
                        break;
                    case 3:
                        DisplayMyFirst(pokemons);
                        break;
                    case 4:
                        DisplayMyWhere(pokemons);
                        break;
                    case 5:
                        float sum = numbers.MySum();
                        Console.WriteLine("The sum of the numbers is {0}.", sum);
                        Console.ReadLine();
                        break;
                    case 6:
                        DisplayMyLastOrDefault(pokemons);
                        break;
                    case 7:
                        DisplayMySingleOrDefault(pokemons);
                        break;
                    case 8:
                        DisplayMySkip(pokemons);
                        break;
                    case 9:
                        DisplayMyTake(pokemons);
                        break;
                    case 10:
                        DisplayMyAny(pokemons);
                        break;
                    case 11:
                        DisplayMyAll(pokemons);
                        break;
                    case 12:
                        DisplayMyDisctinctBy(pokemons);
                        break;
                    case 13:
                        DisplayMyDisctinct(pokemons);
                        break;
                    case 14:
                        DisplayMyOrderBy(pokemons);
                        break;
                }
            }
            
            /////////////////////////////////
        }

        public static List<Pokemon> RegeneratePokemonList()
        {
            var pikachu = new Pokemon()
            {
                Id = 1,
                Name = "Pikachu",
                PokemonType = "Electrique",
                IsActive = true
            };

            var dracaufeu = new Pokemon()
            {
                Id = 2,
                Name = "Dracaufeu",
                PokemonType = "Feu",
                IsActive = false
            };

            var smogogo = new Pokemon()
            {
                Id = 3,
                Name = "Smogogo",
                PokemonType = "Poison",
                IsActive = true

            };

            var raichu = new Pokemon()
            {
                Id = 2,
                Name = "Raichu",
                PokemonType = "Electrique",
                IsActive = true

            };

            var bulbizarre = new Pokemon()
            {
                Id = 1,
                Name = "Bulbizarre",
                PokemonType = "Plante",
                IsActive = false
            };

            var electhor = new Pokemon()
            {
                Id = 6,
                Name = "Électhor",
                PokemonType = "Electrique",
                IsActive = true
            };

            var raichu2 = new Pokemon()
            {
                Id = 7,
                Name = "Raichu",
                PokemonType = "Electrique",
                IsActive = true

            };

            var raichu3 = new Pokemon()
            {
                Id = 8,
                Name = "Raichu",
                PokemonType = "Elec",
                IsActive = true

            };

            pokemons = new List<Pokemon>()
            {
                pikachu,
                dracaufeu,
                smogogo,
                raichu,
                bulbizarre,
                electhor,
                raichu2,
                raichu3
            };

            return pokemons;
        }

        public static void DisplayPokemons<T>(IEnumerable<T> thingToDisplay)
        {
            foreach (var item in thingToDisplay)
            {
                Console.WriteLine(item);
            }
        }

        public static void DisplayMenu()
        {
            Console.Clear();
            DisplayPokemons(pokemons);
            Console.WriteLine();
            Console.WriteLine("------ SELECTIONNE LA METHODE A EFFECTUER SUR LA LISTE DE POKEMON ------");
            Console.WriteLine("----   1    ChangeTypeToChoice");
            Console.WriteLine("----   2    MyFirstOrDefault");
            Console.WriteLine("----   3    MyFirst");
            Console.WriteLine("----   4    MyWhere");
            Console.WriteLine("----   5    MySum");
            Console.WriteLine("----   6    MyLastOrDefault");
            Console.WriteLine("----   7    MySingleOrDefault");
            Console.WriteLine("----   8    MySkip");
            Console.WriteLine("----   9    MyTake");
            Console.WriteLine("----   10   MyAny");
            Console.WriteLine("----   11   MyAll");
            Console.WriteLine("----   12   MyDistinctBy");
            Console.WriteLine("----   13   MyDistinct");
            Console.WriteLine("----   14   MyOrderBy");
            Console.WriteLine("----   15   MyGroupBy");
            Console.WriteLine("----   16    Exit");
            Console.WriteLine("------------------------------------------------------------------------");
            menuChoice = Convert.ToInt32(Console.ReadLine());
        }

        public static void ChangeTypesToFire(List<Pokemon> pokemons, Action<Pokemon> predicate)
        {
            foreach (var it in pokemons)
            {
                predicate(it);
            }
        }

        public static void DisplayChangeTypesToFire(List<Pokemon> pokemons)
        {
            Console.Clear();
            Console.WriteLine("Please enter the pokemon Type you want to add : ");
            var type = Console.ReadLine();
            ChangeTypesToFire(pokemons, x => x.PokemonType = type);
            DisplayPokemons(pokemons);
            Console.WriteLine("Press any key to return to Menu");
            Console.ReadLine();
        }

        public static void DisplayMyFirstOrDefault(List<Pokemon> pokemons)
        {
            Console.Clear();
            Console.WriteLine("Enter id to find pokemon");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = pokemons.MyFirstOrDefault(x => x.Id == id);
            Console.WriteLine("pokemon :");
            Console.WriteLine(result);
            Console.WriteLine("Press any key to return to Menu");
            Console.ReadLine();
        }

        public static void DisplayMyFirst(List<Pokemon> pokemons)
        {
            Console.Clear();
            var result = pokemons.MyFirst();
            Console.WriteLine("pokemon :");
            Console.WriteLine(result);
            Console.WriteLine("Press any key to return to Menu");
            Console.ReadLine();
        }

        public static void DisplayMyWhere(List<Pokemon> pokemons)
        {
            Console.Clear();
            Console.WriteLine("Veuillez entrer le type de pokemon que vous souhaitez voir :");
            var type = Console.ReadLine();
            var newList = pokemons.MyWhere(x => x.PokemonType == type);
            Console.WriteLine("New filtered list :");
            DisplayPokemons(newList);
            Console.WriteLine("Press any key to return to Menu");
            Console.ReadLine();
        }

        public static void DisplayMyLastOrDefault(List<Pokemon> pokemons)
        {
            Console.Clear();
            Console.WriteLine("Enter a the last type to find pokemon");
            string type = Console.ReadLine();
            var result = pokemons.MyLastOrDefault(x => x.PokemonType == type);
            Console.WriteLine("pokemon :");
            Console.WriteLine(result);
            Console.WriteLine("Press any key to return to Menu");
            Console.ReadLine();
        }

        public static void DisplayMySingleOrDefault(List<Pokemon> pokemons)
        {
            Console.Clear();
            Console.WriteLine("Enter a the last type to find single pokemon");
            string type = Console.ReadLine();
            var result = pokemons.MySingleOrDefault(x => x.PokemonType == type);
            Console.WriteLine("pokemon :");
            Console.WriteLine(result);
            Console.WriteLine("Press any key to return to Menu");
            Console.ReadLine();
        }

        public static void DisplayMySkip(List<Pokemon> pokemons)
        {
            Console.Clear();
            Console.WriteLine("Enter the amount you want to skip");
            int a = Convert.ToInt32(Console.ReadLine());
            var result = pokemons.MySkip(a);
            Console.WriteLine("Result :");
            DisplayPokemons(result);
            Console.WriteLine("Press any key to return to Menu");
            Console.ReadLine();
        }

        public static void DisplayMyTake(List<Pokemon> pokemons)
        {
            Console.Clear();
            Console.WriteLine("Enter the first index you want to start taking");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second index you want to start taking");
            int b = Convert.ToInt32(Console.ReadLine());
            var result = pokemons.MyTake(a..b);
            Console.WriteLine("Result :");
            DisplayPokemons(result);
            Console.WriteLine("Press any key to return to Menu");
            Console.ReadLine();
        }

        public static void DisplayMyAny(List<Pokemon> pokemons)
        {
            Console.Clear();
            Console.WriteLine("Vérifie si un type de pokémon est actif, entre le type à tester :");
            string a = Console.ReadLine();
            bool result = pokemons.Any();
            Console.WriteLine("Result : {0}", result ? "Des pokemons sont actifs" : "Des pokemons sont inactifs");
            Console.WriteLine("Press any key to return to Menu");
            Console.ReadLine();
        }

        public static void DisplayMyAll(List<Pokemon> pokemons)
        {
            Console.Clear();
            bool result = pokemons.MyAll(x => x.IsActive == true);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void DisplayMyDisctinctBy(List<Pokemon> pokemons)
        {
            Console.Clear();
            var result = pokemons.MyDistinctBy(x => x.PokemonType);
            DisplayPokemons(result);
            Console.ReadLine();
        }

        public static void DisplayMyDisctinct(List<Pokemon> pokemons)
        {
            Console.Clear();
            var result = pokemons.MyDistinct(new PokemonComparer());
            DisplayPokemons(result);
            Console.ReadLine();
        }

        public static void DisplayMyOrderBy(List<Pokemon> pokemons)
        {
            Console.Clear();
            var result = pokemons.OrderBy(x => x.Id);
            DisplayPokemons(result);
            Console.ReadLine();
        }


    }
}

static class Test
{
    public static T MyFirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null)
        {
            throw new ArgumentNullException("There is not argument");
        }

        foreach (var item in source)
        {
            if (predicate(item))
            {
                return item;
            }
        }
        return default;
    }

    public static T MyFirst<T>(this IEnumerable<T> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException("There is not argument");
        }

        foreach (var item in source)
        {
            if (item != null)
            {
                return item;
            }
        }
        return default;
    }

    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        var result = new List<T>();

        if (source == null)
        {
            throw new ArgumentNullException("There is not argument");
        }

        foreach (var item in source)
        {
            if (predicate(item) == true)
            {
                result.Add(item);
            }
        }
        return result;
    }

    public static Single MySum(this IEnumerable<Single> source)
    {
        Single result = 0;

        foreach (var item in source)
        {
            result += item;
        }
        return result;
    }

    public static T? MyLastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        T lastItem = default;

        foreach (var item in source)
        {
            if (predicate(item))
            {
                lastItem = item;
            }
        }

        return lastItem;
    }

    public static T? MySingleOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        var myList = new List<T>();

        foreach (var item in source)
        {
            if (predicate(item))
            {
                myList.Add(item);
            }
        }

        if (myList.Count() == 1)
        {
            return myList[0];
        } else if (myList.Count() > 1)
        {
            throw new InvalidOperationException("Error");
        } else
        {
            return default;
        }

    }

    public static IEnumerable<T> MySkip<T>(this IEnumerable<T> source, int count)
    {
        var result = new List<T>();
        var i = 0;

        foreach (var item in source)
        {
            if (i >= count)
            {
                result.Add(item);
            }
            i++;
        }

        return result;
    }

    public static IEnumerable<T> MyTake<T>(this IEnumerable<T> source, Range range)
    {
        var myList = new List<T>();
        int start = range.Start.Value;
        int end = range.End.Value;
        int i = 0;

        while (source.Count() <= end)
        {
            T item = source.First();

            if (i >= start && i <= end)
            {
                myList.Add(item);
            }

            i++;
            source = source.Skip(1);
        }
        return myList;
    }

    public static bool MyAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                return true;
            }
        }
        return false;
    }

    public static bool MyAny<T>(this IEnumerable<T> source)
    {
        foreach (var item in source)
        {
            return true;
        }
        return false;
    }

    public static bool MyAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (!predicate(item))
            {
                return false;
            }
        }
        return true;
    }

    public static IEnumerable<T> MyDistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
    {
        HashSet<TKey> myHash = new HashSet<TKey>();
        var result = new List<T>();

        foreach (var item in source)
        {

            TKey key = keySelector(item);

            if (myHash.Add(key))
            {
                result.Add(item);
            }
        }

        return result;
    }

    public static IEnumerable<T> MyDistinct<T>(this IEnumerable<T> source, IEqualityComparer<T>? comparer)
    {
        HashSet<T> myHash = new HashSet<T>(comparer);
        var result = new List<T>();

        foreach (var item in source)
        {
            if (myHash.Add(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    //public static IOrderedEnumerable<T> MyOrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
    //{
    //    var result = new List<T>();

    //    foreach (var item in source)
    //    {
            
    //    }


    //    return (IOrderedEnumerable <T>)result;
    //}

    public static bool TestT<T>(T a, T b)
    {
        if (a > b)
        {
            return true;
        }
        return false;
    }
}

class PokemonComparer : IEqualityComparer<Pokemon>
{
    public bool Equals(Pokemon x, Pokemon y)
    {
        //Check whether the compared objects reference the same data.
        if (Object.ReferenceEquals(x, y)) return true;

        //Check whether any of the compared objects is null.
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            return false;

        //Check whether the pokemon properties are equal.
        return x.PokemonType == y.PokemonType && x.Name == y.Name;
    }


    public int GetHashCode(Pokemon Pokemon)
    {
        //Check whether the object is null
        if (Object.ReferenceEquals(Pokemon, null)) return 0;

        //Get hash code for the Name field if it is not null.
        int hashProductName = Pokemon.Name == null ? 0 : Pokemon.Name.GetHashCode();

        //Get hash code for the Type field.
        int hashProductType = Pokemon.PokemonType.GetHashCode();

        //Calculate the hash code for the pokemon.
        return hashProductName ^ hashProductType;
    }
}

