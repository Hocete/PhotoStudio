using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoStudio.WebApp.Controllers
{
    public class FinanceController : Controller
    {
        // GET: Finance
        public ActionResult Index()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            var letters = new List<string>() { };
            List<PhotoStudio.Model.Budget> Budget = new PhotoStudio.BLL.Budget().GetModelList("");
            foreach (PhotoStudio.Model.Budget s in Budget)
            {
                letters.Add(s.OperID.ToString());
            }
            var lstLetters = new List<SelectListItem>();
            foreach (var letter in letters)
            {
                lstLetters.Add(new SelectListItem { Text = letter, Value = letter });
            }
            ViewBag.Letters = lstLetters;

            var sfselects = new List<string>() { "收入", "支出" };
            var lstSf = new List<SelectListItem>();
            foreach (var sfselect in sfselects)
            {
                lstSf.Add(new SelectListItem { Text = sfselect, Value = sfselect });
            }
            ViewBag.sfselect = lstSf;

            string date = Request["dddate"];
            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int pageSize = 10;
            string sWhere = "";
            int Count;
            if (date != null)
            {
                sWhere = " CONVERT(VARCHAR,Time,120) like '" + date.Trim() + "%'";
            }
            else
            {
                sWhere = "";
            }
            IList<PhotoStudio.Model.Budget> listBudget = new PhotoStudio.BLL.Budget().GetListByPage(pageIndex, pageSize, sWhere, out Count);
            int pageCount = Count % pageSize == 0 ? Count / pageSize : Count / pageSize + 1;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            ViewBag.listBudget = listBudget;
            ViewBag.lCount = pageCount;
            ViewBag.Index = pageIndex;

            return View();
        }
        //商品入库
        public ActionResult GoodsGet()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            var letters = new List<string>() {};
            List<PhotoStudio.Model.Goods> goods = new PhotoStudio.BLL.Goods().GetModelList("Type='其他'");
            foreach (PhotoStudio.Model.Goods s in goods)
            {
                letters.Add(s.ID+"."+s.Name);
            }
            var lstLetters = new List<SelectListItem>();
            foreach (var letter in letters)
            {
                lstLetters.Add(new SelectListItem { Text = letter, Value = letter });
            }
            ViewBag.Letters = lstLetters;
            return View();
        }
        public ActionResult GoodsAdd()
        {
            try
            {
                int UID = Convert.ToInt32(Session["UID"].ToString());
                string select = Request["select1"];
                int id = Convert.ToInt32(select.Split('.')[0]);
                int num = Convert.ToInt32(Request["num"]);
                decimal price =Convert.ToDecimal(Request["price"]);
                PhotoStudio.Model.Budget som = new PhotoStudio.Model.Budget();
                som.Money = price * num;
                som.Type = 1;
                som.UserFor = "买入" + select + num + "个";
                som.OperID = Convert.ToInt32(Session["UID"]);
                som.Time = DateTime.Now;
                new PhotoStudio.BLL.Budget().Add(som);
                new PhotoStudio.BLL.Goods().Update(id,num,price);
                
                return Content("ok:入库成功");

            }
            catch
            {
                return Content("no:入库失败");
            }
        }
        //员工赏罚
        public ActionResult Justice()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            var letters = new List<string>() { };
            List<PhotoStudio.Model.Staff> staffs = new PhotoStudio.BLL.Staff().GetModelList("");
            foreach (PhotoStudio.Model.Staff s in staffs)
            {
                letters.Add(s.ID.ToString());
            }
            var lstLetters = new List<SelectListItem>();
            foreach (var letter in letters)
            {
                lstLetters.Add(new SelectListItem { Text = letter, Value = letter });
            }
            ViewBag.Letters = lstLetters;

            var sfselects= new List<string>() { "奖励","惩罚"};
            var lstSf = new List<SelectListItem>();
            foreach (var sfselect in sfselects)
            {
                lstSf.Add(new SelectListItem { Text = sfselect,Value = sfselect});
            }
            ViewBag.sfselect = lstSf;
            string date = Request["dddate"];
            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int pageSize = 10;
            string sWhere = "";
            int Count;
            if (date != null)
            {
                sWhere = " CONVERT(VARCHAR,Time,120) like '" + date.Trim() + "%'";
            }
            else
            {
                sWhere = "";
            }
            IList<PhotoStudio.Model.RewPun> listRewPun = new PhotoStudio.BLL.RewPun().GetListByPage(pageIndex, pageSize, sWhere, out Count);
            int pageCount = Count % pageSize == 0 ? Count / pageSize : Count / pageSize + 1;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            ViewBag.listOrders = listRewPun;
            ViewBag.lCount = pageCount;
            ViewBag.Index = pageIndex;
            return View();
        }
        public ActionResult JusticeAdd()
        {
            try
            {
                int UID = Convert.ToInt32(Session["UID"].ToString());
                string Type = Request["sf"];
                int GetId = Convert.ToInt32(Request["GetOne"]);
                string Why = Request["yy"];
                if (Type == "" || Why == "")
                {
                    return Content("no:空的输入");
                }
                else
                {
                    int typ = 0;
                    if (Type.Trim() == "奖励")
                    {
                        typ = 0;
                    }
                    else
                    {
                        typ = 1;
                    }
                    PhotoStudio.Model.RewPun RewPun = new PhotoStudio.Model.RewPun();
                    RewPun.Time = DateTime.Now;
                    RewPun.Text = Why;
                    RewPun.OperID = GetId;
                    RewPun.Type = typ;
                    int ad = new PhotoStudio.BLL.RewPun().Add(RewPun);
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