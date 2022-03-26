using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestVNR.Models;

namespace TestVNR.Controllers
{
    public class HomeController : Controller
    {
        private readonly VNR_InternShipContext _context;

        public HomeController(VNR_InternShipContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var testVNR = _context.MonHoc.Include(m => m.KhoaHoc);
            var kq = _context.MonHoc.Where(kq => kq.KhoaHocId == 1).ToList<MonHoc>();
            return View(kq.ToList());
        } 
        public IActionResult BackEnd()
        {
            var testVNR = _context.MonHoc.Include(m => m.KhoaHoc);
            var kq = _context.MonHoc.Where(kq => kq.KhoaHocId == 2).ToList<MonHoc>();
            return View(kq.ToList());
        }
        public IActionResult DotNetCore()
        {
            var testVNR = _context.MonHoc.Include(m => m.KhoaHoc);
            var kq = _context.MonHoc.Where(kq => kq.KhoaHocId == 3).ToList<MonHoc>();
            return View(kq.ToList());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
