namespace CRM.Core.Entities
{
    public class DealProduct : BaseEntity
    { 
        public int DealId { get; set; }
        public Deal Deal { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
