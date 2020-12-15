using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Pokemon_Tester
{
    class FileReaderWriter
    {
        public void WriteDexToFile(List<Pokemon> lines,string path)
        {
            using StreamWriter writer = new StreamWriter(path, false);
            for (int i = 0; i < lines.Count; i++)
            {
                writer.WriteLine(lines[i].PrintDexInfo());
            }
        }
        public void WritePokemonToFile(List<Pokemon> lines, string path)
        {
            using StreamWriter writer = new StreamWriter(path, true);
            for (int i = 0; i < lines.Count; i++)
            {
                writer.WriteLine(lines[i].PrintMyPokemonInfo());
            }
        }
        public void ReadDataFromFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}
