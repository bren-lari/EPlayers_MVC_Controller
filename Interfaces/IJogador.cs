using System.Collections.Generic;
using EPlayers_MVC.Models;

namespace EPlayers_MVC.Interfaces
{
    public interface IJogador
    {
         
         void Create(Jogador j);

        List<Jogador> ReadAll();

        void Uptade(Jogador j);

        void Delete(int id);
    }
}