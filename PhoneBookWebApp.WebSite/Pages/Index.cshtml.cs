using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PhoneBookWebApp.WebSite.Models;
using PhoneBookWebApp.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
           
namespace PhoneBookWebApp.WebSite.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,
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

        //public IActionResult OnPost() 
        //{
        //    return RedirectToPage("", Id);
        
        //}
    }
}
