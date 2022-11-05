using System.Collections.Generic;

namespace EMedicine.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Users> User { get; set; }
        public Users Users { get; set; }
        public List<Medicines> Medicines { get; set; }
        public Medicines Medicine { get; set; }
        public List<Cart> ListCarts { get; set; }
        public Cart Carts { get; set; }
        public List<Orders> ListOrders { get; set; }
        public Orders Orders { get; set; }
        public List<OrderItems> ListOrderItems { get; set; }
        public OrderItems OrderItems { get; set; }
    }
}
