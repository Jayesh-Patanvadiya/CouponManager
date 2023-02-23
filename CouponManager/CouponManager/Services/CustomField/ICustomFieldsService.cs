using CouponManager.Services.Coupons;

namespace CouponManager.Services.CustomField
{
    public interface ICustomFieldsService
    {
        Task<CustomFields> CreateCustomFields(CustomFields customField);
        Task<List<CustomFields>> GetAllCustomFieldss();
        Task<CustomFields> UpdateCustomFields(CustomFields customField);
        Task<string> DeleteCustomFields(string customFieldId);
        Task<CustomFields> GetCustomFieldsById(string customFieldId);
    }
}
