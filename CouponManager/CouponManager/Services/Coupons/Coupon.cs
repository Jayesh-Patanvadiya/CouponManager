using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;

namespace CouponManager.Services.Coupons
{
    [FirestoreData]

    public class Coupon
    {
        public string Id { get; set; } // firebase unique id

        [FirestoreProperty]
        [Required]
        public string? CouponName { get; set; }


        [FirestoreProperty]
        [Required]
        [Range(0, 100, ErrorMessage = "Coupon Value must be less than 100.")]
        public int CouponValue { get; set; }

        [FirestoreProperty]
        [Required]
        public DateTime ExpirationDate { get; set; }
    }
}
