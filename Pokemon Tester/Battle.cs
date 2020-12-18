using System;
using System.Collections.Generic;
using System.Threading;

namespace Pokemon_Tester
{
    internal class Battle
    {
        private static int winner;
        private TypeAdvantages adv = new TypeAdvantages();

        public void BattleRandomXTimes(Pokemon poke1, int amountBattles, List<Pokemon> pokedex, List<Pokemon> enemyPokes, int floor = 1, int ceiling = 100)
        {
            Generators generator = new Generators();
            for (int i = 0; i < amountBattles; i++)
            {
                Pokemon newPoke2 = generator.GeneratorExistingRandomPokemon(pokedex, floor, ceiling);
                enemyPokes.Add(newPoke2);
                ShowBattle(poke1, newPoke2);
                Thread.Sleep(2500);
            }
        }

        private static int DoBasicBattle(Pokemon poke1, Pokemon poke2)
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"   {poke1.PrintBasicInfo()}");
            Console.ResetColor();
            Console.Write("\n│");
            Console.Write($"\t\t              VS");
            Console.Write("\n│");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"   {poke2.PrintBasicInfo()}");
            Console.ResetColor();
            Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────┘");
            DoBattle(poke1, poke2);
            Console.WriteLine("\t│");
            Console.Write("\t│");
            PrintWinner(poke1, poke2);

            Console.WriteLine("\n\t└─────────────────────────────────────────────────────────────────────┘\n");
        }

        private static void PrintWinner(Pokemon poke1, Pokemon poke2)
        {
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

        public int DamageCalc(Pokemon poke1, Pokemon poke2)
        {
            // damage = (((((2*poke1.level)/5)+2)*MovePower*(poke1.attack/poke2.defense)/50)+2)
            double poke2def = poke2.Defense_Full;
            double poke1atk = poke1.Attack_Full;
            double poke1level = poke1.Level;
            poke1.HP_Current = poke1.HP_Full;
            poke2.HP_Current = poke2.HP_Full;
            double multiplier = adv.GetTypeMultiplier(poke1, poke2);
            double damage = Math.Ceiling((((((((2.0 * poke1level) / 5.0) + 2) * 50) * (poke1atk / poke2def)) / 50) + 2) * multiplier);
            return Convert.ToInt32(damage);
        }

        public int DamageCalcSp(Pokemon poke1, Pokemon poke2)
        {
            // damage = (((((2*poke1.level)/5)+2)*MovePower*(poke1.attack/poke2.defense)/50)+2)
            double poke2SpDef = poke2.SpecialDefense_Full;
            double poke1SpAtk = poke1.SpecialAttack_Full;
            double poke1level = poke1.Level;
            poke1.HP_Current = poke1.HP_Full;
            poke2.HP_Current = poke2.HP_Full;
            double multiplier = adv.GetTypeMultiplier(poke1, poke2);
            double damage = Math.Ceiling((((((((2.0 * poke1level) / 5.0) + 2) * 50) * (poke1SpAtk / poke2SpDef)) / 50) + 2) * multiplier);
            return Convert.ToInt32(damage);
        }

        public int CheckifSp(Pokemon poke1, Pokemon poke2)
        {
            if (poke1.SpecialAttack_Full > poke1.Attack_Full)
            {
                Console.WriteLine($"\t│   {poke1.Name} is a Special based attacker");
                return DamageCalcSp(poke1, poke2);
            }
            else
            {
                Console.WriteLine($"\t│   {poke1.Name} is a Normal based attacker");
                return DamageCalc(poke1, poke2);
            }
        }

        public string CheckWeakness(Pokemon poke1, Pokemon poke2)
        {
            double weakness = adv.GetTypeMultiplier(poke1, poke2);
            switch (weakness)
            {
                case 4:
                    return "4x effective";

                case 2:
                    return "2x effective";

                case 1:
                    return "1x effective";

                case 0.5:
                    return "0.5x effective";
                default:
                    return "";
            }
        }

        public void DoBattle(Pokemon poke1, Pokemon poke2)
        {
            if (poke1.Speed_Full > poke2.Speed_Full)
            {
                BattleCalc(poke2, poke1);
            }
            else
            {
                BattleCalc(poke1, poke2);
            }

            if (poke1.HP_Current > poke2.HP_Current)
            {
                winner = 1;
                poke1.LevelUp();
                poke1.WinBattle();
            }
            else
            {
                winner = 2;
                poke2.LevelUp();
                poke2.WinBattle();
            }
        }

        public void BattleCalc(Pokemon poke1, Pokemon poke2)
        {
            int poke1DMG = CheckifSp(poke1, poke2);
            int poke2DMG = CheckifSp(poke2, poke1);
            Console.WriteLine($"\t│   {poke2.Name} is faster than {poke1.Name}");
            Console.WriteLine("\t└─────────────────────────────────────────────────────────────────────┘");
            do
            {
                Thread.Sleep(1500);
                poke1.TakeDamage(poke2DMG);
                Console.WriteLine($"\t│   {poke1.Name} takes {poke2DMG}DMG    {CheckWeakness(poke2, poke1)}");
                Console.WriteLine($"\t│      HP({poke1.HP_Current}/{poke1.HP_Full}) [{HpBar(poke1)}]\n\t│");
                if (poke1.HP_Current <= 0)
                {
                    Console.WriteLine("\t└─────────────────────────────────────────────────────────────────────┘");
                    break;
                }
                poke2.TakeDamage(poke1DMG);
                Console.WriteLine($"\t│   {poke2.Name} takes {poke1DMG}DMG    {CheckWeakness(poke1, poke2)}");
                Console.WriteLine($"\t│      HP({poke2.HP_Current}/{poke2.HP_Full}) [{HpBar(poke2)}]");
                Console.WriteLine("\t└─────────────────────────────────────────────────────────────────────┘");
            } while (poke1.HP_Current > 0 && poke2.HP_Current > 0);
            if (poke1.HP_Current <= 0)
            {
                Console.WriteLine($"\t│   {poke1.Name} has fainted.");
            }
            else
            {
                Console.WriteLine($"\t│   {poke2.Name} has fainted.");
            }
        }

        public string HpBar(Pokemon poke)
        {
            int hpPercentage = Convert.ToInt32((Convert.ToDouble(poke.HP_Current) / Convert.ToDouble(poke.HP_Full)) * 100);

            string hpBar = "";
            for (int i = 0; i < hpPercentage / 5; i++)
            {
                hpBar += "#";
            }
            if (hpPercentage <= 4 && hpPercentage >= 1)
            {
                hpBar = "#";
            }
            while (hpBar.Length != 20)
            {
                hpBar += "-";
            }
            return hpBar;
        }
    }
}