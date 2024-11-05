using ReconsB.Model;

namespace ReconsB.model
{
    public class PurchaseOrderItem
    {
        public int ItemId { get; set; } // Primary Key
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        // Foreign key to relate to PurchaseOrder
        public int PurchaseOrderId { get; set; } // Foreign Key
        public virtual PurchaseOrder PurchaseOrder { get; set; } // Navigation property to PurchaseOrder
    }
}
