using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Количество не может быть отрицательным!")]
        public int ProductQuantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Цена не может принимать отрицательное значение!")]
        public double ProductPrice { get; set; }

    }
}
