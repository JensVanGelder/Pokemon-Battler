using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Pokemon_Tester
{
    class DataManager
    {
        public void CreatePokedexFromOnline(List<Pokemon> pokedex)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string downloaded = wc.DownloadString("https://bit.ly/2tE4CB0");
            string[] lines = downloaded.Split('\n');

            for (int i = 1; i < lines.Length - 1; i++)
            {
                string singlePoke_Line = lines[i];

                string[] data = singlePoke_Line.Split(',');

                Pokemon poketemp = new Pokemon()
                {
                    Name = data[1],
                    Number = Convert.ToInt32(data[0]),
                    Type = data[2],
                    Type2 = data[3],
                    HP_Base = Convert.ToInt32(data[5]),
                    Attack_Base = Convert.ToInt32(data[6]),
                    Defense_Base = Convert.ToInt32(data[7]),
                    SpecialAttack_Base = Convert.ToInt32(data[8]),
                    SpecialDefense_Base = Convert.ToInt32(data[9]),
                    Speed_Base = Convert.ToInt32(data[10])
                };

                pokedex.Add(poketemp);
            }
        }
        public void CreatePokedexFromLocal(List<Pokemon> pokedex,string path)
        {
            string[] lines = File.ReadAllLines(path);

            for (int i = 1; i < lines.Length - 1; i++)
            {
                string singlePoke_Line = lines[i];

                string[] data = singlePoke_Line.Split('|');

                Pokemon poketemp = new Pokemon()
                {
                    Name = data[1],
                    Number = Convert.ToInt32(data[0]),
                    Type = data[2],
                    Type2 = data[3],
                    HP_Base = Convert.ToInt32(data[5]),
                    Attack_Base = Convert.ToInt32(data[6]),
                    Defense_Base = Convert.ToInt32(data[7]),
                    SpecialAttack_Base = Convert.ToInt32(data[8]),
                    SpecialDefense_Base = Convert.ToInt32(data[9]),
                    Speed_Base = Convert.ToInt32(data[10])
                };

                pokedex.Add(poketemp);
            }
        }

        public void PokedexExists(List<Pokemon> pokedex, string path)
        {
            FileReaderWriter fileReaderWriter = new FileReaderWriter();
            if (!File.Exists(path))
            {
                CreatePokedexFromOnline(pokedex);
                fileReaderWriter.WriteDexToFile(pokedex, path);
            }
            else
            {
                CreatePokedexFromLocal(pokedex, path);
            }
        }
    }
}
