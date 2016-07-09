using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoStudio.WebApp.Controllers
{
    public class MyPageController : Controller
    {
        // 我的个人资料
        public ActionResult Index()
        {
            int Uid = 0;
            try
            {
                Uid = Convert.ToInt32(Session["UID"]);
            }
            catch
            {

            }
            ViewBag.UID = Uid;
            return View();
        }
        // 个人资料修改
        public ActionResult Modify()
        {
            int Uid = 0;
            try
            {
                Uid = Convert.ToInt32(Session["UID"]);
            }
            catch
            {

            }
            ViewBag.UID = Uid;
            var sexselects = new List<string>() { "男", "女" };
            var lstsex = new List<SelectListItem>();
            foreach (var sexselect in sexselects)
            {
                lstsex.Add(new SelectListItem { Text = sexselect, Value = sexselect });
            }
            ViewBag.lstsex = lstsex;
            return View();
        }
        public ActionResult Edit()
        {
            try
            {
                int UID = Convert.ToInt32(Session["UID"].ToString());
                string name = Request["name"];
                string getsex = Request["sex"];
                string edu = Request["edu"];
                string birth = Request["birth"];
                string tel = Request["Tel"];
                string email = Request["Email"];
                string place = Request["Place"];
                string IDcard = Request["IDcard"];
                string passWard = Request["pwd"];
                int sex = 0;
                if (getsex.Trim()== "男")
                {
                    sex = 0;
                }
                else
                {
                    sex = 1;
                }
                PhotoStudio.Model.Staff umodel = new PhotoStudio.Model.Staff();
                PhotoStudio.Model.Staff ymodel = new PhotoStudio.BLL.Staff().GetModel(UID);
                try
                {
                    umodel.Birth = Convert.ToDateTime(birth);
                }
                catch
                {
                    umodel.Birth = ymodel.Birth;
                }
                umodel.ID = UID;
                umodel.Edu = edu;
                umodel.Email = email;
                umodel.IDCard = IDcard;
                umodel.JoinTime = ymodel.JoinTime;
                umodel.Name = name;
                umodel.PassWord = passWard;
                umodel.Place = place;
                umodel.Power = ymodel.Power;
                umodel.SeID = ymodel.SeID;
                umodel.Sex = sex;
                umodel.Tel = tel;
                umodel.Wages = ymodel.Wages;
                bool iss=new PhotoStudio.BLL.Staff().Update(umodel);
                return Content("ok:修改成功！:"+iss);
            }
            catch
            {
              return Content("no:修改失败！");
            }
            
        }
    }
}