using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace Client.Pages.Admin.StoryManage
{
    public class EditModel : PageModel
    {
        private readonly BusinessObject.Models.ProjectPRN231Context _context;

        public EditModel(BusinessObject.Models.ProjectPRN231Context context)
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

            var story =  await _context.Stories.FirstOrDefaultAsync(m => m.StoryId == id);
            if (story == null)
            {
                return NotFound();
            }
            Story = story;
           ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Story).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryExists(Story.StoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StoryExists(int id)
        {
          return (_context.Stories?.Any(e => e.StoryId == id)).GetValueOrDefault();
        }
    }
}
