using BurgerApp.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BurgerApp.Models.ViewModels
{
    public class OrderFormViewModel
    {

        [Display(Name = "Fullname")]
        public string FullName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Is Delivered")]
        public bool IsDelivered { get; set; }

        [Display(Name = "Burger Name")]
        public string BurgerName { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
        public int Id { get; set; } 
    }
}
