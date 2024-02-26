using JollyAPI.Models.Entity;

namespace JollyAPI.DAO
{
    public class WishListDAO
    {
        private readonly JollyShoppingOnlineContext _context;

        public WishListDAO(JollyShoppingOnlineContext context)
        {
            _context = context;
        }

        public WishList CreateWishList(WishList wishList)
        {
            _context.WishLists.Add(wishList);
            _context.SaveChanges();
            return wishList;
        }
    }
}
