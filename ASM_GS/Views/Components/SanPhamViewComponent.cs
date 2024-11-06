using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASM_GS.Models;
using System.Collections.Generic;
using System.Linq;
using ASM_GS.Controllers;

namespace ASM_GS.ViewComponents
{
    public class SanPhamViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SanPhamViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var sanPhams = _context.SanPhams.Include(s => s.AnhSanPhams).ToList();
            return View(sanPhams);
        }
    }
}
