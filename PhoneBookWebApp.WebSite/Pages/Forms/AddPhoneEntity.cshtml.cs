using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PhoneBookWebApp.WebSite.Models;
using PhoneBookWebApp.WebSite.Services;

namespace PhoneBookWebApp.WebSite.Pages.Forms
{
    public class AddPhoneEntityModel : PageModel
    {
        private readonly ILogger<AddPhoneEntityModel> _logger;

        public AddPhoneEntityModel(ILogger<AddPhoneEntityModel> logger,
           JsonFileService phoneBookFileService)
        {
            _logger = logger;
            PhoneBookFileService = phoneBookFileService;
        }

        public JsonFileService PhoneBookFileService { get; }

        public IEnumerable<PhoneBook> PhoneBook { get; private set; }

        public void OnGet()
        {
            PhoneBook = PhoneBookFileService.GetPhoneBook();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string lastName = Request.Form["LastName"];
                string firstName = Request.Form["FirstName"];
                string middleName = Request.Form["MiddleName"];
                string phoneNumber = Request.Form["PhoneNumber"];
                string address = Request.Form["Address"];
                string description = Request.Form["Description"];

                var phoneBooks = PhoneBookFileService.GetPhoneBook().ToList();

                int id = (phoneBooks.Count != 0) ? (phoneBooks.Max(e => e.Id) + 1) : 1;

                var phoneBook = new PhoneBook()
                {
                    Id = id,
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    PhoneNumber = phoneNumber,
                    Address = address,
                    Description = description
                };
                phoneBooks.Add(phoneBook);

                PhoneBookFileService.SavePhoneBook(phoneBooks);

                return RedirectToPage("/Index");
            }
            else return Page();
        }
    }
}
