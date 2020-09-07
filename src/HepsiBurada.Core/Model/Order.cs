using System;

namespace HepsiBurada.Core.Model
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Campaign Campaign {get; set;}
        public virtual DateTime CreatedAt {get; set;}
    }
}
