//using Almoxarifado.UI.MVC.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Security;

//namespace Almoxarifado.UI.MVC.Models
//{
//    public class CadastroController : Controller
//    {
//        #region Usuários

//        private const string _senhaPadrao = "{$127;$188}";

//        [Authorize]
//        public ActionResult Usuario()
//        {
//            ViewBag.SenhaPadrao = _senhaPadrao;
//            return View(UsuarioModel.RecuperarLista());
//        }

//        [HttpPost]
//        [Authorize]
//        [ValidateAntiForgeryToken]
//        public ActionResult RecuperarUsuario(Guid id)
//        {
//            return Json(UsuarioModel.RecuperarPeloId(id));
//        }

//        [HttpPost]
//        [Authorize]
//        [ValidateAntiForgeryToken]
//        public ActionResult ExcluirUsuario(Guid id)
//        {
//            return Json(UsuarioModel.ExcluirPeloId(id));
//        }

//        [HttpPost]
//        [Authorize]
//        [ValidateAntiForgeryToken]
//        public ActionResult SalvarUsuario(UsuarioModel model)
//        {
//            var resultado = "OK";
//            var mensagens = new List<string>();
//            var idSalvo = string.Empty;

//            if (!ModelState.IsValid)
//            {
//                resultado = "AVISO";
//                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
//            }
//            else
//            {
//                try
//                {
//                    if (model.Senha == _senhaPadrao)
//                    {
//                        model.Senha = "";
//                    }

//                    var id = model.Salvar();
//                    if (id > 0)
//                    {
//                        idSalvo = id.ToString();
//                    }
//                    else
//                    {
//                        resultado = "ERRO";
//                    }
//                }
//                catch (Exception ex)
//                {
//                    resultado = "ERRO";
//                }
//            }

//            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
//        }

//        #endregion


//    }
//}