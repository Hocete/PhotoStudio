using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoStudio.Common;

namespace PhotoStudio.WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserLogin()
        {
            string UID = Request["UID"];
            string UserPwd= Request["PWD"];
             
            int userID = 0;
            try
            {
                userID = Convert.ToInt32(UID);
            }
            catch
            {
                userID = 0;
            }
            bool isno = new PhotoStudio.BLL.Staff().Exists(userID,UserPwd);
            if (isno)
            {
                Session["UID"] =UID;
                Session["PWD"] = UserPwd;
                if(Request.Form["Remember"]!=""|| Request.Form["Remember"] != null)
                {
                    Session["rem"] = Request.Form["Remember"];
                }
                return Content("ok:登陆成功！");
            }
            else
            {
                return Content("no:登录失败！");
            }
            
        }
        public ActionResult Forget()
        {
            return View();
        }
        public ActionResult ForgetLogin()
        {
            string UID = Request["UID"].Trim();
            string name = Request["name"].Trim();
            string Tel = Request["Tel"].Trim();
            string Email = Request["Email"].Trim();
            string IDcard = Request["IDcard"].Trim();
            int userID = 0;
            try
            {
                userID = Convert.ToInt32(UID);
            }
            catch
            {
                return Content("no:无效的ID！");
            }
            if (userID != 0 && name != "" && Tel != "" && Email != "" && IDcard != "")
            {
                bool isno = new PhotoStudio.BLL.Staff().Exists(userID, name, Tel, Email, IDcard);
                if (isno)
                {
                    PhotoStudio.Model.Staff ui = new PhotoStudio.BLL.Staff().GetModel(userID);
                    return Content("ok:"+ui.ID+":"+ui.PassWord);
                }
                else
                {
                    return Content("no:取回失败！");
                }
            }
            else
            {
                return Content("no:空的输入！");
            }
        }
        public ActionResult Out()
        {
            Session.Abandon();
            Response.Redirect("/Home");
            return View();
        }
        public ActionResult Out2()
        {
            Session.Abandon();
            Response.Redirect("/Login");
            return View();
        }
    }
}