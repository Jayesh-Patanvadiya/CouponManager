using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;

namespace CouponManager.Services.CustomField
{
    [FirestoreData]

    public class CustomFields
    {
        public string Id { get; set; } // firebase unique id

        [FirestoreProperty]
        [Required]
        public string? FieldName { get; set; }


        [FirestoreProperty]
        [Required]
        public int ClientId { get; set; }

        [FirestoreProperty]
        public int FieldType { get; set; }

        [FirestoreProperty]
        public dynamic MultipleChoiceOptions { get; set; }

        [FirestoreProperty]
        public int  IsVisibleConditionFieldId { get; set; }

        [FirestoreProperty]
        public string? IsVisibleConditionFieldValue { get; set; }
    }
}
