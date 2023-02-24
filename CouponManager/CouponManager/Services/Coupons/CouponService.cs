using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace CouponManager.Services.Coupons
{
    public class CouponService : ICouponService
    {
        string projectId;
        FirestoreDb fireStoreDb;

        public CouponService()
        {
            //_configuration = configuration;
            string filepath = @"\test-2a07f-4688daf8c712.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);

            projectId = "test-2a07f";
            fireStoreDb = FirestoreDb.Create(projectId);
        }



        public async Task<Coupon> CreateCoupon(Coupon coupon)
        {
            try
            {

                CollectionReference colRef = fireStoreDb.Collection("coupons");
                var result = await colRef.AddAsync(coupon);

                coupon.Id = result.Id;
                return coupon;

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }

        }

        public async Task<List<Coupon>> GetAllCoupons()
        {
            Query couponQuery = fireStoreDb.Collection("coupons");
            QuerySnapshot couponQuerySnapshot = await couponQuery.GetSnapshotAsync();
            List<Coupon> coupons = new List<Coupon>();

            foreach (DocumentSnapshot documentSnapshot in couponQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Coupon coupon = documentSnapshot.ConvertTo<Coupon>();
                    coupon.Id = documentSnapshot.Id;
                    coupons.Add(coupon);
                }
            }

            return coupons.Where(x=>x.ExpirationDate >= DateTime.Now.Date).ToList();

        }

        public async Task<Coupon> UpdateCoupon(Coupon coupon)
        {
            DocumentReference ezCoupons = fireStoreDb.Collection("coupons").Document(coupon.Id);
            await ezCoupons.SetAsync(coupon, SetOptions.Overwrite);
            return coupon;

        }
        public async Task<Coupon> GetCouponById(string couponId)
        {
            try
            {
                DocumentReference docRef = fireStoreDb.Collection("coupons").Document(couponId);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Coupon coupons = snapshot.ConvertTo<Coupon>();
                    coupons.Id = snapshot.Id;
                    return coupons;
                }
                else
                {
                    return new Coupon();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }

        }
        public async Task<string> DeleteCoupon(string couponId)
        {
            try
            {
                DocumentReference ezCoupons = fireStoreDb.Collection("coupons").Document(couponId);
                await ezCoupons.DeleteAsync();
                return "Deleted Successfully!";
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }
    }
}
