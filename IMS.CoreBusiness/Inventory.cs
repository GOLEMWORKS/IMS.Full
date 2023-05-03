using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        [Required]
        public string? InventoryName{ get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Количество не может быть отрицательным!")]
        public int Quantity { get; set; }
        [Range(0, double.MaxValue,ErrorMessage ="Цена не может принимать отрицательное значение!")]
        public double Price { get; set; }
    }
}