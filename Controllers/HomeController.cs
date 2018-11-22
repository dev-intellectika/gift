using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftApi.Core;
using GiftApi.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GiftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        Redirects redirects;

        public HomeController(Redirects redirects)
        {
            this.redirects = redirects;
        }

        [HttpGet("redirect/{platform}")]
        public IActionResult RedirectToApp(string platform)
        {
            return RedirectPermanent(redirects[platform]);
        }
    }
}
