using CouponManager.Services.Coupons;
using CouponManager.Services.CustomField;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CouponManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFieldController : ControllerBase
    {
        ICustomFieldsService _customFieldsService;
        public CustomFieldController(ICustomFieldsService customFieldsService)
        {
            _customFieldsService = customFieldsService;
        }
        [HttpPost]
        public async Task<CustomFields> CreateCustomField([FromBody] CustomFields customField)
        {

            var createResult = await _customFieldsService.CreateCustomFields(customField);
            return createResult;

        }
        [HttpGet]
        public async Task<List<CustomFields>> GetAllCustomFieldss()
        {
            return await _customFieldsService.GetAllCustomFieldss();
        }

        [HttpGet("customFieldid")]
        public async Task<CustomFields> GetCustomFieldsById(string customFieldid)
        {
            return await _customFieldsService.GetCustomFieldsById(customFieldid);
        }


        [HttpPut]
        public async Task<CustomFields> UpdateCustomFields([FromBody] CustomFields customField)
        {

            return await _customFieldsService.UpdateCustomFields(customField);
        }

        [HttpDelete]
        public async Task<string> DeleteCustomFields(string customFieldid)
        {
            return await _customFieldsService.DeleteCustomFields(customFieldid);
        }
    }
}
