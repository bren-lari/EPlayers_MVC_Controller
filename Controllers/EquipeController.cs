using System;
using EPlayers_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_MVC.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller 
    {
        // Serve para podermos acessar com localhost:5001 com /Equipe
    

        Equipe equipeModel = new Equipe();
       
       [Route("Listar")]
        public IActionResult Index()
        {
            // Estamos listando todas as equipes com o método ReadAll(); e armazenados com ViewBag.
           ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            // criamos uma instância para equipes, através de um formulário armazenamos as informações como: Id da equipe, Nome da equipe e a imagem da equipe
            
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome = form["Nome"];
            novaEquipe.Imagem = form["Imagem"];

            // criamos a equipe para salvar ela no CSV
            // adicionamos ela 
            // e returnamos ela para a mesma página com "LolcalRedirect"
            equipeModel.Create(novaEquipe);

            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}