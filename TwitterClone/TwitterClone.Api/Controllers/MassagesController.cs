using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MassagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MassagesController(
            IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<MessageDto>), StatusCodes.Status200OK)]
        public IActionResult GetMessages([FromQuery] Guid? senderId, [FromQuery] Guid? receiverId)
        {
            return Ok(_messageService.GetMessages(senderId, receiverId));
        }

        [HttpGet("{massageId}")]
        [ProducesResponseType(typeof(MessageDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMessageById([FromRoute] Guid massageId)
        {
            var message = _messageService.GetMessageById(massageId);

            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }


        [HttpGet("conversation")]
        [ProducesResponseType(typeof(List<MessageDto>), StatusCodes.Status200OK)]
        public IActionResult GetConversation([FromQuery] Guid userId, [FromQuery] Guid otherUserId)
        {
            return Ok(_messageService.GetConversation(userId, otherUserId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(MessageDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SendMessage([FromBody] CreateMessageDto createMessageDto)
        {

            var sentMessage = _messageService.SendMessage(createMessageDto);

            if (sentMessage == null)
            {
                return BadRequest("Both users must exist, and a user cannot message themselves.");
            }
            return CreatedAtAction(nameof(GetMessageById), new { id = sentMessage.Id }, sentMessage);
        }

        [HttpPut("massageId:{massageId}")]
        [ProducesResponseType(typeof(MessageDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateMessage([FromRoute] Guid massageId, [FromBody] UpdateMessageDto updateMessageDto)
        {

            var message = _messageService.UpdateMessage(massageId, updateMessageDto);

            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPatch("{massageId}/read")]
        [ProducesResponseType(typeof(MessageDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult MarkMessageAsRead([FromRoute] Guid massageId)
        {
            var message = _messageService.MarkMessageAsRead(massageId);

            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpDelete("massageId:{massageId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteMessage([FromRoute] Guid massageId)
        {
            var isDeleted = _messageService.DeleteMessage(massageId);

            if (isDeleted == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
