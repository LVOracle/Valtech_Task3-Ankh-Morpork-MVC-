using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Valtech_Task3_Ankh_Morpork_MVC_.Services;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Controllers
{
    public class TheMendedDrumPubController : Controller
    {
        // GET: TheMendedDrumPub
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BuyBeer(int beer)
        {
            CurrentPlayerProcessor.CurrentPlayer =
                CurrentPlayerProcessor.PlayerManager.FindById(User.Identity.GetUserId());

            if (!CurrentPlayerProcessor.CurrentPlayer.IsBuyingBeer(beer)) return RedirectToAction("ToMuchBeerMan");

            CurrentPlayerProcessor.CurrentPlayer.LoseMoney(beer * 2);

            CurrentPlayerProcessor.PlayerManager.Update(CurrentPlayerProcessor.CurrentPlayer);

            return RedirectToAction("Ok");
        }

        public ActionResult Ok()
        {
            return View();
        }
        public ActionResult ToMuchBeerMan()
        {
            return View();
        }
    }
}