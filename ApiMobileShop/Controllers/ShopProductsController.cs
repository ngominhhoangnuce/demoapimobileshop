using ApiMobileShop.Models;
using ApiMobileShop.Reponsitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiMobileShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ShopProductsController : ControllerBase
    {
        private readonly IShopProductResponsitory _shopproduct;

        public ShopProductsController(IShopProductResponsitory shopproduct)
        {
            _shopproduct = shopproduct;
        }

        [HttpGet("{ShopProductID}")]
        public ActionResult<ShopProductModel> GetProductById(int ShopProductID)
        {
            var product = _shopproduct.GetProductById(ShopProductID);

            if (product == null)
            {
                return NotFound(); // Trả về HTTP 404 Not Found nếu sản phẩm không tồn tại
            }
            return Ok(product);
        }
    }
}
