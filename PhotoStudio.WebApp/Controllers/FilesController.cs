using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoStudio.WebApp.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files档案管理
        public ActionResult Index()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            return View();
        }
        public ActionResult Department()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            var letters = new List<string>() { };
            List<PhotoStudio.Model.Power> Power = new PhotoStudio.BLL.Power().GetModelList("");
            foreach (PhotoStudio.Model.Power s in Power)
            {
                letters.Add(s.ID + "." + s.Name);
            }
            var lstLetters = new List<SelectListItem>();
            foreach (var letter in letters)
            {
                lstLetters.Add(new SelectListItem { Text = letter, Value = letter });
            }
            ViewBag.Letters = lstLetters;



            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int pageSize = 10;
            string sWhere = "";
            int Count;
            IList<PhotoStudio.Model.Sector> listSector = new PhotoStudio.BLL.Sector().GetListByPage(pageIndex, pageSize, sWhere, out Count);
            int pageCount = Count % pageSize == 0 ? Count / pageSize : Count / pageSize + 1;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            ViewBag.listSector = listSector;
            ViewBag.lCount = pageCount;
            ViewBag.Index = pageIndex;
            return View();
        }
        public ActionResult DepaAdd()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            try
            {
                int UID = Convert.ToInt32(Session["UID"].ToString());
                string name = Request["name"];
                string root = Request["root"];
                string Power = root.Split('.')[0];
                PhotoStudio.Model.Sector sec = new PhotoStudio.Model.Sector();
                sec.Name = name;
                sec.Power = Power;
                new PhotoStudio.BLL.Sector().Add(sec);

                return Content("ok:新部门成功存入");

            }
            catch
            {
                return Content("no:新部门存入失败");
            }
        }
        public ActionResult DepaDel()
        {

            try
            {
                int delID = Convert.ToInt32(Request["delid"]);
                int UID = Convert.ToInt32(Session["UID"].ToString());
                bool iis = new PhotoStudio.BLL.Staff().Exists("SeID="+ delID);
                if (iis)
                {
                    return Content("no:无法删除空的部门");
                }
                else
                {   
                bool si = new PhotoStudio.BLL.Sector().Delete(delID);
                return Content("ok:删除成功");
                 }
            }
            catch
            {
                return Content("no:删除失败");
            }
        }
        public ActionResult DeEdit()
        {
            return View();
        }
        public ActionResult Staff()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            var sexselects = new List<string>() { "男", "女" };
            var lstsex = new List<SelectListItem>();
            foreach (var sexselect in sexselects)
            {
                lstsex.Add(new SelectListItem { Text = sexselect, Value = sexselect });
            }
            ViewBag.lstsex = lstsex;

            var letters = new List<string>() { };
            List<PhotoStudio.Model.Sector> Sector = new PhotoStudio.BLL.Sector().GetModelList("");
            foreach (PhotoStudio.Model.Sector s in Sector)
            {
                letters.Add(s.ID + "." + s.Name);
            }
            var lstLetters = new List<SelectListItem>();
            foreach (var letter in letters)
            {
                lstLetters.Add(new SelectListItem { Text = letter, Value = letter });
            }
            ViewBag.Letters = lstLetters;

            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int pageSize = 10;
            string sWhere ="";
            int Count;
            IList<PhotoStudio.Model.Staff> listStaff = new PhotoStudio.BLL.Staff().GetListByPage(pageIndex, pageSize, sWhere, out Count);
            int pageCount = Count % pageSize == 0 ? Count / pageSize : Count / pageSize + 1;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            ViewBag.listStaff = listStaff;
            ViewBag.lCount = pageCount;
            ViewBag.Index = pageIndex;
            return View();
        }
        public ActionResult StaffAdd()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            try
            {
                int UID = Convert.ToInt32(Session["UID"].ToString());
                string name = Request["name"];
                string root = Request["root"];
                string Birth = Request["Birth"];
                string Edu = Request["Edu"];
                string Email = Request["Email"];
                string Sex = Request["Sex"];
                string Sec = Request["Sec"];
                string Place = Request["Place"];
                string Tel = Request["Tel"];
                string IDcard = Request["IDcard"];
                string Wages = Request["Wages"];
                string SeID = Sec.Split('.')[0];
                int sex = 0;
                if (Sex.Trim() == "男")
                {
                    sex = 0;
                }
                else
                {
                    sex = 1;
                }
                PhotoStudio.Model.Staff Staff = new PhotoStudio.Model.Staff();
                Staff.Name = name;
                Staff.JoinTime = DateTime.Now;
                Staff.Birth = Convert.ToDateTime(Birth);
                Staff.Edu = Edu;
                Staff.Email = Email;
                Staff.IDCard = IDcard;
                Staff.PassWord = "123456";
                Staff.Place = Place;
                Staff.SeID = Convert.ToInt32(SeID);
                Staff.Sex = sex;
                Staff.Tel = Tel;
                Staff.Wages = Convert.ToDecimal(Wages);
                Staff.Power = "0";
                new PhotoStudio.BLL.Staff().Add(Staff);

                return Content("ok:新员工成功存入");

            }
            catch
            {
                return Content("no:新员工存入失败");
            }
        }
        public ActionResult StaffDel()
        {

            try
            {
                int UID = Convert.ToInt32(Session["UID"].ToString());
                int delID = Convert.ToInt32(Request["delid"]);
                if (delID == UID)
                {
                    return Content("no:无法删除自己");
                }
                else
                {
                    bool si = new PhotoStudio.BLL.Staff().Delete(delID);
                    return Content("ok:删除成功");
                }
     
            }
            catch
            {
                return Content("no:删除失败");
            }
        }
    }
}