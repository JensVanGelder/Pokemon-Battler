using System;
using System.Collections.Generic;

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

        private string asciiTitle = @"
        ██████╗  ██████╗ ██╗  ██╗███████╗███╗   ███╗ █████╗ ███╗   ██╗███████╗
        ██╔══██╗██╔═══██╗██║ ██╔╝██╔════╝████╗ ████║██╔══██╗████╗  ██║██╔════╝
        ██████╔╝██║   ██║█████╔╝ █████╗  ██╔████╔██║███████║██╔██╗ ██║███████╗
        ██╔═══╝ ██║   ██║██╔═██╗ ██╔══╝  ██║╚██╔╝██║██╔══██║██║╚██╗██║╚════██║
        ██║     ╚██████╔╝██║  ██╗███████╗██║ ╚═╝ ██║██║  ██║██║ ╚████║███████║
        ╚═╝      ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝
                                                                              

";
        public void MainMenu()
        {
            dataManager.PokedexExists(pokedex, PATHDEX);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(asciiTitle);
            Console.Write("Press a button to continue.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(asciiTitle);

            Console.WriteLine("Modes:" +
                "\n1.Choose your own pokemon" +
                "\n2.Random pokemon");
            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.NumPad1)
            {
                string poke1 = "";
                string poke2 = "";
                int level = 50;
                Console.WriteLine("Choose your pokemon.");
                Console.Write("\nName:");
                poke1 = Console.ReadLine();
                Console.WriteLine("Choose enemy pokemon.");
                Console.Write("\nName:");
                poke2 = Console.ReadLine();
                Console.WriteLine("Choose their level");
                Console.Write("\nLevel:");
                level = Convert.ToInt32(Console.ReadLine());
                Battle2ChosenPoke(poke1, poke2, level);
            }
            else if (cki.Key == ConsoleKey.NumPad2)
            {
                BattleXTimes(3, 50, 55);
            }
            else
            {
                Console.WriteLine("ERROR");
                MainMenu();
            }
        }

        public void BattleXTimes(int amountBattles, int lowestLvl, int highestLvl)
        {
            Pokemon randomPoke1 = generator.GeneratorExistingRandomPokemon(pokedex, lowestLvl,highestLvl);
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
