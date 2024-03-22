using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace Client.Pages.Admin.ChapterManage
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.Models.ProjectPRN231Context _context;

        public IndexModel(BusinessObject.Models.ProjectPRN231Context context)
        {
            _context = context;
        }

        public IList<Chapter> Chapter { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Chapters != null)
            {
                Chapter = await _context.Chapters
                .Include(c => c.Story).ToListAsync();
            }
        }
    }
}
