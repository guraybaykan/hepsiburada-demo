namespace HepsiBurada.Model.Request
{
    public class ProductRequest
    {
        public virtual string Code { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Stock { get; set; }
    }
}
