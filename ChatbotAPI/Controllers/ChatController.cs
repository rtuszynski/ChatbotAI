using ChatbotAPI.Features.ChatMessages.Commands;
using ChatbotAPI.Features.ChatMessages.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("messages")]
    public async Task<IActionResult> GetMessages()
    {
        var messages = await _mediator.Send(new GetChatMessagesQuery());
        return Ok(messages);
    }

    [HttpPost("messages")]
    public async Task<IActionResult> AddMessage([FromBody] AddChatMessageCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var message = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetMessages), new { id = message.Id }, message);
    }

    [HttpPut("messages/{id}")]
    public async Task<IActionResult> UpdateMessage(int id, [FromBody] UpdateChatMessageCommand command)
    {
        if (id != command.Id || !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(command);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPut("messages/{id}/rating")]
    public async Task<IActionResult> UpdateRating(int id, [FromBody] int rating)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(new UpdateChatMessageRatingCommand(id, rating));
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
