using CouponManager.Services.Coupons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CouponManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        [HttpPost]
        public async Task<Coupon> CreateCoupon([FromBody] Coupon coupon)
        {

            var createResult = await _couponService.CreateCoupon(coupon);
            return createResult;

        }
        [HttpGet]
        public async Task<List<Coupon>> GetAllCoupons()
        {
            return await _couponService.GetAllCoupons();
        }

        [HttpGet("couponid")]
        public async Task<Coupon> GetCouponById(string couponid)
        {
            return await _couponService.GetCouponById(couponid);
        }


        [HttpPut]
        public async Task<Coupon> UpdateCoupon([FromBody] Coupon coupon)
        {

            return await _couponService.UpdateCoupon(coupon);
        }

        [HttpDelete]
        public async Task<string> DeleteCoupon(string couponid)
        {
            return await _couponService.DeleteCoupon(couponid);
        }
    }
}
