using System.Text.Json;
using System.Text.Json.Serialization;

namespace PhoneBookWebApp.WebSite.Models
{
    public class PhoneBook
    {
        public PhoneBook() {}

        public PhoneBook(int id, string lastName, string firstName, string middleName,
            string phoneNumber, string address, string description) : this()
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            Address = address;
            Description = description;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }
        
        [JsonPropertyName("middlename")]
        public string MiddleName { get; set; }

        [JsonPropertyName("phonenumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        public override string ToString() =>
            JsonSerializer.Serialize<PhoneBook>(
            this,
            new JsonSerializerOptions() { WriteIndented = true }
            );
    }
}
