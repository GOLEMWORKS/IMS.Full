using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Validation
{
    public class Product_EnsurePricesGreaterThanInventoriesPrice : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;
            if(product != null)
            {
                if (!product.ValidatePricing())
                {
                    //new System.Globalization.CultureInfo("ru-RU"), "{0:C}
                    return new ValidationResult($"Цена продукта не может быть меньше, чем у его комплектующих! Текущая цена комплектующих {product.TotalInventoryCost().ToString("c", new System.Globalization.CultureInfo("ru-RU"))}", 
                        new[] {validationContext.MemberName});
                }
            }

            return ValidationResult.Success;
        }
    }
}
