using Emailer.API.Models;
using Emailer.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Emailer.API.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Emailer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]    
    [ApiController]    
    public class EmailsController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly Helper _helper;

        public EmailsController(IEmailService emailService, Helper helper)
        {
            _emailService = emailService;
            _helper = helper;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<Email>> Get() => _emailService.Get();

        [HttpGet("{id:length(24)}",Name="GetEmail")]        
        public ActionResult<Email> Get(string id)
        {
            var email = _emailService.Get(id);
        
            if (email == null)
            {
                return NotFound();
            } 

            return email;
        }

        [HttpPost]
        public ActionResult<Email> Create(Email email)
        {
            email.Updated = _helper.GetTimestamp();
            _emailService.Create(email);

            return CreatedAtRoute("GetEmail", new { id = email.Id.ToString() }, email);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Email newEmail)
        {
            var email = _emailService.Get(id);

            if (email == null)
            {
                return NotFound();
            }

            newEmail.Updated = _helper.GetTimestamp();
            newEmail.Id = email.Id;
            
            _emailService.Update(id, newEmail);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var email = _emailService.Get(id);

            if (email == null)
            {
                return NotFound();
            }

            _emailService.Remove(email.Id);

            return NoContent();
        }
    }
}