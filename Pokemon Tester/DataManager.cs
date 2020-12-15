using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon_Tester
{
    class DataManager
    {
        public void CreateFile(string file)
        {
            throw new NotImplementedException();
        }
        public void DeleteFile(string file)
        {
            throw new NotImplementedException();
        }
        public bool FileExists(string path)
        {
            throw new NotImplementedException();
        }

        public void CreatePokedex(List<Pokemon> pokedex)
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
    }
}
