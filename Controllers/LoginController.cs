using System.Collections.Generic;
using EPlayers_MVC.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_MVC_Controller.Controllers
{
    [Microsoft.AspNetCore.Components.Route("Login")]
    public class LoginController : Controller
    {

        [TempData]
        public string Mensagem { get; set; }
        
        
        Jogador jogador = new Jogador();

        public IActionResult Index()
        {
            return View();
        }
        [Microsoft.AspNetCore.Mvc.Route("Logar")]
        public IActionResult Logar(IFormCollection form){
             List<string> csv = jogador.ReadAllLinesCSV("Database/Jogador.csv");

    // Verificamos se as informações passadas existe na lista de string
            var logado = 
            csv.Find(
                x => 
                x.Split(";")[2] == form["Email"] && 
                x.Split(";")[3] == form["Senha"]
            );


            // Redirecionamos o usuário logado caso encontrado
            if(logado != null)
            {
                return LocalRedirect("~/");
            }

            Mensagem = "Senha ou email incorretos, tente novamente...";
            return LocalRedirect("~/Login");
                }
            }
}