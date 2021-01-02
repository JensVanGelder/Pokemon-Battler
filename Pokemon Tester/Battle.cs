using System;
using System.Collections.Generic;
using System.Threading;

namespace Pokemon_Tester
{
    internal class Battle
    {
        private static int winner;
        private bool isCrit;
        private bool isSP;
        private TypeAdvantages adv = new TypeAdvantages();
        private Random random = new Random();

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

        //private static int DoBasicBattle(Pokemon poke1, Pokemon poke2)
        //{
        //    if (poke1 is null && poke2 is null)
        //    {
        //        return 0;
        //    }
        //    else if (poke1 is null)
        //    {
        //        return 2;
        //    }
        //    else if (poke2 is null)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        if (poke1.Average_Full == poke2.Average_Full)
        //        {
        //            return 0;
        //        }
        //        else if (poke1.Average_Full > poke2.Average_Full)
        //        {
        //            poke1.LevelUp();
        //            poke1.WinBattle();
        //            return 1;
        //        }
        //        else
        //        {
        //            poke2.LevelUp();
        //            poke2.WinBattle();
        //            return 2;
        //        }
        //    }
        //}

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
            RollCrit(poke1);
            double poke1level = poke1.Level;
            double critMult = 1.0;
            CheckIfSP(poke1);
            if (isCrit == true)
            {
                critMult = 2.0;
            }
            double multiplier = adv.GetTypeMultiplier(poke1.currentMoveType, poke2) * MultiplierRand(random, 0.85, 1.0) * critMult;
            double damagecalc2 = Math.Round((((((2.0 * poke1level) / 5.0) + 2) * poke1.currentMoveDmg * GetAttack(poke1) / GetDef(poke2) / 50) + 2) * multiplier);
            return Convert.ToInt32(damagecalc2);
        }

        private void CheckIfSP(Pokemon poke1)
        {
            if (poke1.SpecialAttack_Full > poke1.Attack_Full)
            {
                isSP = true;
            }
            else
            {
                isSP = false;
            }
        }

        private int GetAttack(Pokemon poke)
        {
            if (isSP == true)
            {
                return poke.SpecialAttack_Full;
            }
            else
            {
                return poke.Attack_Full;
            }
        }

        private int GetDef(Pokemon poke)
        {
            if (isSP == true)
            {
                return poke.SpecialDefense_Full;
            }
            else
            {
                return poke.Defense_Full;
            }
        }

