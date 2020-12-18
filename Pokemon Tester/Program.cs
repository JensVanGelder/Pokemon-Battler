using System.Collections.Generic;
using System;

namespace Pokemon_Tester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Pokemon> pokedex = new List<Pokemon>();
            List<Pokemon> myPokes = new List<Pokemon>();
            List<Pokemon> myPokesRead = new List<Pokemon>();
            List<Pokemon> enemyPokes = new List<Pokemon>();
            DataManager dataManager = new DataManager();
            FileReaderWriter fileReaderWriter = new FileReaderWriter();
            Generators generator = new Generators();
            TypeAdvantages adv = new TypeAdvantages();
            Battle battle = new Battle();
            const string PATHDEX = "Pokedex.txt";
            const string PATHMYPOKE = "myPoke.txt";
            const string PATHMYPOKEFULL = "myPokeFull.txt";
            const string PATHENEMYPOKE = "enemyPoke.txt";
            dataManager.PokedexExists(pokedex, PATHDEX);

            Pokemon randomPoke1 = generator.GeneratorExistingRandomPokemon(pokedex, 30, 35);
            Pokemon randomPoke2 = generator.GeneratorExistingRandomPokemon(pokedex, 30, 35);
            Pokemon rand1 = generator.GeneratorMyPokemon(pokedex, "Charmander", 30);
            Pokemon rand2 = generator.GeneratorMyPokemon(pokedex, "Abomasnow", 30);
            //Pokemon lvl100 = generator.GeneratorMyPokemon(pokedex, "Mew", 99);
            myPokes.Add(randomPoke1);

            //Read pokemons from file, print full info in console, choose one of the read pokemon and let it battle x times, write back to file
            fileReaderWriter.ReadMyPokemon(myPokes, myPokesRead, PATHMYPOKE);
            foreach (Pokemon i in myPokesRead)
            {
                Console.WriteLine(i.PrintFullPokemonInfo());
            }
            battle.BattleRandomXTimes(myPokesRead[5], 10, pokedex, enemyPokes, 30, 35);

            fileReaderWriter.WritePokemonToFile(myPokesRead, PATHMYPOKE, false);

            //Print Full info about pokemon in console
            //Console.WriteLine(randomPoke1.PrintFullPokemonInfo());
            //Console.WriteLine(randomPoke2.PrintFullPokemonInfo());

            //Show X times random generated battles
            //battle.BattleRandomXTimes(randomPoke1, 10, pokedex, enemyPokes, 30, 35);

            //Show 1 battle between two pokemon
            //battle.ShowBattle(rand1, rand2);

            //fileReaderWriter.WritePokemonToFileFull(myPokes, PATHMYPOKEFULL);
            //fileReaderWriter.WritePokemonToFile(myPokes, PATHMYPOKE, true);
            //fileReaderWriter.WritePokemonToFileFull(enemyPokes, PATHENEMYPOKE);
        }
    }
}