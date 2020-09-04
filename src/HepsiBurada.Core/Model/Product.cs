namespace HepsiBurada.Core.Model
{
    public class Product
    {
        public virtual string Code { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Stock { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}
