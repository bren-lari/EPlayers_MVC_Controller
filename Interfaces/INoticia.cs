using System.Collections.Generic;
using EPlayers_MVC.Models;

namespace EPlayers_MVC.Interfaces
{
    public interface INoticia
    {
        void Create(Noticia news);

        List<Noticia> ReadAll();

        void Uptade(Noticia news);

        void Delete(int id);
    }
}