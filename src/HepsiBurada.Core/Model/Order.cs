namespace HepsiBurada.Core.Model
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }
    }
}
