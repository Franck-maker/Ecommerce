using Discount.Application.DTOs;
using Discount.Core.Entities;

namespace Discount.Application.Mappers
{
    public static class CouponMapper
    {
        public static CouponDto ToDto(this Coupon coupon)
        {
            return new CouponDto(
                coupon.Id,
                coupon.ProductName,
                coupon.Description,
                coupon.Amount); 
        }
    }
}
