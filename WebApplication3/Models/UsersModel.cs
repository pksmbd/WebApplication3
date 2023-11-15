using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace WebApplication3.Models
{
    public class UsersModel
    {
        [Key]
        public int Id { get; set; }

        
        
        
        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Your Name")]
        public string Name { get; set; }




        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage ="Enter Valid Email")]
        public string Email { get; set; }

        
        
        [Required(ErrorMessage = "Please Enter Age")]
        [Range(18,30,ErrorMessage ="Value 18 - 30 only")]
        public int Age{ get; set; }


        [Display(Name = "Photo")]
        public string Image123  { get; set; }


        //[DisplayName("Image1")]
        //public string image1path { get; set; }
        //public HttpPostedFileBase image1file { get; set; }

        //[DisplayName("Image1")]
        //public string image1path { get; set; }
        //public HttpPostedFileBase image1file { get; set; }
    }
}
