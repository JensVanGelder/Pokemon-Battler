using System;
using System.Collections.Generic;
using System.IO;

namespace Pokemon_Tester
{
    internal class FileReaderWriter
    {
        public void WriteDexToFile(List<Pokemon> lines, string path)
        {
            using StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine("#|Name|Type1|Type2|Total|HP|Attack|Defense|Sp. Atk|Sp. Def|Speed|Average|");
            for (int i = 0; i < lines.Count; i++)
            {
                writer.WriteLine(lines[i].PrintDexInfo());
            }
        }

        public void WritePokemonToFileFull(List<Pokemon> lines, string path)
        {
            using StreamWriter writer = new StreamWriter(path, true);
            for (int i = 0; i < lines.Count; i++)
            {
                writer.WriteLine(lines[i].PrintFullPokemonInfo());
            }
        }

        public void WritePokemonToFile(List<Pokemon> lines, string path, bool truefalse)
        {
            using StreamWriter writer = new StreamWriter(path, truefalse);
            for (int i = 0; i < lines.Count; i++)
            {
                writer.WriteLine(lines[i].PrintMyPokeInfo());
            }
        }

        public void ReadMyPokemon(List<Pokemon> mypoke, List<Pokemon> mypokeRead, string path)
        {
            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                string singlePoke_Line = lines[i];

                string[] data = singlePoke_Line.Split('|');

                Pokemon poketemp = new Pokemon()
                {
                    Name = data[1],
                    Number = Convert.ToInt32(data[0].Substring(1)),
                    Type = data[3],
                    Type2 = data[4],
                    HP_Base = Convert.ToInt32(data[6]),
                    Attack_Base = Convert.ToInt32(data[7]),
                    Defense_Base = Convert.ToInt32(data[8]),
                    SpecialAttack_Base = Convert.ToInt32(data[9]),
                    SpecialDefense_Base = Convert.ToInt32(data[10]),
                    Speed_Base = Convert.ToInt32(data[11]),
                    BattlesWon = Convert.ToInt32(data[5].Substring(12))
                };
                for (int j = 0; j < Convert.ToInt32(data[2]); j++)
                {
                    poketemp.LevelUp();
                }
                mypokeRead.Add(poketemp);
            }
        }
    }
}