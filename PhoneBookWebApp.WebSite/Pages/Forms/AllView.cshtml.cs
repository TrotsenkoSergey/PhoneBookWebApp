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
    public class AllViewModel : PageModel
    {
        private readonly ILogger<AllViewModel> _logger;

        public AllViewModel(ILogger<AllViewModel> logger,
           JsonFileService phoneBookFileService)
        {
            _logger = logger;
            PhoneBookFileService = phoneBookFileService;
        }

        public JsonFileService PhoneBookFileService { get; }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public PhoneBook PhoneBookEntity { get; private set; }

        public void OnGet()
        {
            if (!String.IsNullOrEmpty(Id))
            {
                var phoneBooks = PhoneBookFileService.GetPhoneBook();
                PhoneBookEntity = phoneBooks.First(e => e.Id == Int32.Parse(Id));
            }
        }
    }
}
