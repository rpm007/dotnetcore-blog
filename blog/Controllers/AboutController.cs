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
    public class AboutController : MasterController
    {
        public AboutController(DataContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

    }
}