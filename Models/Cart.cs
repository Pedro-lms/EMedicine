using System.Collections.Generic;

namespace EMedicine.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public Users User { get; set; }
        public int UserId { get; set; }
        public List<Medicines> Medicines { get; set; }
        public int MedicinesId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
