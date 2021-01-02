using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon_Tester
{
    class Game
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

        public void MainMenu()
        {
            dataManager.PokedexExists(pokedex, PATHDEX);
            Console.WriteLine("Welcome");
            Console.Write("Press a button to continue.");
            Console.ReadLine();
            Console.Clear();
            //Battle2ChosenPoke("Charmander","Squirtle",100);
            BattleXTimes(3);
        }

        public void BattleXTimes(int amountBattles)
        {
            Pokemon randomPoke1 = generator.GeneratorExistingRandomPokemon(pokedex, 30, 35);
            myPokes.Add(randomPoke1);
            battle.BattleRandomXTimes(randomPoke1, amountBattles, pokedex, enemyPokes, randomPoke1.Level + randomPoke1.BattlesWon, randomPoke1.Level + randomPoke1.BattlesWon + 2);
            fileReaderWriter.WritePokemonToFileFull(myPokes, PATHMYPOKEFULL);
            fileReaderWriter.WritePokemonToFile(myPokes, PATHMYPOKE, true);
            fileReaderWriter.WritePokemonToFileFull(enemyPokes, PATHENEMYPOKE);
        }
        public void Battle2ChosenPoke(string name, string name2, int level)
        {
            Pokemon rand1 = generator.GeneratorMyPokemon(pokedex, name, level);
            Pokemon rand2 = generator.GeneratorMyPokemon(pokedex, name2, level);
            battle.ShowBattle(rand1, rand2);
        }
    }
}
