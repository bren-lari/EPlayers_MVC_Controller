using System.Collections.Generic;
using System.IO;

namespace EPlayers_MVC.Models
{
    public class EPlayersBase
    {
        public void CreateFolderAndFile(string PATH){

            // Database/Equipe.csv
            string folder = PATH.Split("/")[0];

            if(!Directory.Exists(folder)){
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(PATH)){
                File.Create(PATH);
            }
        }


        public List<string> ReadAllLinesCSV(string PATH){
            List<string> linhas = new List<string>();


            using (StreamReader file = new StreamReader(PATH)){

                string linha;
                while ((linha = file.ReadLine())!= null)
                {
                    linhas.Add(linha);
                }
                    
                
            }


            return linhas;
        }

        public void RewriteCSV(string PATH, List<string> linhas){
            using (StreamWriter ouput = new StreamWriter(PATH)){
                
                foreach (var item in linhas){
                    ouput.Write(item + '\n');
                }
            }
        }

    }
}