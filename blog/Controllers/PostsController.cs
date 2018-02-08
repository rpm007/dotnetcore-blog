using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Core.Domain;
using Data;
using Microsoft.AspNetCore.Identity;

namespace Blog
{
    [Authorize]
    public class PostsController : MasterController
    {
        public PostsController(DataContext context, UserManager<User> userManager)
        {
            UnitOfWork = new UnitOfWork(context);
            UserManager = userManager;
        }

        // GET: Posts
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentIdentityUser();
            
            return user == null ?
                View(await UnitOfWork.Posts.GetAll()) 
                : View("Admin", await UnitOfWork.Posts.GetAll());
        }

        // GET: Posts/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await UnitOfWork.Posts.GetDisplay((int)id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            var post = new Post()
            {
                Author = "Robin McKavanagh",
                MetaAuthor = "Robin McKavanagh",
                CreateDate = DateTime.Today
            };

            return View(post);
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Posts.Add(post);
                await UnitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await UnitOfWork.Posts.Get((int)id);

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                UnitOfWork.Posts.Update(post);
                await UnitOfWork.Complete();

                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await UnitOfWork.Posts.Get((int)id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await UnitOfWork.Posts.Get((int)id);
            UnitOfWork.Posts.Remove(post);
            await UnitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
