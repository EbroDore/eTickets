using eTickets.Data.Cart;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class OrderController : Controller
    {

        private readonly IMovieService _movieService;
        private readonly ShoppingCart _shoppingCart;
        public OrderController(IMovieService movieService, ShoppingCart shoppingCart)
        {
            _movieService = movieService;
            _shoppingCart = shoppingCart;
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }


        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if(movie != null)
            {
                _shoppingCart.AddItemToCart(movie);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }



        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie != null)
            {
                _shoppingCart.RemoveItemFromCart(movie);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }


    }
}
