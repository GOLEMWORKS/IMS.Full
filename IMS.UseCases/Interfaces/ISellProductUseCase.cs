﻿using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces
{
    public interface ISellProductUseCase
    {
        Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneDy);
    }
}