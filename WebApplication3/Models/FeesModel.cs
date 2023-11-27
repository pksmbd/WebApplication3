using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class FeesModel
    {
        public int id { get; set; }

        [DataType(DataType.Date)]
        public DateTime reg_date { get; set; }


        [Required(ErrorMessage = "Please Enter Fees Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Fees Date")]
        public DateTime fees_date { get; set; }

        [Required(ErrorMessage = "Please Enter Student Name")]
        [Display(Name = "Student Name")]
        public string student_name { get; set; }

        [Display(Name = "Father Name")]
        public string father_name { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        public string email { get; set; }

        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile No."), StringLength(10), Display(Name = "Mobile No.")]
        public string mobile { get; set; }

         


        [Required(ErrorMessage = "Please Enter Student Id")]
        //[ReadOnly(true)]
        [Display(Name = "Student Id")]
        public string student_id { get; set; }





        [Required(ErrorMessage = "Please Enter Course Name")]
        [Display(Name = "Course Name")]
        public string course_name { get; set; }
        public IEnumerable<SelectListItem> coursename { get; set; }

        [Required(ErrorMessage = "Please Enter Installment")]
        [Display(Name = "Installment")]
        public string installment { get; set; }

        [Display(Name = "Profile Photo")]
        public string photo { get; set; }

        [Required(ErrorMessage = "Please Enter Fees Amount")]
        [Display(Name = "Fees Amount")]
        //[Range(300, 4000, ErrorMessage = "Value 300 - 4000 only")]
        public string fees { get; set; }
    }
}
