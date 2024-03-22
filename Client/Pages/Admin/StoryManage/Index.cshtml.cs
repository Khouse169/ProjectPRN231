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
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.Models.ProjectPRN231Context _context;

        public IndexModel(BusinessObject.Models.ProjectPRN231Context context)
        {
            _context = context;
        }

        public IList<Story> Story { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stories != null)
            {
                Story = await _context.Stories
                .Include(s => s.Genre).ToListAsync();
            }
        }
    }
}
