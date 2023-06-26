using BurgerApp.Models.Domain;

namespace BurgerApp.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public string BurgerName { get; set; }

        public string Location { get; set; }
    }
}
