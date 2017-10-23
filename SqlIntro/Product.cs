using System;
using System.Collections.Generic;

namespace SqlIntro
{
    public class Product
    {
        public int ProductId { get; set; }
        public Guid RowGuid { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public double ListPrice { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public int SafetyStockLevel { get; set; }
        public int ReorderPoint { get; set; }
        public int DaysToManufacture { get; set; }
        public double StandardCost { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime SellStartDate { get; set; }

        public Dictionary<string, object> Params => new Dictionary<string, object>
        {
            {"RowGuid", "blob"},
            {"Name", Name},
            {"ProductNumber", ProductNumber},
            {"ListPrice", ListPrice},
            {"MakeFlag", MakeFlag},
            {"FinishedGoodsFlag", FinishedGoodsFlag},
            {"Color", Color},
            {"SafetyStockLevel", SafetyStockLevel},
            {"ReorderPoint", ReorderPoint},
            {"DaysToManufacture", DaysToManufacture},
            {"StandardCost", StandardCost},
            {"ModifiedDate", ModifiedDate},
            {"SellStartDate", SellStartDate}
        };
    }

}