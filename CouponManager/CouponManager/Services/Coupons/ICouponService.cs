namespace CouponManager.Services.Coupons
{
    public interface ICouponService
    {
        Task<Coupon> CreateCoupon(Coupon coupon);
        Task<List<Coupon>> GetAllCoupons();
        Task<Coupon> UpdateCoupon(Coupon coupon);
        Task<string> DeleteCoupon(string couponId);
        Task<Coupon> GetCouponById(string couponId);
    }
}
