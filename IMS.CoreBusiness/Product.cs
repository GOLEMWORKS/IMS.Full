﻿using IMS.CoreBusiness.Validation;
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

        [Range(1, double.MaxValue, ErrorMessage = "Цена не может принимать отрицательное или нулевое значение!")]
        [Product_EnsurePricesGreaterThanInventoriesPrice]
        public double ProductPrice { get; set; }

        [Required(ErrorMessage = "Нельзя создать продукт без комплектующих!")]
        public List<ProductInventory>? ProductInventories { get; set; }

        public double TotalInventoryCost()
        {
            return this.ProductInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);
        }
        public bool ValidatePricing()
        {
            if (ProductInventories == null || ProductInventories.Count <= 0) return true;
            if (this.TotalInventoryCost() > ProductPrice) return false;

            return true;
        }
    }
}
