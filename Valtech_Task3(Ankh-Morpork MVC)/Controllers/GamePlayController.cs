﻿using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    public class GamePlayController : Controller
    {
        private GameController GameController => new GameController(User.Identity.GetUserId());
        // GET: GamePlay
        public ActionResult Index()
        {
            if (GameController.MoneyChecker <= 0)
                return RedirectToAction("GameOver");
            return RedirectToAction("Index", GuildProcessor.GetRandomGuild());
        }
        public ActionResult GameOver()
        {
            GameController.GameOver();
            return View();
        }
    }
}