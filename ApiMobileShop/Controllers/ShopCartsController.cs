using ApiMobileShop.Data;
using ApiMobileShop.Models;
using ApiMobileShop.Reponsitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiMobileShop.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class ShopCartsController : ControllerBase
    {
        private readonly IShopCartResponsitory _shopcartRepository;

        public ShopCartsController(IShopCartResponsitory shopcartRepository)
        {
            _shopcartRepository = shopcartRepository;
        }

        [HttpGet]
        public ActionResult<List<ShopCartModel>> GetCartItems()
        {
            var ShopCarts = _shopcartRepository.GetCartItems();
            return Ok(ShopCarts);
        }

        [HttpPost("Add")]
        public ActionResult AddToCart([FromBody] ShopCart ShopCart)
        {
            if (ShopCart == null || ShopCart.ShopCartID <= 0 || ShopCart.Soluong <= 0 || ShopCart.Price <= 0)
            {
                return BadRequest();
            }

            _shopcartRepository.AddToCart(ShopCart);

            return Ok();
        }

        [HttpPut("Update")]
        public ActionResult UpdateCartItem([FromBody] ShopCart ShopCart)
        {
            if (ShopCart == null || ShopCart.ShopCartID <= 0 || ShopCart.Soluong <= 0)
            {
                return BadRequest();
            }

            _shopcartRepository.UpdateCartItem(ShopCart);

            return Ok();
        }

        [HttpDelete("{ShopCartID}")]
        public ActionResult RemoveCart(int ShopCartID)
        {
            _shopcartRepository.RemoveCart(ShopCartID);

            return Ok();
        }
    }
}
