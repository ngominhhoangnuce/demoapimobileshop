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
        public IActionResult GetAllCartItems()
        {
            try
            {
                var shopcarts = _shopcartRepository.GetAllCartItems(); // Lấy tất cả dữ liệu từ bảng Shopcarts
                return Ok(shopcarts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int ShopCartID)
        {
            var item = _shopcartRepository.GetById(ShopCartID);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Add(ShopCart item)
        {
            _shopcartRepository.Add(item);
            return CreatedAtAction(nameof(GetById), new { ShopCartID = item.ShopCartID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int ShopCartID,ShopCart item)
        {
            if (ShopCartID != item.Id)
            {
                return BadRequest();
            }
            _shopcartRepository.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int ShopCartID)
        {
            var item = _shopcartRepository.GetById(ShopCartID);
            if (item == null)
            {
                return NotFound();
            }
            _shopcartRepository.Delete(item);
            return NoContent();
        }
    }
}
