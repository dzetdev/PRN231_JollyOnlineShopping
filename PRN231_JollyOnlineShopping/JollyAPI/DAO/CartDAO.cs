using JollyAPI.Models.Entity;

namespace JollyAPI.DAO
{
    public class CartDAO
    {
        private readonly JollyShoppingOnlineContext _context;

        public CartDAO(JollyShoppingOnlineContext context)
        {
            _context = context;
        }

        public Cart CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return cart;
        }
    }
}
