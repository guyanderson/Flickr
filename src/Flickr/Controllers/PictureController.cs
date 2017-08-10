using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Flickr.Models;
using Microsoft.AspNetCore.Identity;

namespace Flickr.Controllers
{
    [Authorize]
    public class PictureController : Controller
    {
        private readonly FlickrDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PictureController(UserManager<ApplicationUser> userManager, FlickrDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
