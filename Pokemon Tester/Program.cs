using System;
using System.Collections.Generic;
using System.Threading;

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
            Battle battle = new Battle();
            const string PATHDEX = "Pokedex.txt";
            const string PATHMYPOKE = "myPoke.txt";
            const string PATHMYPOKEFULL = "myPokeFull.txt";
            const string PATHENEMYPOKE = "enemyPoke.txt";
            dataManager.PokedexExists(pokedex,PATHDEX);


            Pokemon randomPoke1 =  generator.GeneratorExistingRandomPokemon(pokedex);
            Pokemon lvl100 = generator.GeneratorMyPokemon(pokedex, "Mew", 99);
            //myPokes.Add(randomPoke1);


            fileReaderWriter.ReadMyPokemon(myPokes, myPokes, PATHMYPOKE);

            battle.BattleRandomXTimes(myPokes[4], 10, pokedex, enemyPokes);

            //Console.WriteLine(randomPoke1.PrintMyPokeInfo());


            //foreach (Pokemon i in myPokesRead)
            //{
            //    Console.WriteLine(myPokesRead);
            //}



            fileReaderWriter.WritePokemonToFileFull(myPokes, PATHMYPOKEFULL);
            fileReaderWriter.WritePokemonToFile(myPokes, PATHMYPOKE,true);
            fileReaderWriter.WritePokemonToFileFull(enemyPokes, PATHENEMYPOKE);
        }




    }
}