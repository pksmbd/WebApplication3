using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;
using WebApplication3.Models;
using WebApplication3.Service;

namespace WebApplication3.Controllers
{
    public class UsersController : Controller
    {
        myClass mc = new myClass();

        private readonly ILogger<UsersController> _logger;
        private IWebHostEnvironment Environment;


        public UsersController(ILogger<UsersController> logger, IWebHostEnvironment _environment)
        {
            _logger = logger;
            Environment = _environment;
        }






        public IActionResult Index()
        {
            List<UsersModel> UsersModelLstObj = new List<UsersModel>();
            DataSet ds1 = mc.fetchdata("select * from users");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                UsersModelLstObj.Add(new UsersModel
                {
                    Id = Convert.ToInt32(ds1.Tables[0].Rows[i]["id"].ToString()),
                    Name = ds1.Tables[0].Rows[i]["Name"].ToString(),
                    Email = ds1.Tables[0].Rows[i]["Email"].ToString(),
                    Age = Convert.ToInt32(ds1.Tables[0].Rows[i]["age"].ToString()),
                    Image123 = ds1.Tables[0].Rows[i]["Image"].ToString()
                });
                i++;
            }
            return View(UsersModelLstObj);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsersModel UsersModelObj, List<IFormFile> postedFiles)
        { 
            // uploaded files code
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    mc.executenonquery("insert into users values('" + UsersModelObj.Name + "','" + UsersModelObj.Email + "','" + UsersModelObj.Age + "','" + fileName + "')");
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
        public IActionResult Details(int id)
        {
            List<UsersModel> UsersModelLstObj = new List<UsersModel>();
            UsersModel UsersModelObj = new UsersModel();
            DataSet ds1 = mc.fetchdata("select * from users where id=" + id + "");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                UsersModelObj.Id = Convert.ToInt32(ds1.Tables[0].Rows[i]["id"].ToString());
                UsersModelObj.Name = ds1.Tables[0].Rows[i]["Name"].ToString();
                UsersModelObj.Email = ds1.Tables[0].Rows[i]["Email"].ToString();
                UsersModelObj.Age = Convert.ToInt32(ds1.Tables[0].Rows[i]["age"].ToString());
                UsersModelObj.Image123 = ds1.Tables[0].Rows[i]["Image"].ToString();
                i++;
            }
            return View(UsersModelObj);
        }

        public IActionResult Edit(int id)
        {
            List<UsersModel> UsersModelLstObj = new List<UsersModel>();
            UsersModel UsersModelObj = new UsersModel();
            DataSet ds1 = mc.fetchdata("select * from users where id="+id+"");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                UsersModelObj.Id = Convert.ToInt32(ds1.Tables[0].Rows[i]["id"].ToString());
                UsersModelObj.Name = ds1.Tables[0].Rows[i]["Name"].ToString();
                UsersModelObj.Email = ds1.Tables[0].Rows[i]["Email"].ToString();
                UsersModelObj.Age = Convert.ToInt32(ds1.Tables[0].Rows[i]["age"].ToString());
                i++;
            }
            return View(UsersModelObj);
        }
        [HttpPost]
        public IActionResult Edit(UsersModel UsersModelObj)
        {
            mc.executenonquery("update users set name='" + UsersModelObj.Name + "', email='" + UsersModelObj.Email + "', age='" + UsersModelObj.Age + "' where id="+ UsersModelObj.Id + "");
            TempData["savemsg"] = "<script>alert('User Update Done...');</script>";
            return RedirectToAction("Index");
        }  
        
        public ActionResult Delete(int id)
        {
            mc.executenonquery("delete from users where id=" + id + "");
            TempData["savemsg"] = "<script>alert('User Delete Done...');</script>";
            return RedirectToAction("Index");
        }
    }
}
