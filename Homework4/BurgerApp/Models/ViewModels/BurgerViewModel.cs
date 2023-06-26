namespace BurgerApp.Models.ViewModels
{
    public class BurgerViewModel
    {
        public int Id { get; set; }
        public string BurgerName { get; set; }
        public decimal Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool HasFries { get; set; }
    }
}
