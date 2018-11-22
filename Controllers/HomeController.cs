using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftApi.Core;
using GiftApi.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GiftApi.Controllers
{
    public class HomeController : ControllerBase
    {
        Redirects redirects;

        public HomeController(Redirects redirects)
        {
            this.redirects = redirects;
        }

        public IActionResult Index()
        {
            var url = redirects[GetUserPlatform(Request)];

            if (url == "")
            {
                return BadRequest();
            }

            return RedirectPermanent(url);
        }

        private string GetUserPlatform(HttpRequest request)
        {
            var ua = request.Headers["User-Agent"].ToString();

            if (ua.Contains("Android"))
                return "android";

            if (ua.Contains("iPad") || ua.Contains("iPhone") || ua.Contains("Mac OS"))
                return "ios";

            return "";
        }

        private string GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;

            foreach (var character in temp)
            {
                var validCharacter = false;
                int test = 0;

                if (Int32.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                    break;
            }

            return version;
        }
    }
}
