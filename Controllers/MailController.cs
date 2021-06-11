using BackendUsers.BL.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        [HttpPost]
        public ActionResult SendMail(string Title, string Message)
        {
            var result = MailHelper.SendMail(Title, Message);
            return Ok(result);

        }

    }
}
