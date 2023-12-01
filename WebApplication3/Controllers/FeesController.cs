using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Service;
using PagedList;
using PagedList.Mvc;
//using System.Web.Mvc;


namespace WebApplication3.Controllers
{
    public class FeesController : Controller
    {
        myClass mc = new myClass();
        private readonly ILogger<FeesController> _logger;
        private IWebHostEnvironment Environment;

        public FeesController(ILogger<FeesController> logger, IWebHostEnvironment _environment)
        {
            _logger = logger;
            Environment = _environment;
        }


        public IActionResult Index()
        {
            List<FeesModel> FeesModelLstObj = new List<FeesModel>();
            DataSet ds1 = mc.fetchdata("select * from tblfees");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                FeesModelLstObj.Add(new FeesModel
                {
                    id = Convert.ToInt32(ds1.Tables[0].Rows[i]["id"].ToString()),
                    reg_date = Convert.ToDateTime(ds1.Tables[0].Rows[i]["reg_date"].ToString()),
                    fees_date = Convert.ToDateTime(ds1.Tables[0].Rows[i]["fees_date"].ToString()),
                    student_name = ds1.Tables[0].Rows[i]["student_name"].ToString(),
                    father_name = ds1.Tables[0].Rows[i]["father_name"].ToString(),
                    email = ds1.Tables[0].Rows[i]["email"].ToString(),
                    dob = Convert.ToDateTime(ds1.Tables[0].Rows[i]["dob"].ToString()),
                    mobile = ds1.Tables[0].Rows[i]["mobile"].ToString(),
                    student_id = ds1.Tables[0].Rows[i]["student_id"].ToString(),
                    course_name = ds1.Tables[0].Rows[i]["course_name"].ToString(),
                    installment = ds1.Tables[0].Rows[i]["installment"].ToString(),
                    photo = ds1.Tables[0].Rows[i]["photo"].ToString(),
                    fees = ds1.Tables[0].Rows[i]["fees"].ToString()
                });
                i++;
            }
            return View(FeesModelLstObj);
        }
          
        //[System.Web.Mvc.HttpGet]
        //public ActionResult getdetails(string stu_id)
        //{
        //    List<FeesModel> FeesModelLstObj = new List<FeesModel>();
        //    FeesModel FeesModelObj = new FeesModel();
        //    DataSet ds1 = mc.fetchdata("select * from tblfees where id=" + stu_id + "");
        //    int i = 0;
        //    while (i < ds1.Tables[0].Rows.Count)
        //    {
        //        FeesModelObj.id = Convert.ToInt32(ds1.Tables[0].Rows[i]["id"].ToString());
        //        FeesModelObj.reg_date = Convert.ToDateTime(ds1.Tables[0].Rows[i]["reg_date"].ToString());
        //        FeesModelObj.fees_date = Convert.ToDateTime(ds1.Tables[0].Rows[i]["fees_date"].ToString());
        //        FeesModelObj.student_name = ds1.Tables[0].Rows[i]["student_name"].ToString();
        //        FeesModelObj.father_name = ds1.Tables[0].Rows[i]["father_name"].ToString();
        //        FeesModelObj.email = ds1.Tables[0].Rows[i]["email"].ToString();
        //        FeesModelObj.dob = Convert.ToDateTime(ds1.Tables[0].Rows[i]["dob"].ToString());
        //        FeesModelObj.mobile = ds1.Tables[0].Rows[i]["mobile"].ToString();
        //        FeesModelObj.student_id = ds1.Tables[0].Rows[i]["student_id"].ToString();
        //        FeesModelObj.course_name = ds1.Tables[0].Rows[i]["course_name"].ToString();
        //        FeesModelObj.installment = ds1.Tables[0].Rows[i]["installment"].ToString();
        //        FeesModelObj.photo = ds1.Tables[0].Rows[i]["photo"].ToString();
        //        FeesModelObj.fees = ds1.Tables[0].Rows[i]["fees"].ToString();
        //        i++;
        //    }
        //    return Json(FeesModelObj, System.Web.Mvc.JsonRequestBehavior.AllowGet);
             
