using System;

namespace PharmacyManagementSystem
{
    public class Medicine
    {
        public int MedicineID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Medicine()
        {
        }

        public Medicine(int medicineId, string name, string category, decimal price, int quantity)
        {
            MedicineID = medicineId;
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Name} - {Category} (₦{Price:F2}) - Stock: {Quantity}";
        }

        public bool IsInStock()
        {
            return Quantity > 0;
        }

        public bool HasSufficientStock(int requiredQuantity)
        {
            return Quantity >= requiredQuantity;
        }
    }

    public class Sale
    {
        public int SaleID { get; set; }
        public int MedicineID { get; set; }
        public int QuantitySold { get; set; }
        public DateTime SaleDate { get; set; }

        public Sale()
        {
            SaleDate = DateTime.Now;
        }

        public Sale(int saleId, int medicineId, int quantitySold, DateTime saleDate)
        {
            SaleID = saleId;
            MedicineID = medicineId;
            QuantitySold = quantitySold;
            SaleDate = saleDate;
        }

        public override string ToString()
        {
            return $"Sale #{SaleID} - Quantity: {QuantitySold} - Date: {SaleDate:dd/MM/yyyy}";
        }
    }
}