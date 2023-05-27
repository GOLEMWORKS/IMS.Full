using System.ComponentModel.DataAnnotations;


namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Необходимо укказать наименование!")]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Количество не может быть отрицательным!")]
        public int ProductQuantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Цена не может принимать отрицательное значение!")]
        public double ProductPrice { get; set; }

        public List<ProductInventory>? ProductInventories { get; set; }
    }
}
