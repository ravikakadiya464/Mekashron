using Mekashron.IICUTechService;
using Mekashron.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mekashron.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Login model)
        {
            ICUTechClient iCUTechClient = new ICUTechClient();
            var response = (await iCUTechClient.LoginAsync(model.Username, model.Password, null)).@return;
            var entity = JsonConvert.DeserializeObject<Models.LoginResponse>(response);

            if (!string.IsNullOrEmpty(entity.ResultMessage))
            {
                return Json(new { success = false, data = entity.ResultMessage });
            }
            else
            {
                Session["entity"] = entity;
                return Json(new { success = true, data = entity });
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Register model)
        {
            ICUTechClient iCUTechClient = new ICUTechClient();
            var response = (await iCUTechClient.RegisterNewCustomerAsync(model.Email, model.Password, model.FirstName, model.LastName, model.Mobile, 0, 0, null)).@return;
            var entity = JsonConvert.DeserializeObject<Models.LoginResponse>(response);

            if (!string.IsNullOrEmpty(entity.ResultMessage))
            {
                return Json(new { success = false, data = entity.ResultMessage });
            }
            else
            {
                Session["entity"] = entity;
                return Json(new { success = true, data = entity });
            }
        }

        public ActionResult LoginDetail()
        {
            if (Session["entity"] == null)
            {
                return RedirectToAction("Login");
            }
            return View((Models.LoginResponse)Session["entity"]);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}