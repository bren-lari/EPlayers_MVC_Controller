using System.Collections.Generic;
using EPlayers_MVC.Models;

namespace EPlayers_MVC.Interfaces
{
    public interface IEquipe
    {
         void Create(Equipe e);

        List<Equipe> ReadAll();

        void Uptade(Equipe e);

        void Delete(int id);
    }
}