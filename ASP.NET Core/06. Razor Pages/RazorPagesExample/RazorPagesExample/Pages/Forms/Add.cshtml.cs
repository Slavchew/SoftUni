using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesExample.Pages.Forms
{
    public class AddModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        [Required]
        public string Name { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required]
        public string Town { get; set; }

        [BindProperty(SupportsGet = true)]
        [Range(2.00, 5.00)]
        public decimal Salary { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return Content(Name);
        }
    }
}
