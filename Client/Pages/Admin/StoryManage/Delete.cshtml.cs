using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace Client.Pages.Admin.StoryManage
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObject.Models.ProjectPRN231Context _context;

        public DeleteModel(BusinessObject.Models.ProjectPRN231Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Story Story { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stories == null)
            {
                return NotFound();
            }

            var story = await _context.Stories.FirstOrDefaultAsync(m => m.StoryId == id);

            if (story == null)
            {
                return NotFound();
            }
            else 
            {
                Story = story;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Stories == null)
            {
                return NotFound();
            }
            var story = await _context.Stories.FindAsync(id);

            if (story != null)
            {
                Story = story;
                _context.Stories.Remove(Story);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
