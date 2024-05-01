using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using ProjetoPixelPlace.Entities;
using ProjetoPixelPlace.Models;

namespace ProjetoPixelPlace.Controllers
{
    public class UsuarioController : Controller
    {
        //Oi pra quem tiver lendo, espero que voce não entenda nada, e q eu esteja r.i.p


        //model do banco de dados
        UsuarioModel model = new UsuarioModel();



        //colocar como parametrom, email e senha, ver se existe esse usuario, caso existir, coloca ele em uma session
        public ActionResult Logar()
        {

            // era pra ser model.ValidaUser(), mas criei usuario de teste
            //criei um usuario teste
            Usuario user = new Usuario(null, "Joao", null, "kaio", "1234");


            //e retornei a index de listar, mas deveria validar se ele realmente esta logado;
            return RedirectToAction("Listagem");
        }

        //index cadastrar, aqui vira o model.inserirUsuario...
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Listagem()
        {
            //aqui eu vejo se ele realmente pode estar aqui...
            if (HttpContext.Session.GetString("user") != null)
            {
                //caso puder, eu disponibilizo a lista
                List<Usuario> users = model.getAllUser();
                return View(users);
            }
            //caso nao tiver, eu devolvo a lista vazia *(fazer um validacao no index, caso a lista estiver vazia,
            //retornar a tela de erro
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details()
        {
            return View();

        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //aqui é o create do usuario...
        public ActionResult Create(string nomeUsuario, string email, string senha)
        {
            try
            {
                byte[] imagem = null;
                var msg = "";

                //crio um user
                Usuario u = new Usuario(null, nomeUsuario, imagem, email, senha);
                //insiro o user e guardo a resposta..
                msg = model.inserirUsuario(u);

                //se a mensagem for sucedida, mando pro index, caso nao retorno a mensagem de erro pra mesma view, criar um dialogo sobre isso
                if (msg == "Usuário cadastrado com sucesso")
                {

                    //coloquei ele numa session
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(u));

                    // e retorno a imagem
                    return RedirectToAction(nameof(Listagem));
                }
                    


                //para parar de dar erro, somente produzir uma mensagem de erro 
                //utilizo assim por debug somente
                return View(msg);
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Listagem));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Listagem));
            }
            catch
            {
                return View();
            }
        }
    }
}
