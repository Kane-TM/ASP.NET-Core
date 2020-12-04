using KiemTraTuan11.Data;
using KiemTraTuan11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KiemTraTuan11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DPContext _context;


        public HomeController(ILogger<HomeController> logger, DPContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int ?id)
        {
            ViewData["Action"] = "true";
            if (id == null)
            {
                id = 0;
            }
            ViewBag.Folder = _context.Folder.Where(folders => folders.ParentsId == id && folders.status == true);
            ViewBag.File = _context.File.Where(files => files.FolderId == id && files.Status == true);
            ViewData["folder-id"] = id;
            return View();
        }

        public IActionResult RecycleBin()
        {
            ViewData["Action"] = "false";
            ViewBag.Folder = _context.Folder.Where(folders =>  folders.status == true);
            ViewBag.File = _context.File.Where(files =>  files.Status == true);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
