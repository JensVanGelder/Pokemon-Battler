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
    }
}