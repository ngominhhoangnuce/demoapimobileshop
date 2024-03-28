using ApiMobileShop.Data;
using ApiMobileShop.Models;
using ApiMobileShop.Reponsitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiMobileShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopResponsitory _shopmodel;

        public ShopsController(IShopResponsitory shopmodel)
        {
            _shopmodel = shopmodel;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var shops = _shopmodel.GetAllProducts(); // Lấy tất cả dữ liệu từ bảng Shop
                return Ok(shops);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
