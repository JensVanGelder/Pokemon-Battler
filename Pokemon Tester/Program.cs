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
            List<Pokemon> enemyPokes = new List<Pokemon>();
            DataManager dataManager = new DataManager();
            FileReaderWriter fileReaderWriter = new FileReaderWriter();
            const string PATHDEX = "C:/Users/jens/desktop/MyFolder/Pokedex.txt";
            const string PATHMYPOKE = "C:/Users/jens/desktop/MyFolder/myPoke.txt";
            const string PATHENEMYPOKE = "C:/Users/jens/desktop/MyFolder/enemyPoke.txt";
            dataManager.CreatePokedex(pokedex);
            fileReaderWriter.WriteDexToFile(pokedex, PATHDEX);

            //Pokemon doesntExist = GeneratorMyPokemon(pokedex, "Cagagzg", 5);
            ////doesntExist.PrintMyPokemonInfo();
            //Pokemon charmander = GeneratorMyPokemon(pokedex, "Charmander", 3);
            ////charmander.PrintMyPokemonInfo();

            //Pokemon randomPoke1 = GeneratorExistingRandomPokemon(pokedex);
            //Pokemon randomPoke2 = GeneratorExistingRandomPokemon(pokedex);

            //randomPoke1.PrintMyPokemonInfo();

            //Pokemon newPoke1 = GeneratorNewOriginalPokemon(pokedex,"Handgelsaur");
            //Pokemon newPoke2 = GeneratorNewOriginalPokemon(pokedex,"Coronachu");

            //ShowBattle(randomPoke1, newPoke2);
            //ShowBattle(randomPoke1, doesntExist);
            //ShowBattle(randomPoke1, newPoke1);
            //ShowBattle(randomPoke1, randomPoke2);
            //ShowBattle(randomPoke1, charmander);

            //randomPoke1.PrintMyPokemonInfo();

            //Pokemon randomPoke1 = GeneratorExistingRandomPokemon(pokedex);
            //Pokemon poke100 = GeneratorMyPokemon(pokedex, "Absol", 100);
            //ShowBattle(randomPoke1, poke100);
            //poke100.PrintMyPokemonInfo();

            Pokemon randomPoke1 = GeneratorExistingRandomPokemon(pokedex);
            myPokes.Add(randomPoke1);

            for (int i = 0; i < 3; i++)
            {
                Pokemon newPoke2 = GeneratorExistingRandomPokemon(pokedex);
                enemyPokes.Add(newPoke2);
                ShowBattle(randomPoke1, newPoke2);
                Thread.Sleep(500);
            }

            fileReaderWriter.WritePokemonToFile(myPokes, PATHMYPOKE);
            fileReaderWriter.WritePokemonToFile(enemyPokes, PATHENEMYPOKE);
        }

        private static Pokemon GeneratorNewOriginalPokemon(List<Pokemon> pokedex, string name)
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

        private static Pokemon GeneratorMyPokemon(List<Pokemon> pokedex, string name, int level)
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

        private static Pokemon GeneratorExistingRandomPokemon(List<Pokemon> pokedex)
        {
            int rng = RNGGen(1, pokedex.Count);
            Pokemon newExPoke = new Pokemon();
            newExPoke = pokedex[rng];
            LevelByAmount(newExPoke, RNGGen(1, 100));
            return newExPoke;
        }

        private static int Battle(Pokemon poke1, Pokemon poke2)
        {
            if (poke1 is null && poke2 is null)
            {
                return 0;
            }
            else if (poke1 is null)
            {
                return 2;
            }
            else if (poke2 is null)
            {
                return 1;
            }
            else
            {
                if (poke1.Average_Full == poke2.Average_Full)
                {
                    return 0;
                }
                else if (poke1.Average_Full > poke2.Average_Full)
                {
                    poke1.LevelUp();
                    poke1.WinBattle();
                    return 1;
                }
                else
                {
                    poke2.LevelUp();
                    poke2.WinBattle();
                    return 2;
                }
            }
        }

        private static void ShowBattle(Pokemon poke1, Pokemon poke2)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n   {poke1.PrintBasicInfo(poke1)} ");
            Console.ResetColor();
            Console.WriteLine($"\n\t\t      VS");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n   {poke2.PrintBasicInfo(poke2)}");
            Console.ResetColor();
            Console.WriteLine($"\n----------------------------------------------");
            PrintWinner(poke1, poke2);
            Console.WriteLine($"\n----------------------------------------------");
        }

        private static void PrintWinner(Pokemon poke1, Pokemon poke2)
        {
            int winner = Battle(poke1, poke2);
            if (winner == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (poke1.Level >= 100)
                {
                    Console.WriteLine($"\n    {poke1.Name} wins!");
                }
                else
                {
                    Console.WriteLine($"\n   {poke1.Name} wins! {poke1.Name} leveled up! {poke1.Level - 1}->{poke1.Level}");
                }
                Console.ResetColor();
            }
            else if (winner == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (poke2.Level >= 100)
                {
                    Console.WriteLine($"\n    {poke2.Name} wins!");
                }
                else
                {
                    Console.WriteLine($"\n   {poke2.Name} wins! {poke2.Name} leveled up! {poke2.Level - 1}->{poke2.Level}");
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n\t       Tie!");
                Console.ResetColor();
            }
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