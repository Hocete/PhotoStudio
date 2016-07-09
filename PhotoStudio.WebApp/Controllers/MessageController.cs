using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoStudio.WebApp.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message信息提醒添加
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
            var letters = new List<int>() { };
            List<PhotoStudio.Model.Staff> staffs = new PhotoStudio.BLL.Staff().GetModelList("");
            foreach (PhotoStudio.Model.Staff s in staffs)
            {
                letters.Add(s.ID);
            }
            var lstLetters = new List<SelectListItem>();
            foreach (var letter in letters)
            {
                lstLetters.Add(new SelectListItem { Text = letter.ToString(), Value = letter.ToString() });
            }
            ViewBag.Letters = lstLetters;
            return View();
        }
        //提交信息
        public ActionResult PutMessage()
        {
            try
            {
                int UID = Convert.ToInt32(Session["UID"].ToString());
                string Title = Request["Title"];
                int GetId = Convert.ToInt32(Request["GetOne"]);
                string Text = Request["Text"];
                if (Title == "" || Text == "")
                {
                    return Content("no:空的输入");
                }
                else
                {
                    PhotoStudio.Model.Message mess = new PhotoStudio.Model.Message();
                    mess.ToID = GetId;
                    mess.Title = Title;
                    mess.FromID = UID;
                    mess.Text = Text;
                    mess.Time = DateTime.Now;
                    int ad = new PhotoStudio.BLL.Message().Add(mess);
                    return Content("ok:添加成功");
                }
                
            }
            catch
            {
                return Content("no:添加失败");
            }
            
        }
    }
}