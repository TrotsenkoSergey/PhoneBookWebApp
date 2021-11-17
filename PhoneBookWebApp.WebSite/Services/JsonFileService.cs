using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.AspNetCore.Hosting;
using PhoneBookWebApp.WebSite.Models;

namespace PhoneBookWebApp.WebSite.Services
{
    public class JsonFileService
    {
        private IWebHostEnvironment _webHostEnvironment;

        public JsonFileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get => Path.Combine(_webHostEnvironment.WebRootPath, "data", "phonebook.json");
        }

        private JsonSerializerOptions Options
        {
            get => new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }

        public IEnumerable<PhoneBook> GetPhoneBook()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<PhoneBook[]>(
                    jsonFileReader.ReadToEnd(),
                    Options);
            }
        }

        public void SavePhoneBook(IEnumerable<PhoneBook> phoneBook)
        {
            //using (var outputStream = File.OpenWrite(JsonFileName))
            //{
            //    JsonSerializer.Serialize<IEnumerable<PhoneBook>>(
            //        new Utf8JsonWriter(outputStream, new JsonWriterOptions
            //        {
            //            SkipValidation = true,
            //            Indented = true
            //        }),
            //        phoneBook,
            //        Options
            //        );
            //}
            string json = JsonSerializer.Serialize<IEnumerable<PhoneBook>>(
                phoneBook, Options);
            File.WriteAllText(JsonFileName, json);
        }
    }
}