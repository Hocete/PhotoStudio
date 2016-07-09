using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace PhotoStudio.WebApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            int putid = 0;
            try
            {
                putid = Convert.ToInt32(Session["UID"]);
            }
            catch
            {

            }
            ViewBag.UID = putid;
            ViewBag.xzvalue = Request["xz"];
            ViewBag.ppvalue = Request["pp"];
            string name = Request["name"];
            string select = Request["select"];
            string phone = Request["phone"];
            string Email = Request["email"];
            string Place = Request["place"];
            string Price = Request["price"];
            if (name != "")
            {
                bool isname = new PhotoStudio.Common.Validator().IsOnllyChinese(name);
                bool isphone = new PhotoStudio.Common.Validator().IsPhone(phone);
                bool ismobile = new PhotoStudio.Common.Validator().IsMobile(phone);
                bool isemail = new PhotoStudio.Common.Validator().IsEmail(Email);
                bool isprice = new PhotoStudio.Common.Validator().IsNumber(Price);
                if (isname)
                {
                    if (isphone || ismobile)
                    {
                        if (isemail)
                        {
                            if (select == "")
                            {
                                ViewBag.select = "所选套系为空！";
                            }
                            else
                            {
                                if (phone != "")
                                {
                                    try
                                    {
                                        if (isprice)
                                        {
                                            Add(name, select, phone, Email, Place, putid,Price);
                                        }
                                        else
                                        {
                                            ViewBag.Price = "价格输入无效！";
                                        }
                                        
                                    }
                                    catch
                                    {

                                    }

                                }

                            }
                        }
                        else
                        {
                            ViewBag.Email = "请输入有效的邮箱！";
                        }
                    }
                    else
                    {
                        ViewBag.phone = "请输入有效的手机或座机！";
                    }
                }
                else
                {
                    ViewBag.name = "请输入有效的中文名字！";
                }
            }

            return View();
        }
        //添加订单数据和客户数据
        public void Add(string name, string select, string phone, string Email, string Place, int putid,string price)
        {

            PhotoStudio.Model.Order model = new PhotoStudio.Model.Order();
            model.Name = name;
            model.Type = select;
            model.Phone = phone;
            model.Email = Email;
            model.Place = Place;
            model.PutID = putid;
            model.Time = DateTime.Now;
            model.State = "已预约";
            model.ChangeTime = DateTime.Now;
            model.Money = Convert.ToDecimal(price);
            int id = new PhotoStudio.BLL.Order().Add(model);
            ViewBag.Success = "已成功预约！";
            PhotoStudio.Model.Costomer model2 = new PhotoStudio.Model.Costomer();
            model2.Name = name;
            model2.Phone = phone;
            model2.Email = Email;
            model2.Place = Place;
            bool isno = new PhotoStudio.BLL.Costomer().Exists(phone);
            if(isno)
            {}
            else
            {
                int id2 = new PhotoStudio.BLL.Costomer().Add(model2);
            }

        }
        //订单跟进
        public ActionResult OrderAlter()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            ViewBag.ddnum = Request["ddnum"];
            string dnum = Request["ddnum"];
            bool isnum = new PhotoStudio.Common.Validator().IsNumber(dnum);
            if (isnum)
            {
                int dnums = Convert.ToInt32(Request["ddnum"]);
                bool Exists = new PhotoStudio.BLL.Order().Exists(dnums);
                ViewBag.Exists = Exists;
                if (Exists)
                {
                    PhotoStudio.Model.Order model = new PhotoStudio.BLL.Order().GetModel(dnums);
                    ViewBag.State = model.State.Trim();
                    string state = Request["btn"];
                    if (state != null)
                    {
                        new PhotoStudio.BLL.Order().Update(dnums,state);
                        if (state.Trim() == "已取货付款")
                        {
                            PhotoStudio.Model.Budget bud = new PhotoStudio.Model.Budget();
                            
                            bud.Type = 0;
                            bud.Money =model.Money;
                            bud.UserFor = "订单"+dnums+"套系消费";
                            bud.Time = DateTime.Now;
                            bud.OperID = Convert.ToInt32(putid);
                            new PhotoStudio.BLL.Budget().Add(bud);
                        }
                    }
                }
                else
                {
                    ViewBag.Error = "不存在的订单号码";
                }

            }
            else
            {
                bool Exists =false;
                ViewBag.Exists = Exists;
                ViewBag.Error = "错误的订单号码";
            }
            ViewBag.btn = Request["btn"];
            return View();
        }
        //图片上传
        public ActionResult Upload()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            HttpPostedFileBase photofile = Request.Files["photo"];
            string ddid = "all";
            ddid = Request["ddid"];
            if(photofile != null)
            {
                DateTime time = DateTime.Now;
                string uploadPath = Server.MapPath("~/Resource/Photos/"+ddid+"/");
                string fileName = time.ToString("yyyyMMddHHmmssfff");
                string filetrype = System.IO.Path.GetExtension(photofile.FileName);
                string saveFile = uploadPath + fileName + filetrype;
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                long contentLength = photofile.ContentLength;
                if (contentLength > 0)
                {
                    photofile.SaveAs(saveFile);
                    string url = "/Resource/Photos/" + ddid + "/" + fileName + filetrype;
                    ViewBag.PP = url;
                    PhotoStudio.Model.Photo model = new PhotoStudio.Model.Photo();
                    bool isnum = new PhotoStudio.Common.Validator().IsNumber(ddid);
                    if (!isnum)
                    {
                        ViewBag.Message = "订单号码只能全为数字！";
                    }
                    else
                    {
                        model.OrderID = Convert.ToInt32(ddid);
                        model.CostID = Convert.ToInt32(putid);
                        model.URL = url;
                        model.State = "未选";
                        new PhotoStudio.BLL.Photo().Add(model);
                        ViewBag.Message = "图片上传成功！";
                    }  
                }
                else
                {
                    ViewBag.Message = "请选择图片！";
                }
            }
            return View();
        }
        //客户选片
        public ActionResult Select()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
            ViewBag.ddnum = Request["ddnum"];
            string dnum = Request["ddnum"];
            if (Request["ddid"] != null)
            {
                ViewBag.ddnum = Request["ddid"];
                dnum = Request["ddid"];
                string photoid= Request["xpid"];
                int pid = Convert.ToInt32(photoid);
                string state = Request["state"];
                if (state.Trim() == "未选")
                {
                    state = "已选";
                }
                else if(state.Trim() == "已选")
                {
                    state = "未选";
                }
                new PhotoStudio.BLL.Photo().Update(pid,state);
            }
            bool isnum = new PhotoStudio.Common.Validator().IsNumber(dnum);
            if (isnum)
            {
                int dnums = Convert.ToInt32(Request["ddnum"]);
                if (Request["ddid"] != null)
                {
                    dnums = Convert.ToInt32(Request["ddid"]);
                }
                bool Exists = new PhotoStudio.BLL.Order().Exists(dnums);
                ViewBag.Exists = Exists;
                if (Exists)
                {
                    PhotoStudio.Model.Order model = new PhotoStudio.BLL.Order().GetModel(dnums);
                    List<PhotoStudio.Model.Photo> Photolist = new PhotoStudio.BLL.Photo().GetModelList("OrderID="+dnums);
                    ViewBag.Photolist = Photolist;
                }
                else
                {
                    ViewBag.Error = "不存在的订单号码";
                }

            }
            else
            {
                bool Exists = false;
                ViewBag.Exists = Exists;
                ViewBag.Error = "错误的订单号码";
            }
            return View();
        }
        //历史订单
        public ActionResult Records()
        {
            object putid = Session["UID"];
            ViewBag.UID = putid;
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
            IList<PhotoStudio.Model.Order> listOrders= new PhotoStudio.BLL.Order().GetListByPage(pageIndex, pageSize, sWhere, out Count);
            int pageCount = Count % pageSize == 0 ? Count / pageSize : Count / pageSize + 1;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            ViewBag.listOrders = listOrders;
            ViewBag.lCount = pageCount;
            ViewBag.Index = pageIndex;
            return View();
        }
    }
}