using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels
{
    public class SellViewModel
    {
        [Required(ErrorMessage = "Необходимо указать номер заказа!")]
        public string SalesOrderNumber { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Минимальное количество для продажи: 1")]
        public int QuantityToSell { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Минимальная цена для продажи: 1 рубль")]
        public double ProductPrice { get; set; }
    }
}
