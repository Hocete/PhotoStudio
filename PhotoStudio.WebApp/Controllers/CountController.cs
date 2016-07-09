using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoStudio.WebApp.Controllers
{
    public class CountController : Controller
    {
        // GET: Count
        public ActionResult Index()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            try
                {
                    string ksdate = Convert.ToDateTime(Request["ksdate"]).ToString("yyyy-MM-dd HH:mm:ss");
                    string jsdate = Convert.ToDateTime(Request["jsdate"]).ToString("yyyy-MM-dd HH:mm:ss");
                    ViewBag.ksdate = Convert.ToDateTime(Request["ksdate"]).ToString("yyyy-MM-dd");
                    ViewBag.jsdate = Convert.ToDateTime(Request["ksdate"]).ToString("yyyy-MM-dd");
                    long count1 = new PhotoStudio.BLL.Budget().GetAllMoney("Type=0 and Time>'"+ksdate+"' and Time<'"+jsdate+"'");
                    long count2 = new PhotoStudio.BLL.Budget().GetAllMoney("Type=1 and Time>'" + ksdate + "' and Time<'" + jsdate + "'");
                    ViewBag.countr = count1;
                     ViewBag.countc = count2;
            }
                catch
                {

                }
                
            return View();
        }

        public ActionResult Appointment()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            string nowdate = DateTime.Now.ToString("yyyy-MM-dd");
            IList<PhotoStudio.Model.Order> listOrders = new PhotoStudio.BLL.Order().GetModelList("Convert(varchar,Time,120) LIKE '"+nowdate+"%'");
            ViewBag.listOrders = listOrders;
            ViewBag.lCount = listOrders.Count;
            return View();
        }
        public ActionResult Guest()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            string name = Request["name"];
            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int pageSize = 10;
            string sWhere = "";
            int Count;
            if (name != null)
            {
                sWhere = " Name like '" + name.Trim() + "%'";
            }
            else
            {
                sWhere = "";
            }
            IList<PhotoStudio.Model.Costomer> listCostomer = new PhotoStudio.BLL.Costomer().GetListByPage(pageIndex, pageSize, sWhere, out Count);
            int pageCount = Count % pageSize == 0 ? Count / pageSize : Count / pageSize + 1;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            ViewBag.listOrders = listCostomer;
            ViewBag.lCount = pageCount;
            ViewBag.Index = pageIndex;
            return View();
        }
    }
}