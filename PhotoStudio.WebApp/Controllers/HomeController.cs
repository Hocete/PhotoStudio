using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoStudio.WebApp.Controllers
{
    public class HomeController : Controller
    {
        
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
            ViewBag.messdate = Request["messdate"];
            if (Request["wp"] != null)
            {
                int wpid = int.Parse(Request["wpid"]);
                PhotoStudio.Model.Goods wpmodel = new PhotoStudio.BLL.Goods().GetModel(wpid);
                PhotoStudio.Model.Goods updatewp = new PhotoStudio.Model.Goods();
                updatewp.ID = wpmodel.ID;
                updatewp.Name = wpmodel.Name;
                updatewp.Cost = wpmodel.Cost;
                updatewp.Spend = wpmodel.Spend;
                updatewp.Stock = wpmodel.Stock - 1;
                updatewp.Type = wpmodel.Type;
                updatewp.Photo = wpmodel.Photo;
                if (updatewp.Stock >= 0)
                {
                    new PhotoStudio.BLL.Goods().Update(updatewp);
                    ViewBag.Message = "成功购买" + Request["wp"] + "！";
                    PhotoStudio.Model.Budget bg = new PhotoStudio.Model.Budget();
                    bg.Type = 0;
                    bg.Time = DateTime.Now;
                    bg.OperID = Uid;
                    bg.UserFor = "出售"+ Request["wp"]+"收入！";
                    bg.Money = Convert.ToDecimal(Request["hf"]);
                    new PhotoStudio.BLL.Budget().Add(bg);
                }
                else
                {
                    ViewBag.Message = Request["wp"] + "库存不足！";
                }

            }
            List<PhotoStudio.Model.Goods> modelall = new PhotoStudio.BLL.Goods().GetModelList("Type!='其他'"); 
            ViewBag.goodsall = modelall;
            if (Request["tx"] != null)
            {
                modelall = new PhotoStudio.BLL.Goods().GetModelList("Type!='其他' And Type='" + Request["tx"] + "'");
                ViewBag.goodsall = modelall;
            }
            List<PhotoStudio.Model.Goods> otherall = new PhotoStudio.BLL.Goods().GetModelList("Type='其他'");
            ViewBag.othersall = otherall;
            if (Request["sp"]!=null)
            {
                otherall = new PhotoStudio.BLL.Goods().GetModelList("Type='其他' And Name='" + Request["sp"] + "'");
                ViewBag.othersall = otherall;
            }
           
            
            ViewBag.Search1 = Request["tx"];
            ViewBag.Search2 = Request["sp"];
            return View();
        }

        public ActionResult Sets()
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
            var letters = new List<string>() { };
            List<PhotoStudio.Model.Goods> Goods = new PhotoStudio.BLL.Goods().GetModelList("Type!='其他'");
            foreach (PhotoStudio.Model.Goods s in Goods)
            {
                letters.Add(s.ID.ToString());
            }
            var lstLetters = new List<SelectListItem>();
            foreach (var letter in letters)
            {
                lstLetters.Add(new SelectListItem { Text = letter, Value = letter });
            }
            ViewBag.Letters = lstLetters;
            string active = Request["active"];
            string name = Request["name"];
            string types = Request["types"];
            string price = Request["price"];
            HttpPostedFileBase photofile = Request.Files["photo"];
            if (active == "1")
            {
                ViewBag.AC = "1";
                int ID=Convert.ToInt32(Request["ID"]);
                if (photofile != null)
                {
                    DateTime time = DateTime.Now;
                    string uploadPath = Server.MapPath("~/Resource/Goods/");
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
                        PhotoStudio.Model.Goods del = new PhotoStudio.BLL.Goods().GetModel(ID);
                        string deletPath = Server.MapPath("~" + del.Photo);
                        System.IO.File.Delete(deletPath);
                        photofile.SaveAs(saveFile);
                        string url = "/Resource/Goods/" + fileName + filetrype;
                        try
                        {
                            PhotoStudio.Model.Goods sytx = new PhotoStudio.Model.Goods();
                            sytx.ID = ID;
                            sytx.Name = name;
                            sytx.Type = types;
                            sytx.Cost = 0;
                            sytx.Spend = Convert.ToDecimal(price);
                            sytx.Stock = 0;
                            sytx.Photo = url;
                            new PhotoStudio.BLL.Goods().Update(sytx);
                            ViewBag.Content = "社影套系修改成功";
                        }
                        catch
                        {
                            ViewBag.Content = "无法写入";
                        }

                    }
                    else
                    {
                        ViewBag.Content = "图片为空";
                    }

                }
                else
                {
                    ViewBag.Content = "请选择图片";
                }
            }
            else if (active == "2")
            {
                ViewBag.AC = "2";
                if (photofile != null)
                {
                    DateTime time = DateTime.Now;
                    string uploadPath = Server.MapPath("~/Resource/Goods/");
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
                        string url = "/Resource/Photos/Goods/" + fileName + filetrype;
                        try
                        {
                            PhotoStudio.Model.Goods sytx = new PhotoStudio.Model.Goods();
                            sytx.Name = name;
                            sytx.Type = types;
                            sytx.Cost = 0;
                            sytx.Spend = Convert.ToDecimal(price);
                            sytx.Stock = 0;
                            sytx.Photo = url;
                            new PhotoStudio.BLL.Goods().Add(sytx);
                            ViewBag.Content = "社影套系成功存入";
                        }
                        catch
                        {
                            ViewBag.Content = "无法写入";
                        }

                    }
                    else
                    {
                        ViewBag.Content = "图片为空";
                    }

                }
                else
                {
                    ViewBag.Content = "请选择图片";
                }
            }
            

            return View();
        }
        public ActionResult Other()
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
            var letters = new List<string>() { };
            List<PhotoStudio.Model.Goods> Goods = new PhotoStudio.BLL.Goods().GetModelList("Type='其他'");
            foreach (PhotoStudio.Model.Goods s in Goods)
            {
                letters.Add(s.ID.ToString());
            }
            var lstLetters = new List<SelectListItem>();
            foreach (var letter in letters)
            {
                lstLetters.Add(new SelectListItem { Text = letter, Value = letter });
            }
            ViewBag.Letters = lstLetters;

            string active = Request["active"];
            string name = Request["name"];
            string stock = Request["stock"];
            string price = Request["price"];
            string cost = Request["cost"];
            HttpPostedFileBase photofile = Request.Files["photo"];
            if (active == "1")
            {
                ViewBag.AC = "1";
                int ID = Convert.ToInt32(Request["ID"]);
                if (photofile != null)
                {
                    DateTime time = DateTime.Now;
                    string uploadPath = Server.MapPath("~/Resource/Goods/");
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
                        PhotoStudio.Model.Goods del = new PhotoStudio.BLL.Goods().GetModel(ID);
                        string deletPath= Server.MapPath("~"+del.Photo);
                        System.IO.File.Delete(deletPath);
                        photofile.SaveAs(saveFile);
                        string url = "/Resource/Goods/" + fileName + filetrype;
                        try
                        {
                            PhotoStudio.Model.Goods sytx = new PhotoStudio.Model.Goods();
                            sytx.ID = ID;
                            sytx.Name = name;
                            sytx.Type = "其他";
                            sytx.Cost = Convert.ToDecimal(cost);
                            sytx.Spend = Convert.ToDecimal(price);
                            sytx.Stock = Convert.ToInt32(stock);
                            sytx.Photo = url;
                            new PhotoStudio.BLL.Goods().Update(sytx);
                            ViewBag.Content = "其他商品修改成功";
                        }
                        catch
                        {
                            ViewBag.Content = "无法写入";
                        }

                    }
                    else
                    {
                        ViewBag.Content = "图片为空";
                    }

                }
                else
                {
                    ViewBag.Content = "请选择图片";
                }
            }
            else if (active == "2")
            {
                ViewBag.AC = "2";
                if (photofile != null)
                {
                    DateTime time = DateTime.Now;
                    string uploadPath = Server.MapPath("~/Resource/Goods/");
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
                        string url = "/Resource/Goods/" + fileName + filetrype;
                        try
                        {
                            PhotoStudio.Model.Goods sytx = new PhotoStudio.Model.Goods();
                            sytx.Name = name;
                            sytx.Type = "其他";
                            sytx.Cost = 0;
                            sytx.Spend = Convert.ToDecimal(price);
                            sytx.Stock = 0;
                            sytx.Photo = url;
                            new PhotoStudio.BLL.Goods().Add(sytx);
                            ViewBag.Content = "其他商品成功存入";
                        }
                        catch
                        {
                            ViewBag.Content = "无法写入";
                        }

                    }
                    else
                    {
                        ViewBag.Content = "图片为空";
                    }

                }
                else
                {
                    ViewBag.Content = "请选择图片";
                }
            }
            return View();
        }

    }
}