using System;
using EPlayers_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_MVC.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogador = new Jogador();
        
        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Jogadores = jogador.ReadAll();
           
            return View();
            
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            // criamos uma instância para equipes, através de um formulário armazenamos as informações como: Id da equipe, Nome da equipe e a imagem da equipe
            
           Jogador novoJogador = new Jogador();
            novoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            novoJogador.Nome = form["Nome"];
           novoJogador.IdEquipe = Int32.Parse(form["IdEquipe"]);

            // criamos a equipe para salvar ela no CSV
            // adicionamos ela 
            // e returnamos ela para a mesma página com "LolcalRedirect"
            jogador.Create(novoJogador);

            ViewBag.Jogadores = jogador.ReadAll();

            return LocalRedirect("~/Jogador/Listar");
        }

    }
}