        //}


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FeesModel FeesModelObj, List<IFormFile> postedFiles)
        {
            // uploaded files code
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;
            string path = Path.Combine(this.Environment.WebRootPath, "uploads");
            if (!Directory.Exists(path))
            { Directory.CreateDirectory(path); }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {

                    if (FeesModelObj.installment == "1") { FeesModelObj.reg_date = FeesModelObj.fees_date; }

mc.executenonquery("insert into tblfees (reg_date,fees_date,student_name,father_name,email,dob,mobile,student_id,course_name,installment,photo,fees) values('" + FeesModelObj.reg_date + "','" + FeesModelObj.fees_date + "','" + FeesModelObj.student_name + "','" + FeesModelObj.father_name+ "','" + FeesModelObj.email+ "','" + FeesModelObj.dob+ "','" + FeesModelObj.mobile+ "','" + FeesModelObj.student_id+ "','" + FeesModelObj.course_name+ "','" + FeesModelObj.installment+ "','" + fileName + "','" + FeesModelObj.fees+ "')");
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    ViewBag.Message += fileName + ",";
                }
            }

            // insert code           
            TempData["savemsg"] = "<script>alert('User Save Done...');</script>";
            return RedirectToAction("Index");
            // insert code
            // uploaded files code 
        }
        

        [HttpPost]
        public IActionResult Edit(FeesModel FeesModelObj, List<IFormFile> postedFiles)
        {
            // uploaded files code
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;
            string path = Path.Combine(this.Environment.WebRootPath, "uploads");
            if (!Directory.Exists(path))
            { Directory.CreateDirectory(path); }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {

                    //if (FeesModelObj.installment == "1") { FeesModelObj.reg_date = FeesModelObj.fees_date; }

                    mc.executenonquery("update tblfees set reg_date='" + FeesModelObj.reg_date + "',fees_date='" + FeesModelObj.fees_date + "',student_name='" + FeesModelObj.student_name+ "',father_name='" + FeesModelObj.father_name+ "',email='" + FeesModelObj.email+ "',dob='" + FeesModelObj.dob+ "',mobile='" + FeesModelObj.mobile+ "',student_id='" + FeesModelObj.student_id+ "',course_name='" + FeesModelObj.course_name+ "',installment='" + FeesModelObj.installment+ "',photo='" + fileName + "',fees='" + FeesModelObj.fees+ "' where id="+ FeesModelObj.id + " ");
                    
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    ViewBag.Message += fileName + ",";
                }
            }

            // insert code           
            TempData["savemsg"] = "<script>alert('User Update Done...');</script>";
            return RedirectToAction("Index");
            // insert code
            // uploaded files code 
        }

        public IActionResult Edit(int id)
        {
            List<FeesModel> FeesModelLstObj = new List<FeesModel>();
            FeesModel FeesModelObj = new FeesModel();
            DataSet ds1 = mc.fetchdata("select * from tblfees where id=" + id + "");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                FeesModelObj.id = Convert.ToInt32(ds1.Tables[0].Rows[i]["id"].ToString());
                FeesModelObj.reg_date = Convert.ToDateTime(ds1.Tables[0].Rows[i]["reg_date"].ToString());
                FeesModelObj.fees_date = Convert.ToDateTime(ds1.Tables[0].Rows[i]["fees_date"].ToString());
                FeesModelObj.student_name = ds1.Tables[0].Rows[i]["student_name"].ToString();
                FeesModelObj.father_name = ds1.Tables[0].Rows[i]["father_name"].ToString();
                FeesModelObj.email = ds1.Tables[0].Rows[i]["email"].ToString();
                FeesModelObj.dob = Convert.ToDateTime(ds1.Tables[0].Rows[i]["dob"].ToString());
                FeesModelObj.mobile = ds1.Tables[0].Rows[i]["mobile"].ToString();
                FeesModelObj.student_id = ds1.Tables[0].Rows[i]["student_id"].ToString();
                FeesModelObj.course_name = ds1.Tables[0].Rows[i]["course_name"].ToString();
                FeesModelObj.installment = ds1.Tables[0].Rows[i]["installment"].ToString();
                FeesModelObj.photo = ds1.Tables[0].Rows[i]["photo"].ToString();
                FeesModelObj.fees = ds1.Tables[0].Rows[i]["fees"].ToString();
                i++;
            }
            return View(FeesModelObj);
        }

        public ActionResult Delete(int id)
        {
            mc.executenonquery("delete from tblfees where id=" + id + "");
            TempData["savemsg"] = "<script>alert('User Delete Done...');</script>";
            return RedirectToAction("Index");
        }
    }
}
