using System;
using System.Collections.Generic;

namespace Pokemon_Tester
{
    internal class Generators
    {
        public Pokemon GeneratorNewOriginalPokemon(List<Pokemon> pokedex, string name)
        {
            Pokemon newPoke = new Pokemon();
            newPoke.Name = name;
            newPoke.Number = RNGGen(898, 1000);
            newPoke.Type = pokedex[RNGGen(1, pokedex.Count)].Type;
            newPoke.Type2 = pokedex[RNGGen(1, pokedex.Count)].Type2;
            while (newPoke.Type == newPoke.Type2)
            {
                newPoke.Type2 = pokedex[RNGGen(1, pokedex.Count)].Type2;
            }
            newPoke.HP_Base = RNGGen(20, 150);
            newPoke.Attack_Base = RNGGen(20, 150);
            newPoke.Defense_Base = RNGGen(20, 150);
            newPoke.SpecialAttack_Base = RNGGen(20, 150);
            newPoke.SpecialDefense_Base = RNGGen(20, 150);
            newPoke.Speed_Base = RNGGen(20, 150);
            LevelByAmount(newPoke, RNGGen(1, 100));
            return newPoke;
        }

        public Pokemon GeneratorMyPokemon(List<Pokemon> pokedex, string name, int level)
        {
            for (int i = 0; i < pokedex.Count; i++)
            {
                if (name == pokedex[i].Name)
                {
                    Pokemon newExPoke = new Pokemon();
                    newExPoke = pokedex[i];
                    LevelByAmount(newExPoke, level);
                    newExPoke.AssignMoves();
                    return newExPoke;
                }
            }
            Pokemon noPoke = new Pokemon();
            return noPoke;
        }

        public Pokemon GeneratorExistingRandomPokemon(List<Pokemon> pokedex)
        {
            int rng = RNGGen(1, pokedex.Count);
            Pokemon newExPoke = new Pokemon();
            newExPoke = pokedex[rng];
            LevelByAmount(newExPoke, RNGGen(1, 100));
            newExPoke.AssignMoves();
            return newExPoke;
        }

        public Pokemon GeneratorExistingRandomPokemon(List<Pokemon> pokedex, int floor, int ceiling)
        {
            int rng = RNGGen(1, pokedex.Count);
            Pokemon newExPoke = new Pokemon();
            newExPoke = pokedex[rng];
            LevelByAmount(newExPoke, RNGGen(floor, ceiling));
            newExPoke.AssignMoves();
            return newExPoke;
        }

        private static int RNGGen(int lowerbound, int upperbound)
        {
            Random random = new Random();
            return random.Next(lowerbound, upperbound);
        }

        private static void LevelByAmount(Pokemon pokemon, int value)
        {
            for (int i = 0; i < value; i++)
            {
                pokemon.LevelUp();
                //pokemon.PrintMyPokemonInfo();
            }
        }

        public string RandomType()
        {
            string[] types = { "Normal", "Fire", "Water", "Grass", "Electric", "Ice", "Fighting", "Poison", "Ground", "Flying", "Psychic", "Bug", "Rock", "Ghost", "Dark", "Dragon", "Steel", "Fairy" };
            Random rand = new Random();
            int index = rand.Next(types.Length);
            return types[index];
        }
    }
}