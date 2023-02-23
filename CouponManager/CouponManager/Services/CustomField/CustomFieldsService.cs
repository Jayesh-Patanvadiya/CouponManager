using CouponManager.Services.Coupons;
using Google.Cloud.Firestore;
using Google.Type;
using System.Reflection;
using System.Text.Json;

namespace CouponManager.Services.CustomField
{
    public class CustomFieldsService : ICustomFieldsService
    {
        string projectId;
        FirestoreDb fireStoreDb;

        public CustomFieldsService()
        {
            //_configuration = configuration;
            string filepath = @"\test-2a07f-4688daf8c712.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);

            projectId = "test-2a07f";
            fireStoreDb = FirestoreDb.Create(projectId);
        }



        public async Task<CustomFields> CreateCustomFields(CustomFields customField)
        {
            try
            {
                //var test = customField.MultipleChoiceOptions.ValueKind;
               
                //var test2 = Convert.ToString( customField.MultipleChoiceOptions);

                var customFields = new CustomFields()
                {
                    ClientId = customField.ClientId,
                    FieldName = customField.FieldName,
                    FieldType = customField.FieldType,
                    IsVisibleConditionFieldId = customField.IsVisibleConditionFieldId,
                    IsVisibleConditionFieldValue = customField.IsVisibleConditionFieldValue,
                    MultipleChoiceOptions = customField.MultipleChoiceOptions
                };

                CollectionReference colRef = fireStoreDb.Collection("customfields");
                var result = await colRef.AddAsync(customField);

                customField.Id = result.Id;
                return customField;

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }

        }

        public async Task<List<CustomFields>> GetAllCustomFieldss()
        {
            Query customFieldQuery = fireStoreDb.Collection("customfields");
            QuerySnapshot customFieldQuerySnapshot = await customFieldQuery.GetSnapshotAsync();
            List<CustomFields> CustomFieldss = new List<CustomFields>();

            foreach (DocumentSnapshot documentSnapshot in customFieldQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    CustomFields customFields = documentSnapshot.ConvertTo<CustomFields>();
                    customFields.Id = documentSnapshot.Id;
                    CustomFieldss.Add(customFields);
                }
            }
            return CustomFieldss;

        }

        public async Task<CustomFields> UpdateCustomFields(CustomFields customField)
        {
            DocumentReference ezCustomFieldss = fireStoreDb.Collection("customfields").Document(customField.Id);
            await ezCustomFieldss.SetAsync(customField, SetOptions.Overwrite);
            return customField;

        }
        public async Task<CustomFields> GetCustomFieldsById(string customFieldId)
        {
            try
            {
                DocumentReference docRef = fireStoreDb.Collection("customfields").Document(customFieldId);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    CustomFields customField = snapshot.ConvertTo<CustomFields>();
                    customField.Id = snapshot.Id;
                    return customField;
                }
                else
                {
                    return new CustomFields();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }

        }
        public async Task<string> DeleteCustomFields(string customFieldId)
        {
            try
            {
                DocumentReference customFields = fireStoreDb.Collection("customfields").Document(customFieldId);
                await customFields.DeleteAsync();
                return "Deleted Successfully!";
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }
    }
}

