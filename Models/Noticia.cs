using System;
using System.Collections.Generic;
using System.IO;
using EPlayers_MVC.Interfaces;

namespace EPlayers_MVC.Models
{
    public class Noticia : EPlayersBase , INoticia  
    {
        public int IdNoticias { get; set; }

        public string Titulo { get; set; }

        public string Texto { get; set; }

        public string Imagem { get; set; }


         private const string PATH = "Database/Noticia.csv";

         public Noticia(){
            CreateFolderAndFile(PATH);
        }
        
        public string Prepare(Noticia news){
            return $"{news.IdNoticias};{news.Titulo};{news.Texto};{news.Imagem}";
        }

            public void Create(Noticia news){
            string[] linhas = {Prepare(news)};
            File.AppendAllLines(PATH, linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas  = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());


            RewriteCSV(PATH , linhas);
        }

             public List<Noticia> ReadAll(){
            List<Noticia> noticias = new List<Noticia>();

            string [] linhas = File.ReadAllLines(PATH);


            foreach(var item in linhas){
                string[] linha = item.Split(";");

                Noticia news = new Noticia();

                news.IdNoticias = int.Parse( linha[0]);
                news.Titulo = (linha [1]);
                news.Texto = (linha [2]);
                news.Imagem = (linha[3]);

                noticias.Add(news);
            }


            return noticias;
        }
            
        
            public void Uptade(Noticia news){
            List<string> linhas  = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == news.IdNoticias.ToString());

            linhas.Add( Prepare(news));

            RewriteCSV(PATH , linhas);
        }

    } 
       
        }
