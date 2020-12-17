using System;
using System.Collections.Generic;
using System.Threading;

namespace Pokemon_Tester
{
    internal class Battle
    {
        public void BattleRandomXTimes(Pokemon poke1, int amountBattles, List<Pokemon> pokedex, List<Pokemon> enemyPokes)
        {
            Generators generator = new Generators();
            for (int i = 0; i < amountBattles; i++)
            {
                Pokemon newPoke2 = generator.GeneratorExistingRandomPokemon(pokedex);
                enemyPokes.Add(newPoke2);
                ShowBattle(poke1, newPoke2);
                Thread.Sleep(1000);
            }
        }
        private static int CalcBattle(Pokemon poke1, Pokemon poke2)
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

        public void ShowBattle(Pokemon poke1, Pokemon poke2)
        {
            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────┐");
            Console.Write("│");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"   {poke1.PrintBasicInfo()}");
            Console.ResetColor();
            Console.Write("\n│");
            Console.Write($"\t\t              VS");
            Console.Write("\n│");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"   {poke2.PrintBasicInfo()}");
            Console.ResetColor();
            Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────┘");
            Console.Write("\t│");
            PrintWinner(poke1, poke2);

            Console.WriteLine("\n\t└─────────────────────────────────────────────────────────────────────┘\n");
        }

        private static void PrintWinner(Pokemon poke1, Pokemon poke2)
        {
            int winner = CalcBattle(poke1, poke2);
            if (winner == 1)
            {
                WinnerLoser(poke1, ConsoleColor.Green);
            }
            else if (winner == 2)
            {
                WinnerLoser(poke2, ConsoleColor.Red);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\t       Tie!");
                Console.ResetColor();
            }
        }
        private static void WinnerLoser(Pokemon poke, ConsoleColor color)

        {
            Console.ForegroundColor = color;
            if (poke.Level >= 100)
            {
                Console.Write($"    {poke.Name} wins! {poke.Name} reached max level!");
            }
            else
            {
                Console.Write($"   {poke.Name} wins! {poke.Name} leveled up! {poke.Level - 1}->{poke.Level}");
            }
            Console.ResetColor();
        }
    }
}