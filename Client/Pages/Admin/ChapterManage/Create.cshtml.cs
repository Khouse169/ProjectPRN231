using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;

namespace Client.Pages.Admin.ChapterManage
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.Models.ProjectPRN231Context _context;

        public CreateModel(BusinessObject.Models.ProjectPRN231Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StoryId"] = new SelectList(_context.Stories, "StoryId", "Title");
            return Page();
        }

        [BindProperty]
        public Chapter Chapter { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Chapters == null || Chapter == null)
            {
                return Page();
            }

            _context.Chapters.Add(Chapter);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
