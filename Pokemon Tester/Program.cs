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
            TypeAdvantages adv = new TypeAdvantages();
            Battle battle = new Battle();
            const string PATHDEX = "Pokedex.txt";
            const string PATHMYPOKE = "myPoke.txt";
            const string PATHMYPOKEFULL = "myPokeFull.txt";
            const string PATHENEMYPOKE = "enemyPoke.txt";
            dataManager.PokedexExists(pokedex,PATHDEX);


            Pokemon randomPoke1 =  generator.GeneratorExistingRandomPokemon(pokedex,30,35);
            Pokemon randomPoke2 = generator.GeneratorExistingRandomPokemon(pokedex,30,35);
            Pokemon rand1 = generator.GeneratorMyPokemon(pokedex, "Charmander", 30);
            Pokemon rand2 = generator.GeneratorMyPokemon(pokedex, "Abomasnow", 30);
            //Pokemon lvl100 = generator.GeneratorMyPokemon(pokedex, "Mew", 99);
            //myPokes.Add(randomPoke1);

            //Console.WriteLine(randomPoke1.PrintFullPokemonInfo());
            //Console.WriteLine(randomPoke2.PrintFullPokemonInfo());


            battle.BattleRandomXTimes(randomPoke1, 15, pokedex, enemyPokes,30,35);

            //Console.WriteLine(rand1.PrintBasicInfo());
            //Console.WriteLine(rand2.PrintBasicInfo());
            //Console.WriteLine(adv.GetTypeMultiplier(rand1,rand2));
            //battle.ShowBattle(rand1, rand2);

            //fileReaderWriter.ReadMyPokemon(myPokes, myPokes, PATHMYPOKE);

            //battle.BattleRandomXTimes(myPokes[4], 10, pokedex, enemyPokes);

            //Console.WriteLine(randomPoke1.PrintMyPokeInfo());


            //foreach (Pokemon i in myPokesRead)
            //{
            //    Console.WriteLine(myPokesRead);
            //}



            //fileReaderWriter.WritePokemonToFileFull(myPokes, PATHMYPOKEFULL);
            //fileReaderWriter.WritePokemonToFile(myPokes, PATHMYPOKE, true);
            //fileReaderWriter.WritePokemonToFileFull(enemyPokes, PATHENEMYPOKE);
        }




    }
}