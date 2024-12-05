using les3.Models;
using les3.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Mail;

namespace les3.Controllers
{
       [Route("api/[controller]")]
       [ApiController]
        public class AttachmentController : ControllerBase
        {
            private readonly IAttachmentService _attachmentService;

            public AttachmentController(IAttachmentService attachmentService)
            {
                _attachmentService = attachmentService;
            }


        [HttpPost]
        public IActionResult CreateAttachment([FromBody] Attachments model)
        {
            if (model == null || string.IsNullOrEmpty(model.FileName) || string.IsNullOrEmpty(model.FilePath) || string.IsNullOrEmpty(model.Size) || string.IsNullOrEmpty(model.Description))
            {
                return BadRequest("All fields are required.");
            }

            DataTable result = _attachmentService.CreateAttachment(model.FileName, model.FilePath, model.Size, model.Description);
            return Ok(result);
        }

        [HttpPost("/transaction")]
        public IActionResult Create([FromBody] AttachmentWithTask model)
        {
            if (model == null || model.attachment == null || model.task == null)
            {
                return BadRequest("Attachment and Task are required.");
            }

            bool success = _attachmentService.Create(model);
            if (success)
            {
                return Ok("Transaction completed successfully.");
            }
            return StatusCode(500, "Failed to process transaction.");
        }
    }
}
