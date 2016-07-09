using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoStudio.WebApp.Controllers
{
    public class SystemController : Controller
    {
        // GET: System用户权限设置
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
            var vatype = new List<string>() { "部门", "个人" };
            var lsttype = new List<SelectListItem>();
            foreach (var types in vatype)
            {
                lsttype.Add(new SelectListItem { Text = types, Value = types });
            }
            ViewBag.Type = lsttype;
            var names = new List<string>() { };
            List<PhotoStudio.Model.Power> Power = new PhotoStudio.BLL.Power().GetModelList("");
            foreach (PhotoStudio.Model.Power s in Power)
            {
                names.Add(s.ID + "." + s.Name);
            }
            names.Add("888888.最高权限");
            var lstname = new List<SelectListItem>();
            foreach (var name in names)
            {
                lstname.Add(new SelectListItem { Text = name, Value = name });
            }
            ViewBag.name = lstname;
            ViewBag.UID = Uid;
            ViewBag.power = Power;
            return View();
        }
        //设置操作权限
        public ActionResult SetRoot()
        {
            try
            {
                string idall = "";
                for (int i = 1; i <= 15; i++)
                {
                    string getid = Request.Form["chk" + i];
                    if (getid != null)
                    {
                        idall = idall + getid + ",";
                    }
                }
                string name = Request["name"];
                if (name != null && idall != "")
                {
                    PhotoStudio.Model.Power pow = new PhotoStudio.Model.Power();
                    pow.Name = name;
                    pow.Powers = idall;
                    new PhotoStudio.BLL.Power().Add(pow);
                    return Content("ok:" + name + "权限添加成功！");
                }
                else
                {
                    return Content("no:添加失败！");
                }
            }
            catch
            {
                return Content("no:添加失败！");
            }
        }
        public ActionResult SetPower()
        {
            try
            {
                string type = Request["Type"];
                string name = Request["name"];
                string toID = Request["ToID"];
                string[] sname = name.Split('.');
                int id = Convert.ToInt32(toID);
                int poid = Convert.ToInt32(sname[0]);
                if (type == "部门")
                {
                    new PhotoStudio.BLL.Sector().Update(id, poid);
                    return Content("ok:" + id + "权限分配成功！");
                }
                else
                {
                    new PhotoStudio.BLL.Staff().Update(id, poid);
                    return Content("ok:" + id + "权限分配成功！");
                }
            }
            catch
            {
                return Content("no:添加失败！");
            }
        }
        // 数据备份回复
        public ActionResult Database()
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
            HttpPostedFileBase data = Request.Files["files"];
            if (data != null)
            {
                DateTime time = DateTime.Now;
                string uploadPath = Server.MapPath("~/App_Data/");
                string fileName = time.ToString("yyyyMMddHHmmssfff");
                string filetrype = System.IO.Path.GetExtension(data.FileName);
                string saveFile = uploadPath + fileName + filetrype;
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                long contentLength = data.ContentLength;
                if (contentLength > 0)
                {
                    data.SaveAs(saveFile);

                    try
                    {
                        PhotoStudio.Common.DatabaseMain.RestoreBackup("H:/PhotoStudio/PhotoStudio.WebApp/App_Data/摄影工作室数据.bak");
                        ViewBag.dat = "还原成功";
                    }
                    catch
                    {
                        ViewBag.dat = "还原失败";
                    }

                }
                else
                {
                    ViewBag.dat = "文件为空";
                }
                   
            }
            return View();
        }
        public ActionResult DataBack()
        {
            try
            {
                string dname = "摄影工作室数据";
                string filename = Server.MapPath("~/App_Data/" + dname + ".bak");
                if (!System.IO.File.Exists(filename))
                {
                    System.IO.File.Create(filename);
                }
                PhotoStudio.Common.DatabaseMain.Backup(filename);
                return Content("ok:备份成功");
            }
            catch
            {
                return Content("no:备份失败");
            }
        }
        public ActionResult Down()
        {
            string fileName = "摄影工作室数据库备份.bak";//客户端保存的文件名  
            string filePath = Server.MapPath("~/App_Data/摄影工作室数据.bak");//路径  

            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
            return new EmptyResult();
        }
    }
}