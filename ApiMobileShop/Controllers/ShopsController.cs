using ApiMobileShop.Data;
using ApiMobileShop.Models;
using ApiMobileShop.Reponsitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiMobileShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ShopsController : ControllerBase
    {
        private readonly IShopResponsitory _shopmodel;

        public ShopsController(IShopResponsitory shopmodel)
        {
            _shopmodel = shopmodel;
        }

        [HttpGet]
        public ActionResult<List<ShopModel>> GetAllProducts()
        {
            var products = _shopmodel.GetAllProducts();
            return Ok(products);
        }
    }
}
