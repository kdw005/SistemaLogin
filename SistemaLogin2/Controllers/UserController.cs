using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaLogin2.Models;
using SistemaLogin2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLogin2.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login(int? Id)
        {
            if (Id != null)
            {
                if (Id == 0)
                {
                    HttpContext.Session.SetString("NomeUsuarioLogado",String.Empty);
                    HttpContext.Session.SetString("IdUsuarioLogado", String.Empty);
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult ValidarLogin(UserModel user)
        {
            
            bool login = user.ValidarLogin();
            if (login)
            {
                HttpContext.Session.SetString("NomeUsuarioLogado", user.Nome);
                HttpContext.Session.SetString("IdUsuarioLogado", user.Id.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["MensagemLoginInvalido"] = "Dados de login inválidos"; 
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public IActionResult registrar(UserModel user)
        {
            if (ModelState.IsValid)
            {
                //registrar usuario
                user.RegistrarUsuario();
                return RedirectToAction("Sucesso");
            }
            return View();
        }
        [HttpGet]
        public IActionResult registrar()
        {
            return View();
        }
        public IActionResult Sucesso()
        {
            return View();
        }
    }
}
