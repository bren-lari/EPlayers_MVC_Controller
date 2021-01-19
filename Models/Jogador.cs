using System.Collections.Generic;
using System.IO;
using EPlayers_MVC.Interfaces;

namespace EPlayers_MVC.Models
{
    public class Jogador : EPlayersBase , IJogador
    {
        public int IdJogador { get; set; }

        public string Nome { get; set; }

        public int IdEquipe { get; set; }

        public string Email { get; set; }
        public string Senha { get; set; }

        private const string PATH = "Database/Jogador.csv";

        public Jogador(){
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Jogador j){
            return $"{j.IdJogador};{j.Nome};{j.IdEquipe};{j.Email};{j.Senha}";
        }

            public void Create(Jogador j){
            string[] linhas = {Prepare(j)};
            File.AppendAllLines(PATH, linhas);
        }

        public void Delete(int id){

            List<string> linhas  = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());


            RewriteCSV(PATH , linhas);

        }


            public List<Jogador> ReadAll(){
            List<Jogador> jogadores = new List<Jogador>();

            string [] linhas = File.ReadAllLines(PATH);


            foreach(var item in linhas){
                string[] linha = item.Split(";");

                Jogador jogador = new Jogador();

                jogador.IdJogador = int.Parse( linha[0]);
                jogador.Nome = (linha [1]);
                jogador.Email = (linha [2]);
                jogador.Senha =(linha [3]);

                jogadores.Add(jogador);
            }


            return jogadores;
        }


             public void Uptade(Jogador j){
            List<string> linhas  = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());

            linhas.Add( Prepare(j));

            RewriteCSV(PATH , linhas);
        }

    }
}