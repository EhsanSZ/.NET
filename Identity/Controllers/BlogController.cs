using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Data;
using Identity.Models.Dto.Blog;
using Identity.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Bugeto.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BlogController : Controller
    {
        private readonly DataBaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IAuthorizationService _authorizationService;
        public BlogController(DataBaseContext context,
            UserManager<User> userManager
            , IAuthorizationService authorizationService)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }
        public IActionResult Index()
        {
            var blogs = _context.Blogs
                .Include(p => p.User)
                .Select(
                p => new BlogDto
                {
                    Id = p.Id,
                    Body = p.Body,
                    Title = p.Title,
                    UserName = p.User.UserName
                });
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogDto blog)
        {
            var user = _userManager.GetUserAsync(User).Result;
            Blog newBlog = new Blog()
            {
                Body = blog.Body,
                Title = blog.Title,
                User = user,
            };
            _context.Add(newBlog);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(long Id)
        {
            var blog = _context.Blogs
                .Include(p => p.User)
                .Where(p => p.Id == Id)
                .Select(p => new BlogDto
                {
                    Body = p.Body,
                    Id = p.Id,
                    Title = p.Title,
                    UserId = p.UserId,
                    UserName = p.User.UserName
                }).FirstOrDefault();

            var result = _authorizationService.AuthorizeAsync(User, blog, "IsBlogForUser").Result;
           if(result.Succeeded)
            {
                return View(blog);
            }
           else
            {
                return new ChallengeResult();
            }
        }

        [HttpPost]
        public IActionResult Edit(BlogDto blog)
        {
            ///
            return View();
        }
    }
}
