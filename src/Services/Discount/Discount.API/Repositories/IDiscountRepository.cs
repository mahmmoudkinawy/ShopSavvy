namespace Discount.API.Repositories;
public interface IDiscountRepository
{
    Task<CouponEntity?> GetDiscountByProductNameAsync(string productName);
    Task<CouponEntity?> GetDiscountByCouponIdAsync(int couponId);
    Task<bool> CreateDiscountAsync(CouponEntity coupon);
    Task<bool> UpdateDiscountAsync(CouponEntity coupon, int couponId);
    Task<bool> DeleteDiscountAsync(string productName);
    Task<bool> IsDiscountExistByProductNameAsync(string productName);
    Task<bool> IsDiscountExistByCouponIdAsync(int discountId);
}