        public string PrintWeakness(Pokemon poke1, Pokemon poke2)
        {
            double weakness = adv.GetTypeMultiplier(poke1.currentMoveType, poke2);
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

                case 0:
                    return "not effective";

                default:
                    return "";
            }
        }

        public string PrintCrit()
        {
            if (isCrit == true)
            {
                return "CRITICAL HIT";
            }
            else
            {
                return "";
            }
        }

        public void DoBattle(Pokemon poke1, Pokemon poke2)
        {
            //BattleCalc(poke2, poke1);
            poke1.HP_Current = poke1.HP_Full;
            poke2.HP_Current = poke2.HP_Full;
            if (poke1.Speed_Full > poke2.Speed_Full)
            {
                Console.WriteLine($"\t│   {poke1.Name} is faster than {poke2.Name}");
                Console.WriteLine("\t└─────────────────────────────────────────────────────────────────────┘");
                do
                {
                    poke2.SetCurrentMoveType();
                    PickMove(poke1);
                    PrintBattle(poke2, poke1);
                } while (poke1.HP_Current > 0 && poke2.HP_Current > 0);
                PrintFainted(poke1, poke2);
            }
            else
            {
                Console.WriteLine($"\t│   {poke2.Name} is faster than {poke1.Name}");
                Console.WriteLine("\t└─────────────────────────────────────────────────────────────────────┘");
                do
                {
                    poke2.SetCurrentMoveType();
                    PickMove(poke1);
                    PrintBattle(poke1, poke2);
                } while (poke1.HP_Current > 0 && poke2.HP_Current > 0);
                PrintFainted(poke1, poke2);
            }
            EndBattle(poke1, poke2);
        }

        //public void BattleCalc(Pokemon poke1, Pokemon poke2)
        //{
        //    poke1.HP_Current = poke1.HP_Full;
        //    poke2.HP_Current = poke2.HP_Full;
        //    Console.WriteLine($"\t│   {poke2.Name} is faster than {poke1.Name}");
        //    Console.WriteLine("\t└─────────────────────────────────────────────────────────────────────┘");
        //    do
        //    {
        //        Thread.Sleep(1500);
        //        int poke2DMG = DamageCalc(poke2, poke1);
        //        poke1.TakeDamage(poke2DMG);
        //        Console.WriteLine($"\t│   {poke1.Name} takes {poke2DMG}DMG    {PrintWeakness(poke2, poke1)}    {PrintCrit()} move dmg{damage}");
        //        Console.WriteLine($"\t│      HP({poke1.HP_Current}/{poke1.HP_Full}) [{HpBar(poke1)}]\n\t│");
        //        if (poke1.HP_Current <= 0)
        //        {
        //            Console.WriteLine("\t└─────────────────────────────────────────────────────────────────────┘");
        //            break;
        //        }
        //        int poke1DMG = DamageCalc(poke1, poke2);
        //        poke2.TakeDamage(poke1DMG);
        //        Console.WriteLine($"\t│   {poke2.Name} takes {poke1DMG}DMG    {PrintWeakness(poke1, poke2)}    {PrintCrit()} move dmg{damage}");
        //        Console.WriteLine($"\t│      HP({poke2.HP_Current}/{poke2.HP_Full}) [{HpBar(poke2)}]");
        //        Console.WriteLine("\t└─────────────────────────────────────────────────────────────────────┘");
        //    } while (poke1.HP_Current > 0 && poke2.HP_Current > 0);
        //    if (poke1.HP_Current <= 0)
        //    {
        //        Console.WriteLine($"\t│   {poke1.Name} has fainted.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"\t│   {poke2.Name} has fainted.");
        //    }
        //}
        public void BattleInfo(Pokemon poke1, Pokemon poke2)
        {
            int poke2DMG = DamageCalc(poke2, poke1);
            poke1.TakeDamage(poke2DMG);
            Console.WriteLine($"\t│   {poke2.Name} uses {poke2.currentMoveType} type move");
            Console.WriteLine($"\t│   {poke1.Name} takes {poke2DMG}DMG    {PrintWeakness(poke2, poke1)}    {PrintCrit()}");
            Console.WriteLine($"\t│      HP({poke1.HP_Current}/{poke1.HP_Full}) [{HpBar(poke1)}]\n\t│");
        }

        public void PrintBattle(Pokemon poke1, Pokemon poke2)
        {
            for (int i = 0; i < 1; i++)
            {
                Thread.Sleep(1000);
                BattleInfo(poke1, poke2);
                if (poke1.HP_Current <= 0)
                {
                    Console.WriteLine("\t└─────────────────────────────────────────────────────────────────────┘");
                    break;
                }
                BattleInfo(poke2, poke1);
                Console.WriteLine("\t└─────────────────────────────────────────────────────────────────────┘");
            }
        }

        public void PrintFainted(Pokemon poke1, Pokemon poke2)
        {
            if (poke1.HP_Current <= 0)
            {
                Console.WriteLine($"\t│   {poke1.Name} has fainted.");
            }
            else
            {
                Console.WriteLine($"\t│   {poke2.Name} has fainted.");
            }
        }

        public void EndBattle(Pokemon poke1, Pokemon poke2)
        {
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

        public double MultiplierRand(Random random, double min, double max)
        {
            return min + (random.NextDouble() * (max - min));
        }

        public void RollCrit(Pokemon poke)
        {
            int threshold = poke.Speed_Base / 2;
            int rand = random.Next(0, 255);
            if (rand < threshold)
            {
                isCrit = true;
            }
            else
            {
                isCrit = false;
            }
        }

        public void PickMove(Pokemon poke)
        {
            Console.WriteLine(
                $"\t│   MOVES: " +
                $"\n\t│   1. {poke.Moves[0]}\t\t2. {poke.Moves[1]}" +
                $"\n\t│   3. {poke.Moves[2]}\t\t4. {poke.Moves[3]}");
            Console.WriteLine("\t└─────────────────────────────────────────────────────────────────────┘");

            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);

            if (cki.Key == ConsoleKey.NumPad1)
            {
                poke.currentMoveDmg = 50;
                poke.currentMoveType = poke.Moves[0];
            }
            else if (cki.Key == ConsoleKey.NumPad2)
            {
                poke.currentMoveDmg = 50;
                poke.currentMoveType = poke.Moves[1];
            }
            else if (cki.Key == ConsoleKey.NumPad3)
            {
                poke.currentMoveDmg = 50;
                poke.currentMoveType = poke.Moves[2];
            }
            else if (cki.Key == ConsoleKey.NumPad4)
            {
                poke.currentMoveDmg = 50;
                poke.currentMoveType = poke.Moves[3];
            }
            else
            {
                Console.WriteLine("ERROR");
                PickMove(poke);
            }
        }
    }
}