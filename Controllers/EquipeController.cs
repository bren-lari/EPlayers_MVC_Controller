using System;
using System.IO;
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

            // nício do upload de imagem
            // estamos verificando se o usuário anexou pelo menos um arquivo
            if(form.Files.Count > 0)
            {
                // se ele anexar...
                // armazenamos o arquivo/foto na nossa váriavel lista/file
             var file = form.Files[0];
             var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

            //  verificamos se a pasta equipes existe
             if(!Directory.Exists(folder))
             {
                 Directory.CreateDirectory(folder);
             }

             var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", folder, file.FileName);

             using(var stream = new FileStream(path, FileMode.Create))
             {
                //  salvamos o arquivo no caminho 
                 file.CopyTo(stream);
             }
                novaEquipe.Imagem = file.FileName;

            }
            else{
                novaEquipe.Imagem = "padrao.png";
                // término do upload
            }

            equipeModel.Create(novaEquipe);

            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }

            
            // htpps://localhost:5001/Equipe/1
            [Route("id")]
            public IActionResult Excluir(int id){
                equipeModel.Delete(id);
                ViewBag.Equipes = equipeModel.ReadAll();
                
                return LocalRedirect("~/Equipe/Listar");
            }

    }
}