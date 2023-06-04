﻿using IMS.CoreBusiness;
using IMS.CoreBusiness.TransactionTypes;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private readonly IMSContext db;

        public InventoryTransactionRepository(IMSContext db)
        {
            this.db = db;
        }
        public async Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, double inventoryPrice, string doneBy)
        {
            this.db.InventoryTransactions.Add(new InventoryTransaction
            {
                    POnumber = poNumber,
                    InventoryId = inventory.InventoryId,
                    QuantityBefore = inventory.Quantity,
                    InventoryType = InventoryTransactionType.PurchaseInventory,
                    QuantityAfter = inventory.Quantity + quantity,
                    TransactionDate = DateTime.Now,
                    DoneBy = doneBy
            });
            await this.db.SaveChangesAsync();
        }
    }
}
