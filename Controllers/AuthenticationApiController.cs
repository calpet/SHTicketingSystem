using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using SelfHelpTicketingSystem.Models;
using Shts_BusinessLogic;
using Shts_BusinessLogic.Models;
using Shts_Entities.Enums;

namespace SelfHelpTicketingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationApiController : ControllerBase
    {
        private User _user;
        private Account _account;

        public AuthenticationApiController()
        {
            _user = new User();
            _account = new Account();
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserViewModel uvm)
        {
            if (uvm != null && !string.IsNullOrEmpty(uvm.Email) && !string.IsNullOrEmpty(uvm.Password))
            {
                bool status = _account.ValidateCredentials(uvm.Email, uvm.Password);
                return Ok(uvm);
            }
           
            return StatusCode(401);
               
            
        }
    }
}
