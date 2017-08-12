using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Flickr.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IO;
using Microsoft.AspNetCore.Http;

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
            return View(_db.Pictures.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile img)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            byte[] newPhoto = new byte[0];
            if (img != null)
            {
                using (Stream fileStream = img.OpenReadStream())
                using (MemoryStream ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    newPhoto = ms.ToArray();
                }
            }
            Picture newPicture = new Picture(newPhoto);
             newPicture.UserId = userId;
            _db.Pictures.Add(newPicture);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
